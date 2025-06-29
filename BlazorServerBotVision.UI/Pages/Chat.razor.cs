using BlazorServerBotVision.Application.DTOs;
using BlazorServerBotVision.Application.Interfaces;
using BlazorServerBotVision.UI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;


namespace BlazorServerBotVision.UI.Pages
{
    [Authorize]
    public partial class Chat : ComponentBase
    {
        [Inject] private IChatOrchestrationService ChatOrchestrator { get; set; } = default!;
        [Inject] private IUserService UserService { get; set; } = default!;
        [Inject] private AuthenticationStateProvider AuthStateProvider { get; set; } = default!;
        [Inject] private IJSRuntime JSRuntime { get; set; } = default!;

        // State
        private string prompt = "";
        private bool isBusy, isDictating;
        private string status = "", speechError = "", liveText = "";
        private string language = "de-DE";
        private bool enableSpeak = true;

        private Guid userId;
        private string userFirstName = "";
        private List<ChatHistoryDTO> history = new();
        private ChatHistoryDTO? lastAnswer;
        private Guid? selectedId;

        private bool HasReachedDailyLimit =>
          history.Count(h => h.CreatedAt.Date == DateTime.Today) >= 3;

        protected override async Task OnInitializedAsync()
        {
            var auth = await AuthStateProvider.GetAuthenticationStateAsync();
            var email = auth.User.Identity?.Name;
            if (string.IsNullOrEmpty(email)) return;

            var u = await UserService.GetUserByEmailAsync(email);
            userId = u.Id;
            userFirstName = u.FirstName;
            history = (await ChatOrchestrator.GetHistoryAsync(userId)).ToList();
            await JSRuntime.InvokeVoidAsync("scrollToEnd", historyDiv);
        }

        public async Task StartDictation()
        {
            speechError = "";
            liveText = "";
     
            if (isDictating && recognizer != null)
            {
                await StopContinuous();
                return;
            }

            try
            {
                isDictating = true;
                prompt = await JSRuntime.RecognizeOnceAsync(language);
            }
            catch (Exception ex)
            {
                speechError = ex.Message;
            }
            finally
            {
                isDictating = false;
            }
        }

        private ContinuousSpeechRecognizer? recognizer;
        public async Task ToggleContinuous()
        {
            speechError = "";
            liveText = "";

            if (isDictating)
            {
                await StopContinuous();
                return;
            }

            recognizer = new ContinuousSpeechRecognizer(JSRuntime, language);
            recognizer.Recognized += OnRecognized;
            recognizer.Error += OnError;

            isDictating = true;
            await recognizer.StartAsync();
        }

        private async Task StopContinuous()
        {
            if (recognizer != null)
            {
                await recognizer.StopAsync();
                await recognizer.DisposeAsync();
            }
            isDictating = false;
        }

        private Task OnRecognized(string text, bool isFinal)
        {
            liveText = text;
            StateHasChanged();
            if (isFinal) prompt = text;
            return Task.CompletedTask;
        }

        private Task OnError(string msg)
        {
            speechError = msg;
            isDictating = false;
            StateHasChanged();
            return Task.CompletedTask;
        }

        public async Task HandleAsk()
        {
            if (isBusy || HasReachedDailyLimit || string.IsNullOrWhiteSpace(prompt))
                return;

            isBusy = true;
            status = "";

            try
            {
                lastAnswer = await ChatOrchestrator.AskAsync(userId, prompt, true);

                if (enableSpeak)
                    await JSRuntime.SpeakAsync(lastAnswer.AIResponse, language);

                history = (await ChatOrchestrator.GetHistoryAsync(userId)).ToList();
                await JSRuntime.InvokeVoidAsync("scrollToEnd", historyDiv);

                status = "gespeichert!";
                prompt = "";
            }
            catch (Exception ex)
            {
                status = $"Fehler: {ex.Message}";
            }
            finally
            {
                isBusy = false;
            }
        }

        public Task HandleKeyUp(KeyboardEventArgs e) =>
          (e.Key == "Enter" && !e.ShiftKey)
            ? HandleAsk()
            : Task.CompletedTask;

        public async Task Delete(Guid id)
        {
            await ChatOrchestrator.DeleteAsync(userId, id);
            history.RemoveAll(h => h.Id == id);
            if (selectedId == id) selectedId = null;
            status = "Eintrag gelöscht.";
        }

        public Task HandleKeyDown(KeyboardEventArgs e)
        {
            if (e.Key == "Enter" && e.CtrlKey)
                return HandleAsk();

            return Task.CompletedTask;
        }
    }
}
