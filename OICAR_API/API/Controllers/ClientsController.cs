using API.Dto;
using API.DAL.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClientsRepository _repository;

        public ClientsController(IMapper mapper, IClientsRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        //api/clients?client_id=1
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetClient(int client_id)
        {
            try
            {
                return Ok(await _repository.GetClientAsync(client_id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        //api/clients/add
        [Authorize]
        [HttpPut("add")]
        public async Task<IActionResult> AddClient([FromBody] ClientAddDto client)
        {
            try
            {
                return Ok(await _repository.CreateClientAsync(client));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //api/clients/delete?client_id=1
        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteClient(int client_id)
        {
            try
            {
                return Ok(await _repository.DeleteClientAsync(client_id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        //api/clients/chats?client_id=1
        [Authorize]
        [HttpGet("chats")]
        public async Task<IActionResult> GetClientChatConversations(int client_id)
        {
            try
            {
                var chats = await _repository.GetClientChatsAsync(client_id);
                return Ok(chats);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        //api/clients/login      
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] ClientAuthorizationModel cad)
        {
            try
            {
                var response = await _repository.AuthorizeClient(cad.Username, cad.Password);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
