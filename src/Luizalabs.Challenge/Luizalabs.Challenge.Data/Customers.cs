using System.Collections.Generic;
using Luizalabs.Challenge.Core;
using Luizalabs.Challenge.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Dapper;
using System.Threading.Tasks;

namespace Luizalabs.Challenge.Data
{
    public class Customers : ICustomers
    {
        IConfiguration _configuration;
        private string _connectionString;

        public Customers(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> ExistsEmail(string email)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                return await conn.QuerySingleAsync<int>(
                    "SELECT COUNT(id) FROM Customers WHERE email = @email",
                    new { email }) >= 1;
            }
        }

        public async Task<IEnumerable<Customer>> GetAllPerPage(int page)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                return await conn.QueryAsync<Customer>("SELECT id, name, createdAt, updatedAt FROM Customers");
            }
        }

        public async Task<Customer> GetById(long id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                var customer = await conn.QuerySingleOrDefaultAsync<Customer>(
                    "SELECT id, name, email, address, createdAt, updatedAt FROM Customers WHERE id = @id", 
                    new { id });

                var favorities = await conn.QueryAsync<Product>(
                    "SELECT id, title FROM Products " +
                    "INNER JOIN Customers_FavoritiesProducts ON Products.id = Customers_FavoritiesProducts.product_id " +
                    "WHERE customer_id = @id", new { id });

                customer.SetFavoritiesProducts(favorities);

                return customer;
            }
        }

        public async Task Insert(Customer customer)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                var queryInsert = "INSERT INTO Customers(name, address, email, createdAt, updatedAt)" +
                    "VALUES (@Name, @Address, @Email, @CreatedAt, @UpdatedAt);SELECT LAST_INSERT_ID();";

                var id = await conn.ExecuteScalarAsync<long>(queryInsert, customer);
                customer.Id = id;
            }
        }
        public async Task Update(Customer customer)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                customer.Update();
                var queryUpdate = "UPDATE Customers SET name = @Name, address = @Address, updatedAt = @UpdatedAt WHERE id = @Id";

                await conn.ExecuteAsync(queryUpdate, customer);
            }
        }

        public async Task RemoveById(long id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.ExecuteAsync("DELETE FROM Customers WHERE id = @id", new { id });
            }
        }

        public async Task IncludeFavorite(Customer customer, Product product)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                var queryInsert = 
                    "INSERT INTO Customers_FavoritiesProducts (customer_id, product_id) " +
                    "VALUES (@CustomerId, @ProductId);";

                var model = new
                {
                    CustomerId = customer.Id,
                    ProductId = product.Id
                };

                await conn.ExecuteScalarAsync<long>(queryInsert, model);
            }
        }
    }
}
