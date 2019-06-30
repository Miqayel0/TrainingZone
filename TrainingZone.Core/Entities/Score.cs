using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TrainingZone.Core.Auth.Users;
using TrainingZone.Core.Interfaces.Services;

namespace TrainingZone.Core.Entities
{
    public class Score : ITrackable
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string FirstPlayerId { get; set; }
        public string SecondPlayerId { get; set; }
        public Game Game { get; set; }
        public virtual User FirstPlayer { get; set; }
        public virtual User SecondPlayer { get; set; }
        /// <summary>
        /// The value can be (0 or 1). 0 - FirstPlayer(You), 1 - SecondPlayer or Computer.  
        /// </summary>
        public int? Winner { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
