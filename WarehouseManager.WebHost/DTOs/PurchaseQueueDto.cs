namespace WarehouseManager.WebHost.DTOs
{
	public class PurchaseQueueDto
	{
		public Guid Id { get; set; }
		public Guid ProductId { get; set; }
		public int Quantity { get; set; }
	}
}
