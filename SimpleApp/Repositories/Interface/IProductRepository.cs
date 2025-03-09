using SimpleApp.Entities;
using SimpleApp.Repositories.Implementation;

namespace SimpleApp.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<int> AddProduct(Products product);
        Task<int> DeleteProduct(int id);
        Task<IEnumerable<Products>> GetAllProducts();
        Task<Products> GetProductById(int id);
        Task<int> UpdateProduct(Products product);
    }
}
