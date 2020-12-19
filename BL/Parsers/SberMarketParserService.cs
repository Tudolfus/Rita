using Core.Models.Products;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Parsers
{
    public class SberMarketParserService
    {
        public async Task SberMarketParser()
        {
            try
            {
                IWebDriver driver = new ChromeDriver(@"C:\Users\Professional\source\repos\Rita");

                driver.Navigate().GoToUrl("https://sbermarket.ru/auchan/voda-soki-napitki/soki-niektary-morsy?sid=177");

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10000);

                IList<IWebElement> elements = GetElementsFromPage(driver);

                List<Product> products = SplitElements(elements);

                var q = 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private IList<IWebElement> GetElementsFromPage(IWebDriver driver)
        {
            IList<IWebElement> elements;

            int oldY = 0;

            do
            {
                elements = driver.FindElements(By.ClassName("product__link"));

                var lastElement = elements[elements.Count - 1];

                ScrollToBottom(driver, lastElement.Location.X, lastElement.Location.Y);

                if (oldY != lastElement.Location.Y)
                {
                    oldY = lastElement.Location.Y;
                }
                else
                {
                    break;
                }
            } while (true);

            return elements;
        }

        private void ScrollToBottom(IWebDriver driver, int x, int y)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            string str = "window.scrollTo({top:" + y + ", left: " + x + ", behavior: \"smooth\"})";
            js.ExecuteScript(str);
            Thread.Sleep(15000);
        }

        private List<Product> SplitElements(IList<IWebElement> elements)
        {
            List<Product> list = new List<Product>();

            foreach (var i in elements)
            {
                string[] pieces = i.Text.Split("\r\n");

                Product product = new Product();

                if (pieces.Length == 6)
                {
                    product.Price = Convert.ToDouble(pieces[1]);
                    product.Name = pieces[4];
                    product.Amount = Convert.ToDouble(pieces[5]);
                }
                else
                {
                    product.Price = Convert.ToDouble(pieces[0]);
                    product.Name = pieces[1];
                    product.Amount = Convert.ToDouble(pieces[2]);
                }
            }

            return list;
        }
    }
}