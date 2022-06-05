using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Client
    {
        public Client()
        {
            ChatConversationClientIdOneNavigations = new HashSet<ChatConversation>();
            ChatConversationClientIdTwoNavigations = new HashSet<ChatConversation>();
            ChatReplies = new HashSet<ChatReply>();
            Offers = new HashSet<Offer>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Passw { get; set; } = null!;
        public bool IsContractor { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public override string ToString() => $"{FirstName} {LastName}";
        public  ICollection<ChatConversation> ChatConversationClientIdOneNavigations { get; set; }
        public  ICollection<ChatConversation> ChatConversationClientIdTwoNavigations { get; set; }
        public  ICollection<ChatReply> ChatReplies { get; set; }
        public  ICollection<Offer> Offers { get; set; }
        public  ICollection<Review> Reviews { get; set; }
    }
}
