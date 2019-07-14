using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingZone.Models.Dtos;

namespace TrainingZone.Models.Response
{
    public class ScoreResponse
    {

        public int GamesCount { get; set; }
        public int Victories { get; set; }
        public int Losses { get; set; }

        public IEnumerable<ScoreHistoryDto> ScoreHistory { get; set; }
    }
}
