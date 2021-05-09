using Core.Interfaces.Products;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System.Collections.Generic;
using Core.Models.Products;
using Microsoft.Extensions.Options;
using Core.Models.Configuration;
using System;

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

            DateTime dateTime = DateTime.Now;

            foreach (var i in products)
            {
                await connection.ExecuteAsync("[dbo].[SaveProductDateInfo]",
                    new { productName = i.Name, storeId = 1, date = dateTime, price = i.Price}, commandType: CommandType.StoredProcedure);
            }
            
        }

        public async Task<IEnumerable<ProductDB>> GetProducts(string search, short count)
        {
            using IDbConnection connection = new SqlConnection(ConnectionStrings.Value.Dev);

            return await connection.QueryAsync<ProductDB>("[dbo].[GetProducts]", new { search, count }, commandType: CommandType.StoredProcedure);
        }
    }
}