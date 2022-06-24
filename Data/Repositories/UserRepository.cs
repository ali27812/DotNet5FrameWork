using Common;
using Common.Exceptions;
using Common.Utilities;
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
    public class UserRepository : Repository<User>, IUserRepository, IScopedDependency
    {
        //seriLog
        private readonly ILogger<UserRepository> _log;
        //seriLog
        public UserRepository(ApplicationDbContext dbContext, ILogger<UserRepository> logger)
            : base(dbContext)
        {
            _log = logger;
        }
        //method for implement call view interface
        //public void GetStoreProce()
        //{
        //    var dfd = DbContext.vwUsers.ToList();
        //}



        public Task<User> GetByUserAndPass(string username, string password, CancellationToken cancellationToken)
        {            
            var passwordHash = SecurityHelper.GetSha256Hash(password);
            return Table.Where(p => p.UserName == username && p.PasswordHash == passwordHash).SingleOrDefaultAsync(cancellationToken);
        }

        public Task UpdateSecuirtyStampAsync(User user, CancellationToken cancellationToken)
        {
            user.SecurityStamp = Guid.NewGuid();
            return UpdateAsync(user, cancellationToken);
        }

        public Task UpdateLastLoginDateAsync(User user, CancellationToken cancellationToken)
        {
            user.LastLoginDate = DateTimeOffset.Now;
            return UpdateAsync(user, cancellationToken);
        }

        public async Task AddAsync(User user, string password, CancellationToken cancellationToken)
        {
            var exists = await TableNoTracking.AnyAsync(p => p.UserName == user.UserName);
            if (exists)
            {
               // _log.LogError("نام کاربری تکراری است");
                throw new AppException("نام کاربری تکراری است");
            }               
            var passwordHash = SecurityHelper.GetSha256Hash(password);
            user.PasswordHash = passwordHash;
            await base.AddAsync(user, cancellationToken);
        }
    }
}
