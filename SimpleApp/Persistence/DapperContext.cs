using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace SimpleApp.Persistence
{
    public class DapperContext
    {
        private readonly string _masterConnectionString;
        private readonly string _databaseConnectionString;
        private readonly string _databaseName;

        public DapperContext(IConfiguration configuration)
        {
            _masterConnectionString = configuration.GetConnectionString("DefaultConnection")!;
            _databaseName = configuration["DatabaseName"]!;
            _databaseConnectionString = configuration.GetConnectionString("DatabaseConnection")!;
        }
        public IDbConnection CreateConnection() => new SqlConnection(_databaseConnectionString);

        public async Task Init()
        {
            await _initDatabase();
            await _initTables();
        }

        private async Task _initDatabase()
        {
            // create database if not exists
            using var connection = new SqlConnection(_masterConnectionString);
            var sql = $@"
                      IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = '{_databaseName}')
                           CREATE DATABASE [{_databaseName}];
                      ";
            await connection.ExecuteAsync(sql);
        }

        private async Task _initTables()
        {
            // create tables if not exists
            using var connection = CreateConnection();
             connection.Open();
            await _initProducts();

            async Task _initProducts()
            {

                var sql = @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Products')
                CREATE TABLE Products (
                    Id INT PRIMARY KEY IDENTITY(1,1),
                    Name NVARCHAR(100) NOT NULL,
                    Description NVARCHAR(MAX) NOT NULL,
                    CreatedAt DATETIME2(7) NOT NULL
                );
            ";
                await connection.ExecuteAsync(sql);
            }
        }
    }

}
