using API.DAL.Interfaces;
using API.Dto;
using API.Models;
using API.Models.DTO;
using API.Models.DTO.Add;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.Repositories
{
    public class OffersRepository : IOffersRepository
    {
        private readonly OicarDBContext _ctx;
        private readonly IMapper _mapper;

        public OffersRepository(OicarDBContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<int> CreateOfferAsync(OfferAddDto offerDto)
        {         
            var offer = _mapper.Map<Offer>(offerDto);
            await _ctx.Offers.AddAsync(offer);
            await _ctx.SaveChangesAsync();
            return offer.Id;
        }

        public async Task<int> DeleteOfferAsync(int id)
        {
            var offer = await _ctx.Offers.FirstAsync(u => u.Id == id);
            _ctx.Remove(_mapper.Map<Offer>(offer));
            return await _ctx.SaveChangesAsync();
        }
 
        public async Task<List<OfferDto>> GetOffersByParametersAsync(int? id, string? county, string? city, string? category_title, string? subcategory_title)
        {
            //IMPLEMENTIRAT       
            var offers = await _ctx.Offers.Include(o=>o.Client.Reviews)
               .Select(o => new OfferDto()
               {
                   Id = o.Id,
                   ClientId = o.Client.Id,
                   ClientName = o.Client.ToString(),
                   SubcategoryTitle = o.ServiceSubcategory.Title,
                   CategoryTitle = o.ServiceSubcategory.ServiceCategory.Title,
                   CityTitle = o.City.Title,
                   DatePublished = o.DatePublished,
                   Caption = o.Caption,
                   CountyTitle = o.City.County.Title,
                   AverageReviewGrade = o.Client.Reviews.Average(r => r.Grade) == null? 0 : o.Client.Reviews.Average(r => r.Grade)
               })
               .ToListAsync();

            if(id!=null)
            {
                offers = offers.Where(o => o.Id == id).ToList();
            }
            else if (county != null)
            {
                offers = offers.Where(o => o.CountyTitle == county).ToList();
            }
            else if (city != null)
            {
                offers = offers.Where(o => o.CityTitle == city).ToList();
            }
            else if (category_title != null)
            {
                offers = offers.Where(o => o.CategoryTitle == category_title).ToList();
            }
            else if (subcategory_title != null)
            {
                offers = offers.Where(o => o.SubcategoryTitle == subcategory_title).ToList();
            }
            return _mapper.Map<List<OfferDto>>(offers);
        }
     
    }
}
