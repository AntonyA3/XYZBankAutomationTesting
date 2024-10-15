using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZBankTest
{
    internal class CustomerPage : ICommonPage
    {
        protected IWebDriver driver;
        private static By nameSelector = By.Id("userSelect");
        private static By loginButton = By.XPath(@"//*[@type=""submit""]");

        public CustomerPage(IWebDriver driver)
        {
            this.driver = driver;
            this.verifyOnPage();

        }

        public void selectName(string name)
        {
            SelectElement selector = new(driver.FindElement(nameSelector));
            selector.SelectByText(name);            
        }

        public void clickLoginButton()
        {
            driver.FindElement(loginButton).Click();
        }

        public void verifyOnPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver =>
                driver.Url.Equals("https://www.globalsqa.com/angularJs-protractor/BankingProject/#/customer")
            ); 
        }
    }
}
