using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V127.SystemInfo;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XYZBankTest
{
    internal class AccountPage : ICommonPage
    {
        protected IWebDriver driver;
        
        static private By accountNumberValue = By.XPath(@"//*[contains(text(),""Account Number"")]/strong[1]");
        static private By balanceValue = By.XPath(@"//*[contains(text(),""Account Number"")]/strong[2]");
        static private By withdrawButton = By.XPath(@"//*[contains(text(),""Withdrawl"")]/*[@id=""notch""]/parent::*");
        static private By depositButton = By.XPath(@"//*[contains(text(),""Deposit"")]/*[@id=""notch""]/parent::*");
        static private By transactionButton = By.XPath(@"//*[contains(text(),""Transaction"")]/*[@id=""notch""]/parent::*");

        static private By submitWithdrawButton = By.XPath(@"//*[@type=""submit""]");
        static private By withdrawAmountInput = By.XPath(@"//input[contains(@class,""form-control"")]");
        
        static private By errorMessageLocator = By.XPath(@"//span[contains(@class,""error"")]");
        static private string errorMessage = "Transaction Failed. You can not withdraw amount more than the balance.";

        //under deposit
        static private By depositAmountInput = By.XPath(@"//input[contains(@class,""form-control"")]");
        static private By submitDepositButton = By.XPath(@"//*[@type=""submit""]");
        static private By backButton = By.XPath(@"//*[@class=""btn""][1]");
        static private By newbackButton = By.XPath(@"//*[@class=""btn""][1]");

        public AccountPage(IWebDriver driver)
        {
            this.driver = driver;
            this.verifyOnPage();
        }

        public void verifyBalance(int expectedBalance) {
            Assert.That(
                driver.FindElement(balanceValue).Text,
                Is.EqualTo(expectedBalance.ToString())
            );
        }

        public void verifyAccountNumber(int expectedAccountNumber)
        {
            Assert.That(
                driver.FindElement(accountNumberValue).Text,
                Is.EqualTo(expectedAccountNumber.ToString())
            );

        }

        public void clickWithdrawButton()
        {
            driver.FindElement(withdrawButton).Click();
        }

        public void clickDepositButton()
        {
            driver.FindElement(depositButton).Click();
        }

        public void setWithdrawalAmount(int amount)
        {
            driver.FindElement(withdrawAmountInput).SendKeys(amount.ToString());
            
        }

        public void clickSubmitWithdrawal()
        {
            driver.FindElement(submitWithdrawButton).Click();
        }

        public void depositAmount(int amount) {
            driver.FindElement(depositAmountInput).SendKeys(amount.ToString());
        }

        public void clickSubmitDeposit()
        {
            driver.FindElement(submitDepositButton).Click();
        }

        public void verifyWithdrawFailureMessage()
        {
            Assert.That(
                driver.FindElement(errorMessageLocator).Text,
                Is.EqualTo(errorMessage)
            );
        }

        public void clickTransactions()
        {
            driver.FindElement(transactionButton).Click();
        }

        public void verifyOnPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver =>
                driver.Url.Equals("https://www.globalsqa.com/angularJs-protractor/BankingProject/#/account")
            );
        }
    }
}
