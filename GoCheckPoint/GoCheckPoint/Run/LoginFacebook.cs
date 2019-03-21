using GoCheckPoint.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoCheckPoint.Run
{
    public class LoginFacebook
    {
        public IWebDriver driver { get; set; }
        public WebDriverWait waiter { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        public IWebElement TenDangNhap { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@name='pass']")]
        public IWebElement MatKhau { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@name='login']")]
        public IWebElement DangNhap { get; set; }

        [FindsBy(How = How.XPath, Using = "//div//div//div//div//a[@id='nux-nav-button']")]
        public IWebElement ButtonNext { get; set; }

        [FindsBy(How = How.XPath, Using = "//div//div//div//a")]
        public IList<IWebElement> LuuMatKhau { get; set; }

        [FindsBy(How = How.XPath, Using = "//div//fieldset//label//div//div[@class='_4g34']")]
        public IList<IWebElement> DanhSachKieuCheckpoint { get; set; }

        [FindsBy(How = How.XPath, Using = "//div//div//div//img")]
        public IList<IWebElement> DanhSachAnh { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit'][@value='Continue']")]
        public IWebElement ButtonNextCheckpoint{ get; set; }

        public LoginFacebook(IWebDriver dri)
        {
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            chromeDriverService.HideCommandPromptWindow = true;
            var chromeOption = new ChromeOptions();
            chromeOption.AddArguments("chrome.switches", "--disable-extensions --disable-extensions-file-access-check " +
                "--disable-extensions-http-throttling --disable-infobars --enable-automation --start-maximized");
            chromeOption.AddUserProfilePreference("credentials_enable_service", false);
            //chromeOption.AddArguments("--headless");// hidden windown chrome
            chromeOption.AddUserProfilePreference("profile.password_manager_enabled", false);
            chromeOption.AddArgument("disable-infobars");
            dri = new ChromeDriver(chromeDriverService, chromeOption);
            dri.Navigate().GoToUrl("https://m.facebook.com/login.php");
            dri.Manage().Window.Size = new System.Drawing.Size(300, 600);
            this.driver = dri;
            waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            PageFactory.InitElements(this.driver, this);
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
        public void GoCheckpoint(TaiKhoanModel taiKhoanModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(taiKhoanModel.Cookie))
                {
                    taiKhoanModel.TrangThai = "Đang đang nhập bằng cookie";
                    SetCookies(taiKhoanModel.Cookie);
                }
                else
                {
                    taiKhoanModel.TrangThai = "Đang đang nhập bằng tài khoản, mật khẩu.";
                    DienTaiKhoanMatKhau(taiKhoanModel.TaiKhoan, taiKhoanModel.MatKhau);
                }
            }
            catch(Exception ex)
            {
                string s = ex.Message;
            }

                int _countLogin = 0;
            //while (true)
            //{
            //    // Trường hợp phải đăng nhập lại
            //    if (ElementIsVisible(TenDangNhap) && ElementIsVisible(MatKhau))
            //    {
            //        if (_countLogin == 2)
            //        {
            //            taiKhoanModel.TrangThai = "Tài khoản mật khẩu không chính xác!!";
            //            return;
            //        }
            //        _countLogin++;
            //        DienTaiKhoanMatKhau(taiKhoanModel.TaiKhoan, taiKhoanModel.MatKhau);
            //    }
            //    // Click Next lưu mật khẩu
            //    else if (ElementsIsVisible(By.XPath("//div//div//div//a")))
            //    {
            //        taiKhoanModel.TrangThai = "Chọn lưu mật khẩu";
            //        if (ElementIsVisible(LuuMatKhau[0]))
            //        {
            //            LuuMatKhau[0].Click();
            //        }
            //    }
            //    else if (ElementIsVisible(ButtonNext)) // Click next xác minh
            //    {
            //        ButtonNext.SendKeys(Keys.Enter);
            //    }
            //    else if (ElementIsVisible(ButtonNextCheckpoint)) // Countinue
            //    {
            //        ButtonNextCheckpoint.SendKeys(Keys.Enter);
            //    }
            //}
            #region 

            //if (ElementIsVisible(ButtonNextCheckpoint))
            //{
            //    Thread.Sleep(5);
            //    ButtonNextCheckpoint.Click();
            //    if (ElementsIsVisible(By.XPath("//div//fieldset//label//div//div[@class='_4g34']")))
            //    {
            //        if (DanhSachKieuCheckpoint.Count > 1)
            //        {
            //            bool flag = false;
            //            foreach (var item in DanhSachKieuCheckpoint)
            //            {
            //                if (ElementIsVisible(item))
            //                {
            //                    if (item.Text.Contains("images") || item.Text.Contains("photo") ||
            //                        item.Text.Contains("image") || item.Text.Contains("hình") || item.Text.Contains("photos")) // bổ sung sau
            //                    {
            //                        item.Click();
            //                        flag = true;
            //                        break;
            //                    }
            //                }
            //            }
            //            if (flag)
            //            {
            //                if (ElementIsVisible(ButtonNextCheckpoint))
            //                {
            //                    ButtonNextCheckpoint.Click();

            //                    if (ElementIsVisible(ButtonNextCheckpoint))
            //                    {
            //                        ButtonNextCheckpoint.Click();
            //                    }
            //                TraLoiAnh:
            //                    // So sánh ảnh //div//div//div//img
            //                    Thread.Sleep(5);
            //                    if (ElementsIsVisible(By.XPath("//div//fieldset//label//div//div[@class='_4g34']")))
            //                    {
            //                        string dapAnTen = "NULLL HAHAHAH";
            //                        if (ElementsIsVisible(By.XPath("//div//div//div//img")))
            //                        {
            //                            foreach (var item in DanhSachAnh) // Danh Sách ảnh hiện tại
            //                            {
            //                                if (ElementIsVisible(item))
            //                                {
            //                                    string image = item.GetAttribute("src"); // ảnh hiện tại
            //                                }
            //                            }
            //                        }

            //                        bool traLoi = false;
            //                            // danh sách đáp án
            //                        foreach (var item in DanhSachKieuCheckpoint)
            //                        {
            //                            if (ElementIsVisible(item))
            //                            {
            //                                if(item.Text.Equals(dapAnTen))
            //                                {
            //                                    item.Click();
            //                                    traLoi = true;
            //                                    break; ;
            //                                }
            //                            }
            //                        }
            //                        if (!traLoi) {
            //                            DanhSachKieuCheckpoint[DanhSachKieuCheckpoint.Count - 1].Click();// Tôi ko biết
            //                        }

            //                        if (ElementIsVisible(ButtonNextCheckpoint))
            //                        {
            //                            ButtonNextCheckpoint.Click();
            //                            goto TraLoiAnh;
            //                        }

            //                    }
            //                    else
            //                    {
            //                        model.TrangThai = "Thành công";
            //                        return;
            //                    }

            //                }
            //            }
            //            else
            //            {
            //                model.TrangThai = "Không có kiểu checkpoint hình ảnh";
            //                return;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        model.TrangThai = "Không tìm loại lựa chọn kiểu checkpoint";
            //        return;
            //    }
            //}
            //else
            //{
            //    model.TrangThai = "Không bị checkpoint";
            //    return;
            //}
            #endregion
        }

        public bool KiemTraCookieDied()
        {
            if (ElementIsVisible(TenDangNhap) && ElementIsVisible(MatKhau))
            {
                return true;
            }
            return false;
        }

        public void DienTaiKhoanMatKhau(string taiKhoan, string matKhau)
        {
            if (ElementIsVisible(TenDangNhap) && ElementIsVisible(MatKhau))
            {
                if (TenDangNhap.Enabled && TenDangNhap.Displayed)
                {
                    TenDangNhap.SendKeys(taiKhoan);
                }
                if (MatKhau.Displayed && MatKhau.Enabled)
                {
                    MatKhau.SendKeys(matKhau);
                    MatKhau.SendKeys(Keys.Enter);
                }
            }
        }

        public void XacMinh()
        {
        XacMinh:
            if (ElementIsVisible(ButtonNext))
            {
                ButtonNext.Click();
                goto XacMinh;
            }
            else {
                return;
            }
        }

        /// <summary>
        /// return true if element is visible
        /// </summary>
        /// <returns></returns>
        public bool ElementIsVisible(IWebElement element)
        {
            try
            {
                //innerexception
                var ignoredExceptions = new List<Type>() { typeof(StaleElementReferenceException) };
                waiter.IgnoreExceptionTypes(ignoredExceptions.ToArray());
                waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// return true if element is visible
        /// </summary>
        /// <returns></returns>
        public bool ElementsIsVisible(By element)
        {
            try
            {
                var ignoredExceptions = new List<Type>() { typeof(StaleElementReferenceException) };
                waiter.IgnoreExceptionTypes(ignoredExceptions.ToArray());
                waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
