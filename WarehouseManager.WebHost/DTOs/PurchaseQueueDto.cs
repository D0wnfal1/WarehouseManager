namespace WarehouseManager.WebHost.DTOs
{
	/// <summary>
	/// Represents an item in the purchase queue.
	/// </summary>
	public class PurchaseQueueDto
	{
		/// <summary>
		/// Gets or sets the unique identifier of the purchase queue item.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the unique identifier of the product to be purchased.
		/// </summary>
		public Guid ProductId { get; set; }

		/// <summary>
		/// Gets or sets the quantity of the product in the purchase queue.
		/// </summary>
		public int Quantity { get; set; }
	}
}
