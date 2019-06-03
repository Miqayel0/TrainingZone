
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using TrainingZone.Core.Entities;

namespace TrainingZone.Core.Auth.Users
{
    public class User : IdentityUser
    {
        public User()
        {
            Score = new HashSet<Score>();
            Games = new HashSet<Game>();
            Steps = new HashSet<Point>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Victories { get; set; }

        public int Losses { get; set; }

        public int GamesCount { get; set; }

        public virtual ICollection<Score> Score { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Point> Steps { get; set; }
    }
}
