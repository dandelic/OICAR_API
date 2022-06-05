using Newtonsoft.Json;

namespace API.Utility.JWT
{
    [Serializable]
    public class JwtAuthResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("client_id")]
        public int ClientID { get; set; }
        [JsonProperty("expires_in_min")]
        public int Expires_In { get; set; }


    }
}
