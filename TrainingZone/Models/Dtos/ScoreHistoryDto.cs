using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingZone.Models.Dtos
{
    public class ScoreHistoryDto
    {
        public string SecondPlayerName { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
    }
}
