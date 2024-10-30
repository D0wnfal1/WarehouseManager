
namespace WarehouseManager.DataAccess.Models
{
	public class PurchaseQueue
	{
		public Guid Id { get; set; }
		public Guid ProductId { get; set; }
		public Product Product { get; set; }
		public int Quantity { get; set; }
	}
}
