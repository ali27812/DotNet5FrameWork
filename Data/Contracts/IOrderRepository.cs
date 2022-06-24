using Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetBySpecialCode(string specialCode, CancellationToken cancellationToken);

        Task<List<Order>> GetByOrderIdAsync(int orderId, CancellationToken cancellationToken);

        Task AddAsync(Order order, CancellationToken cancellationToken);
    }
}
