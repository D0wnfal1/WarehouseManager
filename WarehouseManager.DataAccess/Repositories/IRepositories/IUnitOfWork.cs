using WarehouseManager.DataAccess.Models;

namespace WarehouseManager.DataAccess.Repositories.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IOrderRepository Orders { get; }
        IRepository<OrderItem> OrderItems { get; }
        IPurchaseQueueRepository PurchaseQueues { get; }
        Task<int> SaveChangesAsync();
    }
}
