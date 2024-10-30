namespace WarehouseManager.WebHost.DTOs
{
	public class ProductDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Stock { get; set; }
		public decimal Price { get; set; }
		public bool IsInPurchaseQueue { get; set; }
	}
}
