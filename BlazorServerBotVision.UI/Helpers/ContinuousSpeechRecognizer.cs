using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorServerBotVision.UI.Helpers
{  
    public class ContinuousSpeechRecognizer : IAsyncDisposable
    {
        readonly IJSRuntime _js;
        readonly DotNetObjectReference<ContinuousSpeechRecognizer> _ref;
        readonly string _lang;

        public event Func<string, bool, Task>? Recognized;
        public event Func<string, Task>? Error;

        public ContinuousSpeechRecognizer(IJSRuntime js, string language = "de-DE")
        {
            _js = js;
            _lang = language;
            _ref = DotNetObjectReference.Create(this);
        }

        public ValueTask StartAsync()
          => _js.InvokeVoidAsync("blazorSpeech.startContinuous", _lang, _ref);

        public ValueTask StopAsync()
          => _js.InvokeVoidAsync("blazorSpeech.stopContinuous");

        [JSInvokable]
        public Task NotifyRecognized(string text, bool isFinal)
          => Recognized?.Invoke(text, isFinal) ?? Task.CompletedTask;

        [JSInvokable]
        public Task NotifyError(string error)
          => Error?.Invoke(error) ?? Task.CompletedTask;

        public async ValueTask DisposeAsync()
        {
            await StopAsync();
            _ref.Dispose();
        }
    }

    public static class SpeechInteropExtensions
    {   
        public static ValueTask<string> RecognizeOnceAsync(
          this IJSRuntime js, string language = "de-DE")
        {
            return js.InvokeAsync<string>("blazorSpeech.recognizeOnce", language);
        }
   
        public static ValueTask SpeakAsync(
          this IJSRuntime js, string text, string language = "de-DE")
        {
            return js.InvokeVoidAsync("blazorSpeech.speakText", text, language);
        }
    }
}
