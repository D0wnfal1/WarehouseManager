﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager.DataAccess.Models
{
	public class Product
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Stock { get; set; }
		public decimal Price { get; set; }
		public bool IsInPurchaseQueue { get; set; }
	}
}