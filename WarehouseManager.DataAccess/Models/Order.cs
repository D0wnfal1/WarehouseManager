using WarehouseManager.DataAccess.Models;

public class Order
{
	public Guid Id { get; set; }

	private DateTime _orderDate;

	public DateTime OrderDate
	{
		get => _orderDate;
		set => _orderDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
	}

	public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
	public bool IsCompleted { get; set; }
}
