using API.Dto;
using API.Models.DTO;
using API.Models.DTO.Add;

namespace API.DAL.Interfaces
{
    public interface IOffersRepository
    {   
        Task<List<OfferDto>> GetOffersByParametersAsync(int? offer_id, string? county_title,
            string? city_title, string? category_title, string? subcategory_title);

        Task<int> CreateOfferAsync(OfferAddDto offer);

        Task<int> DeleteOfferAsync(int id);
    }
}
