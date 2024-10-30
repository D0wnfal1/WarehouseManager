using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager.DataAccess.Models
{
	public class Order
	{
		public Guid Id { get; set; }
		public DateTime OrderDate { get; set; }
		public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
		public bool IsCompleted { get; set; }
	}
}
