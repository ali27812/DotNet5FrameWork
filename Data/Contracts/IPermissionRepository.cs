using Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        Task<Permission> GetById(int id, CancellationToken cancellationToken);
    }
}
