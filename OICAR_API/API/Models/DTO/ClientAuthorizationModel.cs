using Newtonsoft.Json;

namespace API.Dto
{
    public class ClientAuthorizationModel
    {
        public ClientAuthorizationModel(string username,string password)
        {
            Username = username;
            Password = password;
        }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
