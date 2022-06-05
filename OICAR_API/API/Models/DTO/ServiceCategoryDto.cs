using Newtonsoft.Json;

namespace API.Dto
{
    public class ServiceCategoryDto
    {
        public ServiceCategoryDto()
        {
            ServiceSubcategories = new List<ServiceSubcategoryDto>();
        }
        [JsonProperty("category_id")]
        public int Id { get; set; }
        [JsonProperty("category_title")]
        public string Title { get; set; } = null!;
        [JsonProperty("subcategories")]
        public List<ServiceSubcategoryDto> ServiceSubcategories { get; set; }
    }
}
