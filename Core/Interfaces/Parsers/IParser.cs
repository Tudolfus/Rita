using Core.Models.Products;
using System.Collections.Generic;

namespace Core.Interfaces.Parsers
{
    public interface IParser
    {
        IEnumerable<Product> Parsing();
    }
}