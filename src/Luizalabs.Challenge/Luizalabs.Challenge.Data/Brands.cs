using Luizalabs.Challenge.Core;
using Luizalabs.Challenge.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Dapper;
using System.Threading.Tasks;

namespace Luizalabs.Challenge.Data
{
    public class Brands : IBrands
    {
        IConfiguration _configuration;
        private string _connectionString;

        public Brands(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Brand> GetById(long id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                return await conn.QuerySingleOrDefaultAsync<Brand>(
                    "SELECT id, name, createdAt, updatedAt FROM Brands WHERE id = @id",
                    new { id });

            }
        }

        public async Task Insert(Brand brand)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                var queryInsert = "INSERT INTO Brands(name, createdAt, updatedAt)" +
                    "VALUES (@Name, @CreatedAt, @UpdatedAt);SELECT LAST_INSERT_ID();";

                var id = await conn.ExecuteScalarAsync<long>(queryInsert, brand);
                brand.Id = id;
            }
        }
    }
}
