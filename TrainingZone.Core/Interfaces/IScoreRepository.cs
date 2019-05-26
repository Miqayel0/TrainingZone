using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingZone.Core.Entities;

namespace TrainingZone.Core.Interfaces
{
    public interface IScoreRepository
    {
        Task<IEnumerable<Score>> Get();
        Task<Score> GetById(int id);
        Task<IEnumerable<Score>> GetByPlayerId(string playerId);
        Task Add(Score score);
        Task Remove(Score score);
    }
}
