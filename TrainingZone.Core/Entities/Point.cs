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
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        /// <summary>
        /// Value can be 1 or 2 (X, O)
        /// </summary>
        public int Value { get; set; }
        public string PlayerId { get; set; }
        public User Player { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
