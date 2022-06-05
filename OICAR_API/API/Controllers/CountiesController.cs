using API.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountiesController : ControllerBase
    {
        private readonly ICountiesRepository _repository;

        public CountiesController(ICountiesRepository repository)
        {
            _repository = repository;
        }
     
        //api/counties
        //api/counties?id=1
        //api/counties?title=zagrebacka
        //api/counties?title=zagrebacka&id=2
        
        [HttpGet]
        public async Task<IActionResult> GetCounties(int? county_id,string? county_title)
        {
            try
            {             
                var cities = await _repository.GetCountiesByParametersAsync(county_id, county_title);
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
