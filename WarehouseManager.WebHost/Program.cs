using Microsoft.EntityFrameworkCore;
using WarehouseManager.DataAccess;
using WarehouseManager.DataAccess.EfRepository;
using WarehouseManager.DataAccess.Repositories.IRepositories;
using System.Reflection;
using WarehouseManager.BusinessLogic.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Database
builder.Services.AddDbContext<WarehouseDbContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString("WareHouseManagerDb"));
});

// Dependency Injection for Services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPurchaseQueueService, PurchaseQueueService>();

// Configure Swagger with XML comments
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
	options.IncludeXmlComments(xmlPath);
	options.SwaggerDoc("v1", new() { Title = "Warehouse Manager API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
	options.AddPolicy("ClientApp", builder =>
	{
		builder.WithOrigins("http://localhost:4200")
		.AllowAnyMethod()
		.AllowAnyHeader();
	});
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<WarehouseDbContext>();
	if (context.Database.CanConnect())
	{
		context.Database.EnsureDeleted();
	}
	context.Database.EnsureCreated();

    context.SaveChanges();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	
}
app.UseSwagger();

app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "WarehouseManager API V1");
});
//app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors("ClientApp");

app.MapControllers();

app.Run();
