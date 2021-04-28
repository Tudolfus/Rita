using Core.Interfaces.Parsers;
using Core.Models.Products;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace BL.Parsers
{
    public class SberMarketParser : IParser
    {
        public IEnumerable<Product> Parsing()
        {

            string pathToDriver = AppDomain.CurrentDomain.BaseDirectory;

            IWebDriver driver = new ChromeDriver(pathToDriver);

            

            driver.Navigate().GoToUrl("https://sbermarket.ru/auchan/voda-soki-napitki/soki-niektary-morsy?sid=177");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10000);

            IList<IWebElement> elements = GetElementsFromPage(driver);

            var result = SplitElements(elements);

            driver.Quit();

            return result;
        }

        private IList<IWebElement> GetElementsFromPage(IWebDriver driver)
        {
            try
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
            catch (Exception ex)
            {
                throw;
            }
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

            DateTime date = DateTime.Now;

            IList<IWebElement> errorElements = new List<IWebElement>();

            foreach (var i in elements)
            {
                try
                {
                    string[] pieces = i.Text.Split("\r\n");

                    Product product = new Product();

                    if (pieces.Length == 6)
                    {
                        product.Price = ParseString(pieces[1]);
                        product.Name = pieces[4];
                        product.Amount = ParseString(pieces[5]);
                    }
                    else
                    {
                        product.Price = ParseString(pieces[0]);
                        product.Name = pieces[1];
                        product.Amount = ParseString(pieces[2]);
                    }

                    product.Date = date;

                    list.Add(product);
                }
                catch (Exception ex)
                {
                    errorElements.Add(i);
                }
            }

            return list;
        }

        private double ParseString(string str)
        {
            string[] pieces = str.Split(" ");

            return Convert.ToDouble(pieces[0]);
        }
    }
}