using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace lb6
{
    class Tests
    {
        public static string path = "https://dungeon.su/spells/";
        string logo = "body > main > div > div.left.sticky > section:nth-child(1) > div > ul > li:nth-child(2) > ul > li:nth-child(1) > a";
        string search_input = "body > main > div > div.center > div > section.block.block_100.search_form > form > div:nth-child(1) > div:nth-child(1) > div > input";
        string search_non_text = "body > main > div > div.center > div > section:nth-child(2) > div > div > div.card-header > h2";

        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void opensite()
        {
            driver.Navigate().GoToUrl(path);
            driver.Manage().Window.Size = new System.Drawing.Size(1366, 768);
            System.Threading.Thread.Sleep(1000);

        }

        [Test]
        public void searchonsite()
        {
            driver.Navigate().GoToUrl(path);
            driver.Manage().Window.Size = new System.Drawing.Size(1366, 768);

            driver.FindElement(By.CssSelector(search_input)).Click();
            driver.FindElement(By.CssSelector(search_input)).SendKeys("огонь");
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(search_input)).SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(logo)).Click();
            driver.FindElement(By.CssSelector(search_input)).SendKeys("");
            driver.FindElement(By.CssSelector(search_input)).SendKeys("лед");
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(search_input)).SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(1000);
        }


        [Test]
        public void nothingmatches()
        {
            driver.Navigate().GoToUrl(path);
            driver.Manage().Window.Size = new System.Drawing.Size(1366, 768);

            driver.FindElement(By.CssSelector(search_input)).Click();
            driver.FindElement(By.CssSelector(search_input)).SendKeys("якнчсиротлб");
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(search_input)).SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(1000);
            driver.FindElements(By.CssSelector(search_non_text));
            System.Threading.Thread.Sleep(1000);

        }
    }
}
