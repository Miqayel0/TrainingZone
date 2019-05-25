using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrainingZone.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task Complete();
    }
}
