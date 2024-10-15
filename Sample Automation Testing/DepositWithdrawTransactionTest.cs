//Inside SeleniumTest.cs

using NUnit.Framework;

using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Firefox;

using System;

using System.Collections.ObjectModel;

using System.IO;

using XYZBankTest;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCsharp

{

    public class DepositWithdrawTransactionTest

    {
        IWebDriver driver;
        HomePage? homePage;
        CustomerPage? customerPage;
        AccountPage? accountPage;
        TransactionPage? transactionPage;
        [OneTimeSetUp]

        public void Setup()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver= new FirefoxDriver(path + @"\drivers\");
        }

        [Test]

        public void runTest()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10.0);
            driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/BankingProject/#/login");
            homePage = new HomePage(driver);
            homePage.clickCustomerLogin();
            customerPage = new CustomerPage(driver);
            customerPage.selectName("Harry Potter");
            customerPage.clickLoginButton();

            accountPage = new AccountPage(driver);
            accountPage.verifyAccountNumber(1004);
            accountPage.clickWithdrawButton();
            accountPage.setWithdrawalAmount(1009);
            accountPage.clickSubmitWithdrawal();
            accountPage.verifyWithdrawFailureMessage();
            accountPage.clickDepositButton();
            accountPage.depositAmount(100);
            Thread.Sleep(5000);
            accountPage.clickSubmitDeposit();
            accountPage.clickTransactions();

            transactionPage = new TransactionPage(driver);
            transactionPage.verifyNumberOfTransactions(1);
            transactionPage.clickResetButton();
            transactionPage.verifyNumberOfTransactions(0);
            transactionPage.clickBackButton();

            accountPage = new AccountPage(driver);
            accountPage.clickDepositButton();
            accountPage.depositAmount(200);
            Thread.Sleep(1000); //TODO : Replace

            accountPage.clickSubmitDeposit();
            accountPage.clickWithdrawButton();
            accountPage.setWithdrawalAmount(100);
            Thread.Sleep(1000); //TODO : Replace

            accountPage.clickSubmitWithdrawal();
            accountPage.verifyBalance(100);
            Thread.Sleep(1000); //TODO : Replace

            accountPage.clickTransactions();
            Thread.Sleep(1000); //TODO : Replace

            transactionPage = new TransactionPage(driver);
            transactionPage.verifyNumberOfTransactions(2);
            transactionPage.clickLogout();
            customerPage.verifyOnPage();

        }

        [OneTimeTearDown]

        public void TearDown()

        {

            driver.Quit();
            driver.Dispose();

        }


    }

}

