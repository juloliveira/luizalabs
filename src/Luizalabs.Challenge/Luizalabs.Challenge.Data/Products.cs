using Luizalabs.Challenge.Core;
using Luizalabs.Challenge.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Dapper;
using System.Threading.Tasks;

namespace Luizalabs.Challenge.Data
{
    public class Products : IProducts
    {
        IConfiguration _configuration;
        private string _connectionString;

        public Products(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Product> GetById(long id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                return await conn.QuerySingleOrDefaultAsync<Product>(
                    "SELECT id, title, price, image, createdAt, updatedAt FROM Products WHERE id = @id",
                    new { id });
            }
        }

        public async Task Insert(Product product)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                var queryInsert = "INSERT INTO Products(title, price, image, brand_id, createdAt, updatedAt)" +
                    "VALUES (@Title, @Price, @Image, @BrandId, @CreatedAt, @UpdatedAt);SELECT LAST_INSERT_ID();";

                var model = new
                {
                    product.Title,
                    product.Price,
                    product.Image,
                    BrandId = product.Brand.Id,
                    product.CreatedAt,
                    product.UpdatedAt
                };

                var id = await conn.ExecuteScalarAsync<long>(queryInsert, model);
                product.Id = id;
            }
        }

        public async Task InsertReview(Product product, Review review)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                var queryInsert = "INSERT INTO Reviews(product_id, customer_id, score, comment, createdAt, updatedAt)" +
                    "VALUES (@ProductId, @CustomerId, @score, @comment, @CreatedAt, @UpdatedAt);SELECT LAST_INSERT_ID();";

                var model = new
                {
                    ProductId = product.Id,
                    CustomerId = review.Customer.Id,
                    review.Score,
                    review.Comment,
                    review.CreatedAt,
                    review.UpdatedAt
                };
                
                var id = await conn.ExecuteScalarAsync<long>(queryInsert, model);
                review.Id = id;

                await conn.ExecuteAsync(
                    "UPDATE Products " +
                    "SET reviewScore = (SELECT AVG(score) FROM Reviews WHERE product_id = @Id) " +
                    "WHERE id = @Id",
                    new { product.Id });
            }
        }
    }
}
