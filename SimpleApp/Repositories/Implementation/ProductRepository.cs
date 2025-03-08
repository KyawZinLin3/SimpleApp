using Dapper;
using SimpleApp.Entities;
using SimpleApp.Persistence;
using SimpleApp.Repositories.Interface;

namespace SimpleApp.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext dapperContext;

        public ProductRepository(DapperContext dapperContext)
        {
            this.dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            using var connection = dapperContext.CreateConnection();
            connection.Open();
            return await connection.QueryAsync<Products>("SELECT * FROM Products");
        }

        public async Task<Products> GetProductById(int id)
        {
            var query = "SELECT * FROM Products WHERE Id = @Id";
            using var connection = dapperContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Products>(query,new { Id = id});
        }

        public async Task<int> AddProduct(ProductRepository product)
        {
            var query = "INSERT INTO Products (Name, Description, CreatedAt) VALUES (@Name, @Description, @CreatedAt)";
            using var connection = dapperContext.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(query, product);
        }

        public async Task<int> UpdateProduct(ProductRepository product)
        {
            var query = "UPDATE Products SET Name = @Name, Description = @Description, CreatedAt = @CreatedAt WHERE Id = @Id";
            using var connection = dapperContext.CreateConnection();
            return await connection.ExecuteAsync(query, product);
        }

        public async Task<int> DeleteProduct(int id)
        {
            var query = "DELETE FROM Products WHERE Id = @Id";
            using var connection = dapperContext.CreateConnection();
            return await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
