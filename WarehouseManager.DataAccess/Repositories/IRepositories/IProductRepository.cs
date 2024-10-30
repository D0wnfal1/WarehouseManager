using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManager.DataAccess.Models;

namespace WarehouseManager.DataAccess.Repositories.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllAvailableProductsAsync();
    }
}
