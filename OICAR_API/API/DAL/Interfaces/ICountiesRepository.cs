using API.Dto;
namespace API.DAL.Interfaces
{
    public interface ICountiesRepository
    {
        Task<List<CountyDto>>GetCountiesByParametersAsync(int? county_id, string? title);      
    }
}
