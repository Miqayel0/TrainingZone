using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrainingZone.Core.Repoitories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<List<T>> ListAll();
        Task<T> GetSingleBySpec(ISpecification<T> spec);
        Task<List<T>> List(ISpecification<T> spec);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
