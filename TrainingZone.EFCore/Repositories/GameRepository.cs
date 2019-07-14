using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Add(Game game)
        {
            await _context.Games.AddAsync(game);
        }

        public Task<IEnumerable<Game>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<Game> GetById(string id)
        {
            return await _context.Games
                .Include(i => i.SecondPlayer)
                .Include(i => i.PlayedCoordinates)
                .FirstOrDefaultAsync(g => g.Id == new Guid(id));
        }

        public async Task<IEnumerable<Game>> GetByPlayerId(string playerId)
        {
            return await _context.Games
                .Where(g => g.FirstPlayerId == playerId)
                .ToListAsync();
        }

        public Task Remove(Game game)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Game game)
        {
            await Task.FromResult(_context.Games.Update(game));
        }

    }
}
