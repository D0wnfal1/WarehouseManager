
namespace WarehouseManager.DataAccess.Repositories.IRepositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetAllWithItemsAsync();
		Task<Order> GetByIdWithItemsAsync(Guid id);
	}
}
