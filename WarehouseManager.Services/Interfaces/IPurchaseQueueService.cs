using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManager.DataAccess.Models;

namespace WarehouseManager.BusinessLogic.Services
{
	public interface IPurchaseQueueService
	{
		Task<IEnumerable<PurchaseQueue>> GetAllPurchaseQueuesAsync();
		Task<PurchaseQueue> GetPurchaseQueueByIdAsync(int id);
		Task AddToPurchaseQueueAsync(PurchaseQueue purchaseQueue);
		Task RemoveFromPurchaseQueueAsync(int id);
	}
}
