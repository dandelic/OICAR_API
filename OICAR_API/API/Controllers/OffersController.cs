using API.DAL.Interfaces;
using API.Dto;
using API.Models;
using API.Models.DTO;
using API.Models.DTO.Add;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOffersRepository _repository;
        private readonly IMapper _mapper;
        public OffersController(IMapper mapper, IOffersRepository repository)
        {
            _repository=repository;
            _mapper=mapper;
        }

        //api/offers/delete/1
        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteOffer(int offer_id)
        {
            try
            {
                return Ok(await _repository.DeleteOfferAsync(offer_id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        //api/offers/add
        [Authorize]
        [HttpPut("add")]
        public async Task<IActionResult> AddOffer([FromQuery] OfferAddDto offer)
        {
            try
            {              
                return Ok(await _repository.CreateOfferAsync(offer));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //api/offers
        //api/offers?county=zagrebacka
        //api/offers?county=zagrebacka&subcategory=krovista
        //api/offers?county=zagrebacka&city=zagreb&subcategory=krovista
        //....
        [Authorize]
        [HttpGet]
        public async Task<IActionResult>GetOffers(string? county_title,string? city_title, string? category_title, string? subcategory_title, int? offer_id)
        {
            try
            {                  
                var offers = await _repository.GetOffersByParametersAsync(offer_id, county_title, city_title, category_title, subcategory_title);
                return Ok(offers);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
       
    }
}
