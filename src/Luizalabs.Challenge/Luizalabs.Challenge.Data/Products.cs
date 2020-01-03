using Luizalabs.Challenge.Core;
using Luizalabs.Challenge.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

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
            var query =
                "SELECT * FROM Products AS p " +
                "INNER JOIN Brands AS b ON b.id = p.brand_id " +
                "LEFT JOIN Reviews AS r ON r.product_id = p.id " +
                "LEFT JOIN Customers AS c ON r.customer_id = c.id " +
                "WHERE p.id = @id";

            using (var conn = new MySqlConnection(_connectionString))
            {
                var lookup = new Dictionary<long, Product>();
                var products = await conn.QueryAsync<Product, Brand, Review, Customer, Product>(query,
                    param: new { id },
                    map: (p, b, r, c) =>
                    {
                        if (!lookup.TryGetValue(p.Id, out Product product))
                            lookup.Add(p.Id, product = p);

                        product.AddReview(r, c);
                        product.Brand = b;
                        return product;
                    });

                return lookup.Select(x => x.Value).FirstOrDefault();
            }
        }

        public async Task Insert(Product product)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                var queryInsert = "INSERT INTO Products(title, price, image, reviewScore, brand_id, createdAt, updatedAt)" +
                    "VALUES (@Title, @Price, @Image, @ReviewScore, @BrandId, @CreatedAt, @UpdatedAt);SELECT LAST_INSERT_ID();";

                var model = new
                {
                    product.Title,
                    product.Price,
                    product.Image,
                    product.ReviewScore,
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
