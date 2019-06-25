using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingZone.Models.Response
{
    public class UserResponse
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string FullNameShorthand => $"{FirstName.ToUpper()[0]}{LastName.ToUpper()[0]}";
    }
}
