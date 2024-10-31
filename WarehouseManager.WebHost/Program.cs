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
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	
}
app.UseSwagger();

app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "WarehouseManager API V1");
	c.RoutePrefix = string.Empty;
});
//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
