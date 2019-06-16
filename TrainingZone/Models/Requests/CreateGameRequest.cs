using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingZone.Models.Requests
{
    public class CreateGameRequest
    {
        public int MatrixSize { get; set; }
        public char FirstPlayerTurnType { get; set; }
        public int? WhoIsStarts { get; set; }
    }
}
