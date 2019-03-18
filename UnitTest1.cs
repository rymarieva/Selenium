using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium
{
 
    public class UITests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.ukr.net/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // тамаут для дозагрузке элементов и драйвер через 0.5 сек повтаряет операцию, пытается найти элемент пока он "проресовывается" 
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void TestWebDriverMethods()
        {
            var windowHandle = driver.CurrentWindowHandle; //id открытого окна

            System.Console.WriteLine(windowHandle);

            IWebElement element = driver.FindElement(By.CssSelector("test css")); // найти элемент по селектору

            //var elements = driver.FindElements(By.CssSelector("test multi css")); //найти элементы

            var allWindowHandles = driver.WindowHandles; //коллекция открытых окон, порядок элементов может не совпадать с порядком открытия окон

            driver.SwitchTo().Window(windowHandle);
            // driver.Manage() - полезная штука
            //Logs работа с логами консоли, Cookies - работа с куками, 
            //Window - работа с окном браузера (скрины, изменения размеров)
            //Timeouts().
            //Timeouts().ImplicitWait - 
            //IJavaScriptExetutor  - для віполнения скриптоов в своих тестах
            //SwitchTo().Alert() - работа с всплівающими окнами
            //SwitchTo().Frame - перейти на фрейм, парент фрейм - вернуться на 1 фрейм вверх, SwitchTo().DefaultContent - на главную страницу если есть фреймы

            
        }
    }
}
