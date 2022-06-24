using Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        //interface for call view
        //void GetStoreProce();
        Task<User> GetByUserAndPass(string username, string password, CancellationToken cancellationToken);

        Task AddAsync(User user, string password, CancellationToken cancellationToken);

        Task UpdateSecuirtyStampAsync(User user, CancellationToken cancellationToken);


    }
}
