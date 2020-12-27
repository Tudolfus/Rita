using Core.Interfaces.Products;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System.Collections.Generic;
using Core.Models.Products;
using Microsoft.Extensions.Options;
using Core.Models.Configuration;

namespace Database
{
    public class ProductsDB : IProductsDB
    {
        private readonly IOptions<ConnectionStringsModel> ConnectionStrings;

        public ProductsDB(IOptions<ConnectionStringsModel> connectionStrings)
        {
            ConnectionStrings = connectionStrings;
        }

        public async Task SaveProducts(List<Product> products)
        {
            using IDbConnection connection = new SqlConnection(ConnectionStrings.Value.Dev);

            await connection.ExecuteAsync("INSERT INTO [dbo].[Products] VALUES (@Price, @Name, @Amount, @Date)", products);
        }
    }
}