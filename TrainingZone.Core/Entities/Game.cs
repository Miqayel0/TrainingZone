using System;
using System.Collections.Generic;
using System.Text;
using TrainingZone.Core.Auth.Users;

namespace TrainingZone.Core.Entities
{
    public class Game
    {
        public Guid Id { get; set; }
        public User FirstPlayer { get; set; }
        public User SecondPlayer { get; set; }
        public int MatrixSize { get; set; } 
        public char FirstPlayerTurnType { get; set; }
        public char SecondPlayerTurnType { get; set; }
        public int? FirstPlayedPlayer { get; set; }
        public bool IsGameStarted { get; set; }
        public bool IsGameFinished { get; set; }
        public IEnumerable<Tuple<int, int>> PlayedCoordinates { get; set; }
        public IEnumerable<Tuple<int, int>> FirstPlayerCoordinates { get; set; }
        public IEnumerable<Tuple<int, int>> SecondPlayerCoordinates { get; set; }
    }
}
