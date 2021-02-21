using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Parsers;
using Core.Interfaces.Products;
using Core.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace Ira.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IParser _sberMarketParser;
        private readonly IProductBL _productService;

        public TestController(IParser sberMarketParser, IProductBL productService)
        {
            _sberMarketParser = sberMarketParser;
            _productService = productService;
        }

        [HttpGet("sber/parser")]
        public async Task<IActionResult> Test()
        {
            IEnumerable<Product> products = _sberMarketParser.Parsing();
            await _productService.SaveProducts(products.ToList());
            return Ok("29-12");
        }
    }
}