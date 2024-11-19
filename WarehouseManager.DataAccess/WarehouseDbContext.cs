using Microsoft.EntityFrameworkCore;
using WarehouseManager.DataAccess.Models;

namespace WarehouseManager.DataAccess
{
	public class WarehouseDbContext : DbContext
	{
		public WarehouseDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<PurchaseQueue> PurchaseQueues { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<OrderItem>()
				.HasKey(oi => oi.Id);

			modelBuilder.Entity<OrderItem>()
				.HasOne(oi => oi.Order)
				.WithMany(o => o.Items)
				.HasForeignKey(oi => oi.OrderId);

			modelBuilder.Entity<OrderItem>()
				.HasOne(oi => oi.Product)
				.WithMany()
				.HasForeignKey(oi => oi.ProductId);

			modelBuilder.Entity<Product>().HasData(
				new Product
				{
					Id = 1,
					Name = "Laptop",
					Stock = 10,
					Price = 999.99m,
					IsInPurchaseQueue = false
				},
				new Product
				{
					Id = 2,
					Name = "Smartphone",
					Stock = 5,
					Price = 699.99m,
					IsInPurchaseQueue = true
				},
				new Product
				{
					Id = 3,
					Name = "Headphones",
					Stock = 0,
					Price = 199.99m,
					IsInPurchaseQueue = true
				}
			);

			modelBuilder.Entity<Order>().HasData(
				new Order
				{
					Id = 1,
					OrderDate = new DateTime(2024, 11, 16),
					IsCompleted = false
				},
				new Order
				{
					Id = 2,
					OrderDate = new DateTime(2024, 11, 18),
					IsCompleted = true
				}
			);

			modelBuilder.Entity<OrderItem>().HasData(
				new OrderItem
				{
					Id = 1,
					OrderId = 1,
					ProductId = 1,
					Quantity = 2
				},
				new OrderItem
				{
					Id = 2,
					OrderId = 1,
					ProductId = 2,
					Quantity = 1
				},
				new OrderItem
				{
					Id = 3,
					OrderId = 2,
					ProductId = 3,
					Quantity = 3
				}
			);

			modelBuilder.Entity<PurchaseQueue>().HasData(
				new PurchaseQueue
				{
					Id = 1,
					ProductId = 3,
					Quantity = 10
				}
			);
		}
	}
}
