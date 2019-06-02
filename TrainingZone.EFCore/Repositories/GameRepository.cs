using System;
using System.Collections.Generic;
using System.Text;
using TrainingZone.Core.Interfaces;

namespace TrainingZone.EFCore.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;

        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }


    }
}
