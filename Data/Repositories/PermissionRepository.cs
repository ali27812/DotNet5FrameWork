using Common;
using Data.Contracts;
using Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository, IScopedDependency
    {
        private readonly ILogger<PermissionRepository> _log;
        //seriLog
        public PermissionRepository(ApplicationDbContext dbContext, ILogger<PermissionRepository> logger)
            : base(dbContext)
        {
            _log = logger;
        }
        public Task<Permission> GetById(int id, CancellationToken cancellationToken)
        {
            return Table.Where(p => p.Id == id).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
