using API.Dto;

namespace API.DAL.Interfaces
{
    public interface ICategoriesRepository
    {     
        Task<List<ServiceCategoryDto>> GetCategoriesByParametersAsync(string? category_name,int? category_id);
    }
}
