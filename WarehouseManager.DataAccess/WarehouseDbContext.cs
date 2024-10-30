using Microsoft.EntityFrameworkCore;
using WarehouseManager.DataAccess.Models;

namespace WarehouseManager.DataAccess
{
	public class WarehouseDbContext : DbContext
	{
		public WarehouseDbContext(DbContextOptions options) : base(options)
		{

		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<PurchaseQueue> PurchaseQueues { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Product>().HasData(
				new Product
				{
					Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
					Name = "Laptop",
					Stock = 10,
					Price = 999.99m,
					IsInPurchaseQueue = false
				},
				new Product
				{
					Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
					Name = "Smartphone",
					Stock = 5,
					Price = 699.99m,
					IsInPurchaseQueue = true
				},
				new Product
				{
					Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
					Name = "Headphones",
					Stock = 0,
					Price = 199.99m,
					IsInPurchaseQueue = true
				}
			);

			modelBuilder.Entity<Order>().HasData(
				new Order
				{
					Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
					OrderDate = DateTime.Now.AddDays(-3),
					IsCompleted = false
				},
				new Order
				{
					Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
					OrderDate = DateTime.Now.AddDays(-1),
					IsCompleted = true
				}
			);

			modelBuilder.Entity<OrderItem>().HasData(
				new OrderItem
				{
					Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
					OrderId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
					ProductId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
					Quantity = 2
				},
				new OrderItem
				{
					Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
					OrderId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
					ProductId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
					Quantity = 1
				},
				new OrderItem
				{
					Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
					OrderId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
					ProductId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
					Quantity = 3
				}
			);

			modelBuilder.Entity<PurchaseQueue>().HasData(
				new PurchaseQueue
				{
					Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
					ProductId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
					Quantity = 10
				}
			);
		}
	}
}
