using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class LibrarySelenium
    {
        IWebDriver _driver;
        WebDriverWait _waiter;
        public LibrarySelenium(IWebDriver driver, WebDriverWait waiter)
        {
            this._driver = driver;
            this._waiter = waiter;
        }
        /// <summary>
        /// Scroll to Element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="_driver"></param>
        public void ScrollToElement(IWebElement element)
        {
            try
            {
                Actions actions = new Actions(_driver);
                actions.MoveToElement(element);
                actions.Perform();
            }
            catch
            {
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// Check page đã loading xong các DOM chưa
        /// </summary>
        /// <param name="_driver"></param>
        /// <param name="_waiter"></param>
        /// <returns></returns>
        public bool IsLoadingComplete()
        {
            try
            {
                return _waiter.Until<bool>((IWebDriver __driver) =>
                 ((IJavaScriptExecutor)_driver).ExecuteScript("return document.readyState",
                 new object[0]).Equals("complete"));
            }
            catch
            {
                return false;
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// Check Element is Visisble
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="_driver"></param>
        /// <param name="_waiter"></param>
        /// <returns></returns>
        public bool ElementsIsVisible(By xPath)
        {
            try
            {
                //innerexception
                var ignoredExceptions = new List<Type>() { typeof(StaleElementReferenceException) };
                _waiter.IgnoreExceptionTypes(ignoredExceptions.ToArray());
                _waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(xPath));
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// Check Element is Visisble
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="_driver"></param>
        /// <param name="_waiter"></param>
        /// <returns></returns>
        public bool ElementIsVisible(IWebElement xPath)
        {
            try
            {
                //innerexception
                var ignoredExceptions = new List<Type>() { typeof(StaleElementReferenceException) };
                _waiter.IgnoreExceptionTypes(ignoredExceptions.ToArray());
                _waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(xPath));
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// Đợi Ajax request xong
        /// </summary>
        /// <param name="_driver"></param>
        /// <returns></returns>
        public bool IsAjaxLoaded()
        {
            try
            {
                int index = 10000;
                while (index != 0)
                {
                    if ((bool)((IJavaScriptExecutor)_driver).ExecuteScript("return window.jQuery == undefined",
                        new object[0]) ||
                           (bool)((IJavaScriptExecutor)_driver).ExecuteScript("return window.jQuery.active == 0",
                           new object[0]))
                    {
                        return true;
                    }
                    index--;
                }
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                GC.Collect();
            }
        }


        #region Singleton

        /// <summary>
        /// Singleton Pattern
        /// </summary>
        private LibrarySelenium()
        {
        }
        public static LibrarySelenium getInstance { get { return NestedSelenium.instance; } }
        private class NestedSelenium
        {
            static NestedSelenium()
            {
            }
            internal static readonly LibrarySelenium instance = new LibrarySelenium();
        }

        /// <summary>
        /// Scroll to Element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        public void ScrollToElement(IWebElement element, IWebDriver driver)
        {
            try
            {
                Actions actions = new Actions(driver);
                actions.MoveToElement(element);
                actions.Perform();
            }
            catch
            {
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// Check page đã loading xong các DOM chưa
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="waiter"></param>
        /// <returns></returns>
        public bool IsLoadingComplete(IWebDriver driver, WebDriverWait waiter)
        {
            try
            {
                return waiter.Until<bool>((IWebDriver _driver) =>
                 ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState",
                 new object[0]).Equals("complete"));
            }
            catch
            {
                return false;
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// Check Element is Visisble
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="driver"></param>
        /// <param name="waiter"></param>
        /// <returns></returns>
        public bool ElementsIsVisible(By xPath, IWebDriver driver, WebDriverWait waiter)
        {
            try
            {
                //innerexception
                var ignoredExceptions = new List<Type>() { typeof(StaleElementReferenceException) };
                waiter.IgnoreExceptionTypes(ignoredExceptions.ToArray());
                waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(xPath));
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// Check Element is Visisble
        /// </summary>
        /// <param name="xPath"></param>
        /// <param name="driver"></param>
        /// <param name="waiter"></param>
        /// <returns></returns>
        public bool ElementIsVisible(IWebElement xPath, IWebDriver driver, WebDriverWait waiter)
        {
            try
            {
                //innerexception
                var ignoredExceptions = new List<Type>() { typeof(StaleElementReferenceException) };
                waiter.IgnoreExceptionTypes(ignoredExceptions.ToArray());
                waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(xPath));
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// Đợi Ajax request xong
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public bool IsAjaxLoaded(IWebDriver driver)
        {
            try
            {
                int index = 10000;
                while (index != 0)
                {
                    if ((bool)((IJavaScriptExecutor)driver).ExecuteScript("return window.jQuery == undefined",
                        new object[0]) ||
                           (bool)((IJavaScriptExecutor)driver).ExecuteScript("return window.jQuery.active == 0",
                           new object[0]))
                    {
                        return true;
                    }
                    index--;
                }
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion

    }
}
