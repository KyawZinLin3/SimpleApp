using SimpleApp.Entities;
using SimpleApp.Repositories.Implementation;

namespace SimpleApp.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<int> AddProduct(ProductRepository product);
        Task<int> DeleteProduct(int id);
        Task<IEnumerable<Products>> GetAllProducts();
        Task<Products> GetProductById(int id);
        Task<int> UpdateProduct(ProductRepository product);
    }
}
