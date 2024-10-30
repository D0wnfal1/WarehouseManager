using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManager.DataAccess.Models;

namespace WarehouseManager.DataAccess.Repositories.IRepositories
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetItemsByOrderIdAsync(Guid orderId);
    }
}
