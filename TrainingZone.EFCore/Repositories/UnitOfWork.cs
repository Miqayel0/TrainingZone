using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingZone.Core.Interfaces;

namespace TrainingZone.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Complete()
        {
            await Task.FromResult(_context.SaveChanges());
        }
    }
}
