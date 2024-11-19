namespace WarehouseManager.WebHost.DTOs
{
	/// <summary>
	/// Represents an item within an order.
	/// </summary>
	public class OrderItemDto
	{
		/// <summary>
		/// Gets or sets the unique identifier of the order item.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the unique identifier of the product in the order.
		/// </summary>
		public int ProductId { get; set; }

		/// <summary>
		/// Gets or sets the quantity of the product ordered.
		/// </summary>
		public int Quantity { get; set; }
	}
}
	