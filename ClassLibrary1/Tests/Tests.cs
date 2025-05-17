using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WindowsFormsApp1.Tests
{
    [TestFixture]
    public class EbayTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Users\ozoli\Downloads\chromedriver-win64\chromedriver.exe");
            driver.Navigate().GoToUrl("https://www.ebay.com");
        }

        [Test]
        public void Test1_Field()
        {
            IWebElement searchBox = driver.FindElement(By.Id("gh-ac"));
            Assert.IsNotNull(searchBox, "Meklēšanas lauks nav atrasts!");
        }

        [Test]
        public void Test2_Search()
        {
            IWebElement searchButton = driver.FindElement(By.XPath("//button[@type='submit']"));
            Assert.IsNotNull(searchButton, "Meklēšanas poga nav atrasta!");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
