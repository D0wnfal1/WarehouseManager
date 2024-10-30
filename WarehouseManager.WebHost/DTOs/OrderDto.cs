namespace WarehouseManager.WebHost.DTOs
{
	public class OrderDto
	{
		public Guid Id { get; set; }
		public DateTime OrderDate { get; set; }
		public ICollection<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
		public bool IsCompleted { get; set; }
	}
}
