using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class ChatReply
    {
        public int Id { get; set; }
        public string? Caption { get; set; }
        public bool? IsRead { get; set; }
        public DateTime? DateSent { get; set; }
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public  ChatConversation Chat { get; set; } = null!;
        public  Client Sender { get; set; } = null!;
    }
}
