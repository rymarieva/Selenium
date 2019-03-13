using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium
{
 
    public class UITests
    {
     [Test]
        public void TestWebDriverMethods()
        {
            IWebDriver driver = new ChromeDriver();
        }
    }
}
