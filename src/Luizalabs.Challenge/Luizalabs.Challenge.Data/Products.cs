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
    }
}
