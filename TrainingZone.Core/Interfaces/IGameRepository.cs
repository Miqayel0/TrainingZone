using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingZone.Core.Entities;

namespace TrainingZone.Core.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> Get();
        Task<Game> GetById(int id);
        Task<IEnumerable<Game>> GetByPlayerId(string playerId);
        Task Add(Game score);
        Task Remove(Game score);
        Task Update(Game score);
    }
}
