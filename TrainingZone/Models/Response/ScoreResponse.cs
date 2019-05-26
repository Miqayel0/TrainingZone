using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingZone.Models.Response
{
    public class ScoreResponse
    {

        public int GamesCount { get; set; }
        public int Victories { get; set; }
        public int Loses { get; set; }

        public IEnumerable<ScoreHistory> ScoreHistory { get; set; }
    }
}
