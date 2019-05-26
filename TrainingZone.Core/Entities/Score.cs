using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TrainingZone.Core.Auth.Users;

namespace TrainingZone.Core.Entities
{
    public class Score
    {
        public int Id { get; set; }
        public string FirstPlayerId { get; set; }
        public string SecondPlayerId { get; set; }

        public virtual User FirstPlayer { get; set; }

        public virtual User SecondPlayer { get; set; }

        /// <summary>
        /// The value can be (0 or 1). 0 - FirstPlayer(You), 1 - SecondPlayer or Computer.  
        /// </summary>
        public int? Winner { get; set; }
    }
}
