using Newtonsoft.Json;

namespace API.Dto
{
    public class ClientDto
    {
        public ClientDto()
        {
            Offers = new List<OfferDto>();
            Reviews = new List<ReviewDto>();
        }
        [JsonProperty("client_id")]
        public int Id { get; set; }
        [JsonProperty("firstname")]
        public string FirstName { get; set; } = null!;
        [JsonProperty("lastname")]
        public string LastName { get; set; } = null!;
        [JsonProperty("contractor")]
        public bool IsContractor { get; set; }
        [JsonProperty("offers_count")]
        public int OffersCount { get; set; }
        [JsonProperty("reviews_count")]
        public int ReviewsCount { get; set; }
        [JsonProperty("average_grade")]
        public double AverageReviewGrade { get; set; }
        [JsonProperty("total_unread_messages")]
        public int? UnreadMessagesCount { get; set; }
        public List<OfferDto> Offers { get; set; }
        public List<ReviewDto> Reviews { get; set; }
    }
}
