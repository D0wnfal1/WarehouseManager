using System.ComponentModel.DataAnnotations;

namespace WarehouseManager.DataAccess.Models
{
	public class PurchaseQueue
	{
		public Guid Id { get; set; }

		[Required]
		public Guid ProductId { get; set; }

		[Required]
		public Product Product { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
		public int Quantity { get; set; }
	}
}
