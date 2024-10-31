using WarehouseManager.DataAccess.Models;
using WarehouseManager.DataAccess.Repositories.IRepositories;

namespace WarehouseManager.BusinessLogic.Services
{
    public class PurchaseQueueService : IPurchaseQueueService
	{
		private readonly IUnitOfWork _unitOfWork;

		public PurchaseQueueService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<PurchaseQueue>> GetAllPurchaseQueuesAsync()
		{
			return await _unitOfWork.PurchaseQueues.GetAllAsync();
		}

		public async Task<PurchaseQueue> GetPurchaseQueueByIdAsync(Guid id)
		{
			return await _unitOfWork.PurchaseQueues.GetByIdAsync(id);
		}

		public async Task AddToPurchaseQueueAsync(PurchaseQueue purchaseQueue)
		{
			await _unitOfWork.PurchaseQueues.AddAsync(purchaseQueue);
		}

		public async Task RemoveFromPurchaseQueueAsync(Guid id)
		{
			var purchaseQueue = await _unitOfWork.PurchaseQueues.GetByIdAsync(id);
			if (purchaseQueue != null)
			{
				await _unitOfWork.PurchaseQueues.DeleteAsync(purchaseQueue);
			}
		}
	}
}
