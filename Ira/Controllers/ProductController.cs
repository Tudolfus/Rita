using Core.Interfaces.Products;
using Core.Models.Products;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ira.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBL _productBL;

        public ProductController(IProductBL productBL)
        {
            _productBL = productBL;
        }

        [Route("get-products")]
        public async Task<ActionResult> GetProducts(string search, short count = 10)
        {
            IEnumerable<ProductDB> result = await _productBL.GetProducts(search, count);

            return Ok(result);
        }
    }
}