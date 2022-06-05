using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class ChatConversation
    {
        public ChatConversation()
        {
            ChatReplies = new HashSet<ChatReply>();
        }

        public int Id { get; set; }
        public int ClientIdOne { get; set; }
        public int ClientIdTwo { get; set; }
        public DateTime? DateCreated { get; set; }

        public  Client ClientIdOneNavigation { get; set; } = null!;
        public  Client ClientIdTwoNavigation { get; set; } = null!;
        public  ICollection<ChatReply> ChatReplies { get; set; }
    }
}
