using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class AddToCart
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.katalon.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheAddToCartTest()
        {
            driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");
            driver.FindElement(By.XPath("//div[4]/div/div/div[2]")).Click();
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("ehafilipovic@gmail.com");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("test.123");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Forgot password?'])[1]/following::input[1]")).Click();
            driver.FindElement(By.LinkText("Apparel & Shoes")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='per page'])[1]/following::img[1]")).Click();
            driver.FindElement(By.Id("product_attribute_5_7_1")).Click();
            new SelectElement(driver.FindElement(By.Id("product_attribute_5_7_1"))).SelectByText("2X");
            driver.FindElement(By.Id("product_attribute_5_7_1")).Click();
            driver.FindElement(By.Id("addtocart_5_EnteredQuantity")).Click();
            driver.FindElement(By.Id("addtocart_5_EnteredQuantity")).Clear();
            driver.FindElement(By.Id("addtocart_5_EnteredQuantity")).SendKeys("2");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='*'])[1]/following::div[2]")).Click();
            driver.FindElement(By.Id("add-to-cart-button-5")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Log out'])[1]/following::span[1]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
