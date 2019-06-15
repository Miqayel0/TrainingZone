using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingZone.Core.Dto;

namespace TrainingZone.Models.Response
{
    public class LoginResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public Token AccessToken { get; set; }
    }
}
