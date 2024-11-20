
using WarehouseManager.DataAccess.Models;

namespace WarehouseManager.DataAccess.Repositories.IRepositories
{
    public interface IPurchaseQueueRepository : IRepository<PurchaseQueue>
    {
		Task<List<Product>> GetLowStockProductsAsync();

		Task<PurchaseQueue> GetPurchaseQueueByProductIdAsync(int productId);
	}
}
