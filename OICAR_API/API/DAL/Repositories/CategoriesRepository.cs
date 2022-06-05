using API.DAL.Interfaces;
using API.Dto;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly OicarDBContext _ctx;
        private readonly IMapper _mapper;
        public CategoriesRepository(OicarDBContext ctx,IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }   
        public async Task<List<ServiceCategoryDto>> GetCategoriesByParametersAsync(string? category, int? id)
        {
            var categories = await _ctx.ServiceCategories.Include(e => e.ServiceSubcategories).ToListAsync();
            if(category != null)
            {         
                categories = categories.Where(c => c.Title.ToLower() == category.ToLower()).ToList();
                
            }
            else if(id != null)
            {
                categories = categories.Where(c => c.Id == id).ToList();
            }
            return _mapper.Map<List<ServiceCategoryDto>>(categories);
        }
    }
}
