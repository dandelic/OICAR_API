using Newtonsoft.Json;

namespace API.Dto
{
    public class OfferDto
    {
        [JsonProperty("offer_id")]
        public int Id { get; set; }
        [JsonProperty("client_id")]
        public int ClientId { get; set; }
        [JsonProperty("client_name")]
        public string? ClientName { get; set; }
        [JsonProperty("category")]
        public string? CategoryTitle { get; set; }
        [JsonProperty("subcategory_title")]
        public string? SubcategoryTitle { get; set; }
        [JsonProperty("county_title")]
        public string? CountyTitle { get; set; }
        [JsonProperty("city_title")]
        public string? CityTitle { get; set; }
        [JsonProperty("date")]
        public DateTime? DatePublished { get; set; }
        [JsonProperty("caption")]
        public string? Caption { get; set; }
       
        [JsonProperty("client_average_grade")]
        public double? AverageReviewGrade { get; set; }
    }
}
