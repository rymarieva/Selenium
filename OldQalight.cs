using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    class OldQalight
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // тамаут для дозагрузке элементов и драйвер через 0.5 сек повтаряет операцию, пытается найти элемент пока он "проресовывается" 
            driver.Navigate().GoToUrl("http://old.qalight.com.ua/zapisatsya-na-kursy/");
           
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Category("Smoke")]
        [Test]
        public void SmokeTest()
        {
            //Arrange
            string expectedElementLocator = ".alert.alert-error";

            //Act
            IWebElement course = driver.FindElement(By.CssSelector("[name='_7c8289bf6b8e80c1749ef54ab01b92b8']"));
            SelectElement courseDropdown = new SelectElement(course);
            courseDropdown.SelectByIndex(3);


            IWebElement surnameField = driver.FindElement(By.Id("z_sender0"));
            surnameField.SendKeys("Surname");
            //driver.FindElement(By.Id("z_sender0")).SendKeys("surname"); аналогия предыдущех строк

            IWebElement nameField = driver.FindElement(By.Id("z_text1"));
            nameField.SendKeys("Name");

            IWebElement phoneField = driver.FindElement(By.Id("z_text0"));
            phoneField.SendKeys("0661112233");

            IWebElement emailField = driver.FindElement(By.Id("z_sender1"));
            emailField.SendKeys("rymarieva@gmail.com");

            IWebElement skypeField = driver.FindElement(By.Id("z_text2"));
           // skypeField.SendKeys("testskype");

            IWebElement sourseInfo = driver.FindElement(By.CssSelector("[name='_e926ba2b2813f56de8fc13877057e908']"));
            SelectElement sourseInfoDropdown = new SelectElement(sourseInfo);
            sourseInfoDropdown.SelectByIndex(4);

            IWebElement submitButton = driver.FindElement(By.CssSelector("[type=submit]"));
            submitButton.Click();

            //IWebElement succesElement = driver.FindElement(By.CssSelector(".alert.alert-succes"));

            IWebElement succesElement = driver.FindElement(By.CssSelector(".alert.alert-error"));

            // Assert
            Assert.True(IsElementPresent(expectedElementLocator, driver), $"Expected element {expectedElementLocator} is not found"); 
        }

        public bool IsElementPresent(string cssSelector, IWebDriver driver)
        {
            var element = driver.FindElements(By.CssSelector(cssSelector));
            if (element.Count == 1)
            {
                return true;
            }
            else if (element.Count == 1)
            {
                return false;
            }
            else
            {
                throw new Exception("Unexpected error");
            }
        }
    }
}
