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
    public class RoleRepository : Repository<Role>, IRoleRepository, IScopedDependency
    {
        private readonly ILogger<RoleRepository> _log;
        //seriLog
        public RoleRepository(ApplicationDbContext dbContext, ILogger<RoleRepository> logger)
            : base(dbContext)
        {
            _log = logger;
        }

        public Task<Role> GetById(int id, CancellationToken cancellationToken)
        {
            return Table.Where(p => p.Id == id).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
