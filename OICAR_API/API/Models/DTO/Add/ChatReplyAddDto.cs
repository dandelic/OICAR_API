using Newtonsoft.Json;

namespace API.Models.DTO
{
    public class ChatReplyAddDto
    {
        public string? Caption { get; set; }
        public int ChatId { get; set; }

        public int SenderId { get; set; }

    }
}
