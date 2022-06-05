using API.DAL.Interfaces;
using API.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IChatsRepository _repository;

        public ChatController(IChatsRepository repository, IMapper mapper)
        {
                _mapper = mapper;
            _repository = repository;   
        }

        //api/chat?chat_id=1
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetConversationChatReplies(int chat_id)
        {
            try
            {
                var chats =  await _repository.GetChatRepliesAsync(chat_id);
                return Ok(chats);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        //api/chat/create
        [Authorize]
        [HttpPut("create")]
        public async Task<IActionResult> CreateChatConversation([FromBody] ChatConversationAddDto client)
        {
            try
            {
                return Ok(await _repository.CreateChatConversationAsync(client));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //api/chat/reply/add
        [Authorize]
        [HttpPut("reply/add")]
        public async Task<IActionResult> AddChatReply([FromBody] ChatReplyAddDto chatreply)
        {
            try
            {
                return Ok(await _repository.AddChatReplyAsync(chatreply));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //api/chat/delete?chat_id=10
        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteChatConversation(int chat_id)
        {
            try
            {
                return Ok(await _repository.DeleteChatConversationAsync(chat_id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        //api/Chat/read?client_id=1&chat_id=1
        [Authorize]
        [HttpPost("read")]
        public async Task<IActionResult>ReadClientChatMessages(int client_id, int chat_id){
            try
            {
                return Ok(await _repository.ReadClientChatMessagesAsync(client_id,chat_id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
