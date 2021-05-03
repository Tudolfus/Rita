using Core.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Products
{
    public interface IProductsDB
    {
        Task SaveProducts(List<Product> products);

        Task<IEnumerable<ProductDB>> GetProducts(string search, short count);
    }
}