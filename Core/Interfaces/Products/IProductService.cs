using Core.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Products
{
    public interface IProductService
    {
        Task SaveProducts(List<Product> products);
    }
}