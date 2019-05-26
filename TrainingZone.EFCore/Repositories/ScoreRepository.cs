using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Add(Score score)
        {
            await _context.Scores.AddAsync(score);
        }

        public async Task<IEnumerable<Score>> Get()
        {
            return await _context.Scores.ToListAsync();
        }

        public Task<Score> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Score>> GetByPlayerId(string playerId)
        {
            return await _context.Scores
                .Where(s => s.FirstPlayerId == playerId)
                .Include(s => s.SecondPlayer)
                .ToListAsync();
        }

        public Task Remove(Score score)
        {
            throw new NotImplementedException();
        }
    }
}
