using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Luizalabs.Challenge.Contracts.v1.Responses;
using Luizalabs.Challenge.Core;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Luizalabs.Challenge.Services.Products.Impl
{
    public class ProductPagination : IProductPagination
    {
        IConfiguration _configuration;
        private string _connectionString;

        public ProductPagination(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Pagination> Page(int page, int size)
        {
            var query =
                "SELECT * FROM Products AS p " +
                "INNER JOIN Brands as b ON b.id = p.brand_id " +
                "LIMIT @size OFFSET @offset";
            
            using (var conn = new MySqlConnection(_connectionString))
            {
                var products = await conn.QueryAsync<Product, Brand, Product>(query,
                    param: new { size, offset = ((page - 1) * size) },
                    map: (product, brand) => 
                    {
                        product.Brand = brand;
                        return product;
                    });

                var total = await conn.ExecuteScalarAsync<int>("SELECT Count(*) FROM Products");

                return new Pagination(products, page, size, total);
            }
        }
    }
}
