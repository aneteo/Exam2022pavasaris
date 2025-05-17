using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WindowsFormsApp1
{
    internal static class Program
    {
 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class BrowserAutomation
    {
        private IWebDriver driver;

        public BrowserAutomation()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.ebay.com");
        }

        public void Search(string searchQuery)
        {
            IWebElement searchBox = driver.FindElement(By.Id("gh-ac"));
            searchBox.SendKeys(searchQuery);

            IWebElement searchButton = driver.FindElement(By.Id("gh-btn"));
            searchButton.Click();

            Console.WriteLine("Meklēšanas rezultātu URL: " + driver.Url);
        }

        public void GoBack()
        {
            driver.Navigate().Back();
            IWebElement searchBox = driver.FindElement(By.Id("gh-ac"));
            searchBox.Clear();
        }

        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
