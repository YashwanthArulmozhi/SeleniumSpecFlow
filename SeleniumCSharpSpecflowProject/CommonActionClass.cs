﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumCSharpSpecflowProject
{
    class CommonActionClass : ReporterClass
    {
        BrowserClass browserClass = new BrowserClass();
        static IWebDriver driver;

        public IWebDriver InitializeDriver(string browser)
        {
            driver = browserClass.GetBrowserInstanceCreated(browser);
            return driver;
        }

        public void LaunchApplication(string browserName, string url)
        {
            if (driver == null || driver.ToString().ToLower().Equals("null"))
            {
                InitializeDriver(browserName);
                driver.Navigate().GoToUrl(url);
                driver.Manage().Window.Maximize();
            }
            else
            {
                driver.Navigate().GoToUrl(url);
            }

        }

        public void SendValue(By element, string value)
        {
            driver.FindElement(element).SendKeys(value);
        }

        public void ClickElement(By element)
        {
            driver.FindElement(element).Click();
        }


        public IWebElement WaitForElement(By element)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(25)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
        }

        public bool WaitForDynamicObjectToAppear(By Element)
        {
                int i = 1;
                do
                {
                    if (driver.FindElements(Element).Count == 1)
                    {
                        return true;
                    }
                    else
                    {
                        Thread.Sleep(2000);
                        i++;
                    }
                } while (i <= 3);
            return false;
        }

        public string GetTextValue(By Element)
        {
            return driver.FindElement(Element).Text;
        }

        public void SelectValueByIndex(By Element, int index)
        {
            SelectElement select = new SelectElement(driver.FindElement(Element));
            select.SelectByIndex(index);
        }

        public void SelectValueByValue(By Element, string value)
        {
            SelectElement select = new SelectElement(driver.FindElement(Element));
            select.SelectByValue(value);
        }

        public void SelectValueByVisibleText(By Element, string visibleText)
        {
            SelectElement select = new SelectElement(driver.FindElement(Element));
            select.SelectByText(visibleText);
        }

        public IList<IWebElement> GetAllOptionsElementsInDropDown(By Element)
        {
            SelectElement select = new SelectElement(driver.FindElement(Element));
            return select.Options;

        }

        public List<string> GetAllOptionsNamesInDropDown(By Element)
        {
            SelectElement select = new SelectElement(driver.FindElement(Element));
            List<string> options = new List<string>();
            foreach (IWebElement optionElement in select.Options)
            {
                options.Add(optionElement.Text);
            }
            return options;
        }

        public void SwitchToAlertsAndAccept()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        public void ScrollToElement(By Element)
        {
            int locationValue = driver.FindElement(Element).Location.Y;
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scroll(0," + locationValue + ");");
        }

        public void SetElementFocus(By Element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].focus();", driver.FindElement(Element));
        }

        public void SwitchWindow()
        {
            string currentWindow = driver.CurrentWindowHandle;
            List<string> windows = new List<string>(driver.WindowHandles);
            foreach (string window in windows)
            {
                driver.SwitchTo().Window(window);
            }
        }

      /*  public void PassedStepMessage(string passedMessage)
        {
            AddPassedStepLog(passedMessage);
        }

        public void FailedStepMessage(string failedMessage)
        {
            FailedStepMessage(failedMessage);
        }*/

        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
