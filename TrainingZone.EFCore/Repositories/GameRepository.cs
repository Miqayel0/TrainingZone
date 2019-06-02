using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingZone.Core.Entities;
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

        public Task Add(Game game)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Game>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Game> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Game>> GetByPlayerId(string playerId)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Game score)
        {
            throw new NotImplementedException();
        }

        public Task Update(Game score)
        {
            throw new NotImplementedException();
        }
    }
}
