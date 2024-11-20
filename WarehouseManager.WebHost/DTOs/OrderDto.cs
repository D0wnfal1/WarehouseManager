namespace WarehouseManager.WebHost.DTOs
{
	/// <summary>
	/// Represents an order containing multiple items.
	/// </summary>
	public class OrderDto
	{
		/// <summary>
		/// Gets or sets the unique identifier of the order (optional for creation).
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the date when the order was created.
		/// </summary>
		public DateTime OrderDate { get; set; }

		/// <summary>
		/// Gets or sets the collection of items included in the order.
		/// </summary>
		public ICollection<OrderItemDto> Items { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the order is completed.
		/// </summary>
		public bool IsCompleted { get; set; }
	}
}
