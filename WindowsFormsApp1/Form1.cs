using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private IWebDriver driver;
        private List<string> searchHistory = new List<string>();

        public Form1()
        {
            InitializeComponent();
            driver = new ChromeDriver((@"C:\Users\ozoli\Downloads\chromedriver-win64\"));
            driver.Navigate().GoToUrl("https://www.ebay.com");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            IWebElement searchBox = driver.FindElement(By.Id("gh-ac"));
            searchBox.SendKeys(textBox1.Text); 

            IWebElement searchButton = driver.FindElement(By.XPath("//button[@type='submit']"));
            searchButton.Click();


            textBox2.Text = "Meklēšanas rezultāts: " + driver.Url;
            richTextBox1.AppendText(driver.Url);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            driver.Navigate().Back();
            textBox1.Clear(); 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            driver.Quit();
        }
    }
}
