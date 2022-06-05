using Newtonsoft.Json;

namespace API.Dto
{
    public class ServiceSubcategoryDto
    {
        [JsonProperty("subcategory_id")]
        public int Id { get; set; }
        [JsonProperty("subcategory_title")]
        public string Title { get; set; } = null!;
    }
}
