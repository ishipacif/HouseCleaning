using Microsoft.AspNetCore.Identity;

namespace HouseCleanersApi.Models
{
    public class User : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string token { get; set; }
    }
}