using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HustleGotReal
{
    class Program
    {
        public static String scrapUrl = "https://www.saleyee.com/";
        /*the links are in "\HustleGotReal\bin\Debug\netcoreapp3.1\products.txt"*/
        public static String filePath = System.AppDomain.CurrentDomain.BaseDirectory + "/products.txt";
        
        static void Main(string[] args)
        {
            Program p = new Program();
            IWebDriver driver = new ChromeDriver();

            String[] links = p.GetInfo(driver);

            File.WriteAllLines(filePath, Array.ConvertAll(links, l => l.ToString()));
        }

        /*void Login(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(loginUrl);

            var inputEmail = driver.FindElement(By.Name("Email"));
            var inputPass = driver.FindElement(By.Name("Password"));

            inputEmail.SendKeys(email);
            inputPass.SendKeys(pass);

            inputEmail.Submit();
        }*/

        String[] GetInfo(IWebDriver driver)
        {
            List<String> products = new List<String>();

            driver.Navigate().GoToUrl(scrapUrl);

            IList<IWebElement> links = driver.FindElements(By.XPath("//li//div[@class='goods_box']//div[@class='goods_infor']//a"));
            //var content = driver.FindElement(By.XPath("//li//div[@class='goods_box']//div[@class='goods_infor']//a"));

            String[] linksText = new String[links.Count];
            int i = 0;
            foreach (IWebElement element in links)
            {
                linksText[i++] = element.GetAttribute("href");
            }

            return linksText;
        }
    }
}
