using System;
using System.Collections.Generic;
using System.Text;
using TrainingZone.Core.Auth.Users;

namespace TrainingZone.Core.Entities
{
    public class Game
    {
        public Game()
        {
            PlayedCoordinates = new HashSet<Point>();
        }

        public Guid Id { get; set; }
        public int? ScoreId { get; set; }
        public string FirstPlayerId { get; set; }
        public string SecondPlayerId { get; set; }
        public virtual Score Score { get; set; }
        public virtual User FirstPlayer { get; set; }
        public virtual User SecondPlayer { get; set; }
        public int MatrixSize { get; set; }
        public char FirstPlayerTurnType { get; set; }
        public char SecondPlayerTurnType { get; set; }
        public int? WhoIsStarts { get; set; }
        public bool IsGameStarted { get; set; }
        public bool IsGameFinished { get; set; }
        public virtual ICollection<Point> PlayedCoordinates { get; set; }
    }
}
