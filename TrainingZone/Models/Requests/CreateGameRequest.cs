using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingZone.Models.Requests
{
    public class CreateGameRequest
    {
        public string FirstPlayerId { get; set; }
        public int MatrixSize { get; set; }
        public char FirstPlayerTurnType { get; set; }
        public char SecondPlayerTurnType { get; set; }
        public int? FirstPlayedPlayer { get; set; }
    }
}
