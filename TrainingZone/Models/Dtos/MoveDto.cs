using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingZone.Models.Dtos
{
    public class MoveDto
    {
        /// <summary>
        /// The values can be 1 or 2
        /// </summary>
        public int Player { get; set; }

        public int Row { get; set; }

        public int column { get; set; }
    }
}
