using System.ComponentModel.DataAnnotations;

namespace WarehouseManager.DataAccess.Models
{
	public class OrderItem
	{
		public int Id { get; set; }

		[Required]
		public int OrderId { get; set; }

		[Required]
		public Order Order { get; set; }

		[Required]
		public int ProductId { get; set; }

		[Required]
		public Product Product { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
		public int Quantity { get; set; }
	}
}
