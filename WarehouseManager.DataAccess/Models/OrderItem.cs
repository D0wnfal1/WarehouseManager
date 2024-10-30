﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager.DataAccess.Models
{
	public class OrderItem
	{
		public Guid Id { get; set; }
		public Guid OrderId { get; set; }
		public Order Order { get; set; }
		public Guid ProductId { get; set; }
		public Product Product { get; set; }
		public int Quantity { get; set; }
	}
}