using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingZone.Core.Entities
{
    public class GameOptions
    {
        public Guid Id { get; set; }
        public int MatrixSize { get; set; }
        public char TurnType { get; set; }
        public IEnumerable<Tuple<int, int>> PlayedCoordinates { get; set; }
    }
}
