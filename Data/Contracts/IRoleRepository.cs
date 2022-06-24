using Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetById(int id, CancellationToken cancellationToken);
      
    }
}
