using Newtonsoft.Json;

namespace API.Dto
{
    public class ClientAddDto
    {
  
        public string Username { get; set; } = null!;

        public string Passw { get; set; } = null!;

        public bool IsContractor { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
    }
}
