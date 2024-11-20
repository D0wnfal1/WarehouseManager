using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace WarehouseManager.Client
{

	class Program
	{
		private static readonly string baseUrl = "http://localhost:7067/api";


		static async Task Main(string[] args)
		{
			var client = new HttpClient();
			client.Timeout = TimeSpan.FromSeconds(30);
			try
			{
				client.BaseAddress = new Uri(baseUrl);
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				Console.WriteLine("Welcome to the Warehouse Manager API Client!");

				await GetOrdersAsync(client);
				await CreateOrderAsync(client);
				await GetProductsAsync(client);
				await CreateProductAsync(client);
				await GetPurchaseQueuesAsync(client);
				await AddToPurchaseQueueAsync(client);
			}
			finally
			{
				client.Dispose();
			}
		}

		private static async Task GetOrdersAsync(HttpClient client)
		{
			var response = await client.GetAsync("order");
			if (response.IsSuccessStatusCode)
			{
				var orders = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Orders retrieved:");
				Console.WriteLine(orders);
			}
			else
			{
				Console.WriteLine("Failed to retrieve orders.");
			}
		}

		private static async Task CreateOrderAsync(HttpClient client)
		{
			var newOrder = new
			{
				OrderDate = DateTime.Now,
				IsCompleted = false,
				Items = new[]
				{
				new { ProductId = 1, Quantity = 2 },
				new { ProductId = 2, Quantity = 3 }
			}
			};

			var jsonContent = new StringContent(JsonConvert.SerializeObject(newOrder), Encoding.UTF8, "application/json");
			var response = await client.PostAsync("order", jsonContent);

			if (response.IsSuccessStatusCode)
			{
				var order = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Order created:");
				Console.WriteLine(order);
			}
			else
			{
				Console.WriteLine("Failed to create order.");
			}
		}

		private static async Task GetProductsAsync(HttpClient client)
		{
			var response = await client.GetAsync("product");
			if (response.IsSuccessStatusCode)
			{
				var products = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Products retrieved:");
				Console.WriteLine(products);
			}
			else
			{
				Console.WriteLine("Failed to retrieve products.");
			}
		}

		private static async Task CreateProductAsync(HttpClient client)
		{
			var newProduct = new
			{
				Name = "Sample Product",
				Stock = 100,
				Price = 19.99,
				IsInPurchaseQueue = false
			};

			var jsonContent = new StringContent(JsonConvert.SerializeObject(newProduct), Encoding.UTF8, "application/json");
			var response = await client.PostAsync("product", jsonContent);

			if (response.IsSuccessStatusCode)
			{
				var product = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Product created:");
				Console.WriteLine(product);
			}
			else
			{
				Console.WriteLine("Failed to create product.");
			}
		}

		private static async Task GetPurchaseQueuesAsync(HttpClient client)
		{
			var response = await client.GetAsync("purchasequeue");
			if (response.IsSuccessStatusCode)
			{
				var purchaseQueues = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Purchase Queues retrieved:");
				Console.WriteLine(purchaseQueues);
			}
			else
			{
				Console.WriteLine("Failed to retrieve purchase queues.");
			}
		}

		private static async Task AddToPurchaseQueueAsync(HttpClient client)
		{
			var purchaseQueueItem = new
			{
				ProductId = 1, 
				Quantity = 10
			};

			var jsonContent = new StringContent(JsonConvert.SerializeObject(purchaseQueueItem), Encoding.UTF8, "application/json");
			var response = await client.PostAsync("purchasequeue", jsonContent);

			if (response.IsSuccessStatusCode)
			{
				var item = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Item added to purchase queue:");
				Console.WriteLine(item);
			}
			else
			{
				Console.WriteLine("Failed to add item to purchase queue.");
			}
		}
	}

}
