using AutoMapper;
using Core.Interfaces.Products;
using Core.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public class ProductBL : IProductBL
    {
        private readonly IProductsDB _productsDB;
        private readonly IMapper _mapper;

        public ProductBL(IProductsDB productsDB, IMapper mapper)
        {
            _productsDB = productsDB;
            _mapper = mapper;
        }

        public async Task SaveProducts(List<Product> products)
        {
            await _productsDB.SaveProducts(products);
        }

        public async Task<IEnumerable<SelectProductVM>> GetProducts(string search, short count)
        {
            IEnumerable<ProductDB> result = await _productsDB.GetProducts(search, count);

            return _mapper.Map<IEnumerable<SelectProductVM>>(result);
        }
    }
}