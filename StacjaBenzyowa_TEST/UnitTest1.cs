using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using StacjaBenzynowa.Models;
using System;
using System.Threading;
using SQLite;
using StacjaBenzynowa;

namespace StacjaBenzyowa_TEST
{
    [TestClass]
    public class UnitTest1
    {
        protected static WindowsDriver<WindowsElement> desktopSession;
        [TestMethod]
        public void Open()
        {
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", @"C:\Users\Jehan\Documents\GitHub\GasStation-WPF\StacjaBenzynowa\bin\Debug\StacjaBenzynowa.exe");
            desktopSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities);
            Assert.IsNotNull(desktopSession.FindElementByAccessibilityId("loginBtn"));
        }

        [TestMethod]
        public void LogInAsAdmin()
        {
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", @"C:\Users\Jehan\Documents\GitHub\GasStation-WPF\StacjaBenzynowa\bin\Debug\StacjaBenzynowa.exe");
            appCapabilities.SetCapability("Login", @"C:\Users\Jehan\Documents\GitHub\GasStation-WPF\StacjaBenzynowa\bin\Debug\StacjaBenzynowa.exe");
            desktopSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities);

            desktopSession.FindElementByAccessibilityId("loginBtn").Click();
            desktopSession.FindElementByAccessibilityId("loginbox");

            //doesnt work 
            desktopSession.FindElementByAccessibilityId("loginBox").Click();
            desktopSession.FindElementByAccessibilityId("loginBox").SendKeys("jankowalski");

            desktopSession.FindElementByAccessibilityId("passwordBox").Click();
            desktopSession.FindElementByAccessibilityId("passwordBox").SendKeys("kowalski");

            desktopSession.FindElementByAccessibilityId("ZalogujBtn").Click();
            Assert.IsNotNull(desktopSession.FindElementByAccessibilityId("MonitoringBtn"));            
        }
    }
}
