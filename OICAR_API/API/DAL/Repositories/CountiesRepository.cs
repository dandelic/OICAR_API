using API.DAL.Interfaces;
using API.Dto;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.Repositories
{
    public class CountiesRepository:ICountiesRepository
    {
        private readonly OicarDBContext _ctx;
        private readonly IMapper _mapper;

        public CountiesRepository(OicarDBContext ctx ,IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<List<CountyDto>> GetCountiesByParametersAsync(int? county_id, string? title)
        {
            var counties = await _ctx.Counties.Include(c => c.Cities).ToListAsync();          
            
            if(title!=null)
            {
                counties = counties.Where(c=>c.Title==title).ToList();
            }
            else if (county_id != null)
            {
                counties = counties.Where(c => c.Id == county_id).ToList();
            }

            return _mapper.Map<List<CountyDto>>(counties);
        }
    }
}
