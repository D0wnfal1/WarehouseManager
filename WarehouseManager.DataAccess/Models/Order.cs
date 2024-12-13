﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WarehouseManager.DataAccess.Models;

public class Order
{
	[Key]
	public int Id { get; set; }

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

	public ICollection<OrderItem> Items { get; set; }

	public bool IsCompleted { get; set; }
}
