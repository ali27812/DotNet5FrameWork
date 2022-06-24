using Common;
using Common.Exceptions;
using Common.Utilities;
using Data.Contracts;
using Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class OrderRepository : Repository<Order>,IOrderRepository, IScopedDependency
    {
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task<Order> GetBySpecialCode(string specialCode, CancellationToken cancellationToken)
        {
            return Table.Where(p => p.SpecialCode == specialCode).SingleOrDefaultAsync(cancellationToken);
        }

        public Task<List<Order>> GetByOrderIdAsync(int orderId, CancellationToken cancellationToken)
        {
            return Table.Where(p => p.IdOrder == orderId).ToListAsync();
        }

        public async Task AddAsync(Order order, CancellationToken cancellationToken)
        {
            var exists = await TableNoTracking.AnyAsync(p => p.SpecialCode == order.SpecialCode);
            if (exists)
                throw new AppException("کد تراکنش (SpecialCode) تکراری است ");
            await base.AddAsync(order, cancellationToken);
        }
    }
}
