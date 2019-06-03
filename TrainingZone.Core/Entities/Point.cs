using System;
using System.Collections.Generic;
using System.Text;
using TrainingZone.Core.Auth.Users;

namespace TrainingZone.Core.Entities
{
    public class Point
    {
        public Point()
        {
            Games = new HashSet<Game>();
        }

        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string PlayerId { get; set; }
        public User Player { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
