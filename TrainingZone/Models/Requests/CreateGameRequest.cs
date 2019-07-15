using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingZone.Models.Requests
{
    public class CreateGameRequest
    {
        public int MatrixSize { get; set; }
        public int FirstPlayerTurn { get; set; }
        public int SecondPlayerTurn { get; set; }
    }
}
