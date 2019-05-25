using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingZone.Core.Entities;
using TrainingZone.Core.Interfaces;

namespace TrainingZone.EFCore.Repositories
{
    class ScoreRepository : IScoreRepository
    {
        private readonly ApplicationDbContext _context;

        public ScoreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Add(Score score)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Score>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Score> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Score>> GetByPlayerId(int playerId)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Score score)
        {
            throw new NotImplementedException();
        }
    }
}
