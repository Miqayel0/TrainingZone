using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TrainingZone.Models.Dtos;

namespace TrainingZone.Models.Response
{
    public class GameResponse
    {
        public string Id { get; set; }
        public string FirstPlayerId { get; set; }
        public string SecondPlayerId { get; set; }
        public int MatrixSize { get; set; }
        public int FirstPlayerTurn { get; set; }
        public int SecondPlayerTurn { get; set; }
        public bool IsGameStarted { get; set; }
        public bool IsGameFinished { get; set; }
        public ICollection<MoveDto> Moves { get; set; }
    }
}
