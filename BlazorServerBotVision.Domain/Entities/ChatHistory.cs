using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerBotVision.Domain.Entities
{
    public class ChatHistory
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime LastModified { get; set; } = DateTime.UtcNow;
        public string Prompt { get; set; } = string.Empty;
        public string AIResponse { get; set; } = string.Empty;
        public string DBResponse { get; set; } = string.Empty;
    }
}
