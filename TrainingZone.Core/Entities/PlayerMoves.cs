using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingZone.Core.Entities
{
    public class PlayerMoves
    {
        public int Id { get; set; }
        /// <summary>
        /// X or 0
        /// </summary>
        public char TurnType { get; set; }
        public IEnumerable<Tuple<int, int>> Coordinates { get; set; }
    }
}
