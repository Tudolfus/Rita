using BL.Parsers;
using System;

namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SberMarketParserService test = new SberMarketParserService();

            test.SberMarketParser();
        }
    }
}