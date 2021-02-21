using Core.Interfaces.Products;
using Core.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public class ProductBL : IProductBL
    {
        private readonly IProductsDB _productsDB;

        public ProductBL(IProductsDB productsDB)
        {
            _productsDB = productsDB;
        }

        public async Task SaveProducts(List<Product> products)
        {
            await _productsDB.SaveProducts(products);
        }

        public async Task<IEnumerable<ProductDB>> GetProducts(string productName)
        {
            return await _productsDB.GetProducts(productName);
        }
    }
}