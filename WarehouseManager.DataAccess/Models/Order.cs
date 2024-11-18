using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WarehouseManager.DataAccess.Models;

public class Order
{
	public Guid Id { get; set; }

	private DateTime _orderDate;

	[Required]
	[JsonPropertyName("order_date")]
	public DateTime OrderDate
	{
		get => _orderDate;
		set
		{
			if (value > DateTime.UtcNow)
				throw new ArgumentException("Order date cannot be in the future.");
			_orderDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
		}
	}

	[Required]
	public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

	public bool IsCompleted { get; set; }
}
