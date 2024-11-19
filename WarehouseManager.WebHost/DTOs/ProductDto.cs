namespace WarehouseManager.WebHost.DTOs
{
	/// <summary>
	/// Represents a product in the warehouse.
	/// </summary>
	public class ProductDto
	{
		/// <summary>
		/// Gets or sets the unique identifier of the product.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the name of the product.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the quantity of the product in stock.
		/// </summary>
		public int Stock { get; set; }

		/// <summary>
		/// Gets or sets the price of the product.
		/// </summary>
		public decimal Price { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the product is in the purchase queue.
		/// </summary>
		public bool IsInPurchaseQueue { get; set; }
	}
}
