
using Microsoft.AspNetCore.Identity;

namespace TrainingZone.Core.Auth.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
