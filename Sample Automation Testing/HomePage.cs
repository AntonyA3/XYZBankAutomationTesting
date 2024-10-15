using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZBankTest
{
    internal class HomePage : ICommonPage
    {
        protected IWebDriver driver;

        private static By customerLoginButton = By.XPath(@"//*[text()=""Customer Login""]");
        private static By bankManagerLoginButton = By.XPath(@"//*[text()=""Bank Manager Login""]");
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.verifyOnPage();

        }

        public void clickCustomerLogin()
        {
            driver.FindElement(customerLoginButton).Click();
        }

        public void clickBankManagerLogin()
        {
            driver.FindElement(bankManagerLoginButton).Click();
        }

        public void verifyOnPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver =>
                driver.Url.Equals("https://www.globalsqa.com/angularJs-protractor/BankingProject/#/login")
            );
        }
    }
}
