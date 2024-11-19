using System.ComponentModel.DataAnnotations;

namespace WarehouseManager.DataAccess.Models
{
	public class Product
	{
		public int Id { get; set; }

		[Required]
		[StringLength(100, MinimumLength = 1, ErrorMessage = "Product name must be between 1 and 100 characters.")]
		public string Name { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "Stock must be 0 or greater.")]
		public int Stock { get; set; }

		[Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
		public decimal Price { get; set; }

		public bool IsInPurchaseQueue { get; set; }
	}
}
