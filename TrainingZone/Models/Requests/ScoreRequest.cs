using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingZone.Models.Requests
{
    public class ScoreRequest
    {
        public string FirstPlayerId { get; set; }
        public string SecondPlayerId { get; set; }
        public int? Winner { get; set; }
    }
}
