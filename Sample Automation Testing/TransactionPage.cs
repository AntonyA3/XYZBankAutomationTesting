using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZBankTest
{

    internal class TransactionPage : ICommonPage
    {

        protected IWebDriver driver;

        static private By transactionField = By.XPath(@"//tbody/tr");
        static private By backButton = By.XPath(@"//*[@class=""btn""][1]");
        static private By resetButton = By.XPath(@"//*[@class=""btn""][2]");
        static private By logoutButton = By.XPath(@"//*[@class=""btn logout""]");

        public TransactionPage(IWebDriver driver)
        {
            this.driver = driver;
            this.verifyOnPage();

        }

        public void verifyNumberOfTransactions(int expected)
        {
            Assert.That(
                driver.FindElements(transactionField).Count(),
                Is.EqualTo(expected)
            );
        }

        public void clickResetButton()
        {
            driver.FindElement(resetButton).Click();
        }

        public void clickBackButton()
        {
            driver.FindElement(backButton).Click();
        }

        public void clickLogout()
        {
            driver.FindElement(logoutButton).Click();
        }

        public void verifyOnPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver =>
                driver.Url.Equals("https://www.globalsqa.com/angularJs-protractor/BankingProject/#/listTx")
            );
        }
    }
}
