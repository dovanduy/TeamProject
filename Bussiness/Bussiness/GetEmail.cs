using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bussiness
{
   public class GetEmail
    {
        public IWebDriver driver { get; set; }
        public WebDriverWait waiter { get; set; }
        public string Email { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@id='bookmarks_jewel']")]
        public IWebElement Menu { get; set; }
        [FindsBy(How = How.XPath, Using = "//div//a[@href='/settings/?entry_point=bookmark']")]
        public IWebElement Setting { get; set; }
        [FindsBy(How = How.XPath, Using = "//div//div//div//div//div//span//input")]
        public IWebElement CountryText { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@class='_5r7k _5r7m']")]
        public IList<IWebElement> Profile { get; set; }
        [FindsBy(How = How.XPath, Using = "//div//div//h3//span//span")]
        public IList<IWebElement> MailInfo { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@class='_4b7k _4b7k_big _53rs']")]
        public IList<IWebElement> CompanyInfo { get; set; }
        [FindsBy(How = How.XPath, Using = "//button//div//div")]
        public IWebElement ButtonContinue { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@href='/ads/creativehub/home/?crst_nav_source=SPLASH_MENU']//span//a")]
        public IWebElement ButtonTaoTaiKhoan { get; set; }
        [FindsBy(How = How.XPath, Using = "//div//div//div//div//a[@id='nux-nav-button']")]
        public IWebElement ButtonNext { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@class='_4b7k _4b7k_big _53rs']")]
        public IList<IWebElement> CompanyForm { get; set; }
        [FindsBy(How = How.XPath, Using = "//div//span//div//div//button")]
        public IList<IWebElement> ButtonSubmit { get; set; }
        [FindsBy(How = How.XPath, Using = "//div//span//div//div//button")]
        public IWebElement ButtonFinish { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@class = '_2ha7']//button")]
        public IWebElement ButtomCombobox { get; set; }
        [FindsBy(How = How.XPath, Using = "//div//div//div//div//div//div//span//div//div//div//div//div//div")]
        public IList<IWebElement> ListCountry { get; set; }
        /// <summary>
        /// If account need check telephone number
        /// </summary>
        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement NextSubmit { get; set; } // Loop 3
        LibrarySelenium library = null;
        public GetEmail(IWebDriver dri)
        {
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            chromeDriverService.HideCommandPromptWindow = true;
            var chromeOption = new ChromeOptions();
            chromeOption.AddArguments("chrome.switches", "--disable-extensions --disable-extensions-file-access-check --disable-extensions-http-throttling --disable-infobars --enable-automation --start-maximized");
            chromeOption.AddUserProfilePreference("credentials_enable_service", false);
            //chromeOption.AddArguments("--headless");// hidden windown chrome
            chromeOption.AddUserProfilePreference("profile.password_manager_enabled", false);
            chromeOption.AddArgument("disable-infobars");
            dri = new ChromeDriver(chromeDriverService, chromeOption);
            dri.Navigate().GoToUrl("https://m.facebook.com/login.php");
            dri.Manage().Window.Size = new System.Drawing.Size(300, 600);
            this.driver = dri;
            waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            library = new LibrarySelenium(driver, waiter);
            PageFactory.InitElements(this.driver,this);

        }
        public void SetCookies(string cookie)
        {
            if (driver != null)
            {
                driver.Manage().Cookies.DeleteAllCookies();
                string[] split_cookie = cookie.Split(';');
                int cout = split_cookie.Length;
                if (split_cookie.Length <= 1) return;
                for (int i = 0; i < cout; i++)
                {
                    string[] sub_cookie = split_cookie[i].Split('=');
                    if (sub_cookie.Length > 1)
                    {
                        driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(sub_cookie[0].Trim(),
                            sub_cookie[1].Trim()));
                    }
                }
                driver.Navigate().GoToUrl("https://m.facebook.com/home.php");
            }
        }
        public bool RunGetMail()
        {
            try
            {
                if (library.IsLoadingComplete() &&
                    library.IsAjaxLoaded(driver))
                {
                ClickButtonNext:
                    if (library.ElementIsVisible(ButtonNext))
                    {
                        ButtonNext.Click();
                        goto ClickButtonNext;
                    }
                    else if (library.ElementIsVisible(Menu))
                    {
                        library.ScrollToElement(Menu);
                        Menu.Click();
                        if (library.IsLoadingComplete() && library.IsAjaxLoaded())
                        {
                            if (library.ElementIsVisible(Setting))
                            {
                                try
                                {
                                    library.ScrollToElement(Setting);
                                    Setting.Click();
                                }
                                catch
                                {
                                    Email = "Đizz con mẹ Indonesia";
                                    return false;
                                }
                                if (library.IsLoadingComplete() && library.IsAjaxLoaded() && library.ElementsIsVisible(By.XPath("//div[@class='_5r7k _5r7m']")))
                                {
                                    library.ScrollToElement(Profile[0]);
                                    Profile[0].Click();
                                    if (library.IsLoadingComplete() && library.IsAjaxLoaded() && library.ElementsIsVisible(By.XPath("//div//div//h3//span//span")))
                                    {
                                        Email = MailInfo[0].Text;
                                        return true;
                                    }
                                    else
                                    {
                                        Email = "Không tìm thấy Email";
                                        driver.Close();
                                        return false;
                                        // 
                                    }
                                }
                                else
                                {
                                    Email = "Không tìm thấy Profile";
                                    driver.Close();
                                    return false;
                                    // Không tìm thấy Profile
                                }
                            }
                            else
                            {
                                Email = "Không tìm thấy Setting";
                                driver.Close();
                                return false;
                                // Không tìm thấy Setting
                            }
                        }
                    }
                    else
                    {
                        Email = "Cookie died!";
                        driver.Close();
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Email = ex.Message;
                driver.Close();
                return false;
            }
            finally
            {
                GC.Collect();
            }
        }
        public string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "qwertyu iopasdfg hjklzxcvbnm ABCDEFGHIJK LMNOPQRS TUVWXY Z0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public void TaoBussiness(string mail)
        {
            driver.Navigate().GoToUrl("https://business.facebook.com/");
            if (library.IsAjaxLoaded() && library.IsLoadingComplete() && library.ElementIsVisible(ButtonTaoTaiKhoan))
            {
                try
                {
                    ButtonTaoTaiKhoan.Click();
                }
                catch (Exception ex)
                {
                    Email = "Lỗi tạo tài khoản!!";
                    driver.Close();
                    return;
                }
                if (library.ElementsIsVisible(By.XPath("//input[@class='_4b7k _4b7k_big _53rs']")))
                {
                    CompanyInfo[0].SendKeys(CompanyInfo[1].GetAttribute("value").ToString());
                    CompanyInfo[2].SendKeys(mail);
                    if (library.ElementIsVisible(ButtonContinue))
                    {
                        ButtonContinue.Click();
                        if (library.ElementsIsVisible(By.XPath("//input[@class='_4b7k _4b7k_big _53rs']")))
                        {
                            // Input form
                            Thread.Sleep(3000);
                            if (library.IsLoadingComplete() && library.IsAjaxLoaded())
                            {
                                foreach (var ipForm in CompanyForm)
                                {
                                    if (library.ElementIsVisible(ipForm))
                                    {
                                        ipForm.SendKeys(RandomString(20));
                                    }
                                }
                                CompanyForm[5].SendKeys(Keys.Control + "a");
                                CompanyForm[5].SendKeys("0385102879");
                                CompanyForm[6].SendKeys(Keys.Control + "a");
                                CompanyForm[6].SendKeys("https://www.24h.com.vn/");
                                if (library.ElementIsVisible(ButtomCombobox))
                                {
                                    ButtomCombobox.Click();

                                    if (library.ElementIsVisible(CountryText))
                                    {
                                        Thread.Sleep(1500);
                                        CountryText.SendKeys("Vi");
                                        Thread.Sleep(1200);
                                        if (library.ElementsIsVisible(By.XPath("//div//div//div//div//div//div//span//div//div//div//div//div//div")))
                                        {
                                            if (library.ElementIsVisible(ListCountry[0]))
                                            {
                                                ListCountry[0].Click();
                                            }
                                        }
                                        else
                                        {
                                            Email = "Chọn quốc gia thất bại";
                                            driver.Close();
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        Email = "Chọn quốc gia thất bại";
                                        driver.Close();
                                        return;
                                    }

                                }
                                else
                                {
                                    Email = "Chọn quốc gia thất bại";
                                    driver.Close();
                                    return;
                                }
                                if (library.ElementsIsVisible(By.XPath("//div//span//div//div//button")))
                                {
                                    if (library.ElementIsVisible(ButtonSubmit[1]))
                                    {
                                        ButtonSubmit[1].Click();
                                        if (library.IsAjaxLoaded() && library.IsLoadingComplete())
                                        {
                                            if (library.ElementIsVisible(ButtonFinish))
                                            {
                                                ButtonFinish.Click();
                                            }
                                            Email = "Thành công!!";
                                            driver.Close();
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        Email = "Gửi submit thất bại!!";
                                        driver.Close();
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Email = "Click tiếp tục thất bại";
                        driver.Close();
                        return;
                    }
                }
                else
                {
                    Email = "Nhập thông tin BM thất bại";
                    driver.Close();
                    return;
                }
            }
            else
            {
                Email = "Tài khoản đã được tạo";
                driver.Close();
                return;
            }
        }

    }
}
