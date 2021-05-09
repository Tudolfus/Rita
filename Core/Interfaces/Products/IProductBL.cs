using Core.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Products
{
    public interface IProductBL
    {
        Task SaveProducts(List<Product> products);

        Task<IEnumerable<SelectProductVM>> GetProducts(string search, short count);
    }
}