using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingZone.Core.Auth.Users;

namespace TrainingZone.Core.Repoitories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Create(string firstName, string lastName, string email, string userName, string password);
        Task<User> FindByName(string userName);
        Task<bool> CheckPassword(User user, string password);
    }
}
