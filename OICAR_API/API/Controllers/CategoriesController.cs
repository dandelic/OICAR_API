using API.DAL.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoriesRepository _repository;

        public CategoriesController(ICategoriesRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        //CALLS

        //api/categories 
        //api/categories?title=gradevina
        //api/categories?id=1
        //api/categories?title=gradevina&id=1

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories(string? title, int? id)
        {
            try
            {
                var categories = await _repository.GetCategoriesByParametersAsync(title, id);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
