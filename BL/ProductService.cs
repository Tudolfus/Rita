using Core.Interfaces.Products;
using Core.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public class ProductService : IProductService
    {
        private readonly IProductsDB _productsDB;

        public ProductService(IProductsDB productsDB)
        {
            _productsDB = productsDB;
        }

        public async Task SaveProducts(List<Product> products)
        {
            await _productsDB.SaveProducts(products);
        }
    }
}