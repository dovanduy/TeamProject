using GoCheckPoint.Handle;
using GoCheckPoint.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoCheckPoint.Run
{
    public class LoginFacebook
    {
        public static string PATH_FOLDER =
            System.IO.Path.GetDirectoryName(System.Reflection.Assembly
                .GetExecutingAssembly().Location) + "\\DataBackup";

        public ChromeDriver driver { get; set; }
        public WebDriverWait waiter { get; set; }
        public List<Friend> danhSachBanRoot = new List<Friend>();
        public List<List<Friend>> danhSachBanDang = new List<List<Friend>>();
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

        public List<Friend> DocDanhSachTuFile(string path)
        {
            try
            {
                List<Friend> ds = new List<Friend>();
                var list = File.ReadAllLines(path);

                foreach (var item in list)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            string[] arr = item.Split('*');
                            ds.Add(new Friend()
                            {
                                UID = arr[0],
                                Name = arr[1],
                                Image = arr[2].Split('|')[0],
                                ImageCheckpoint = null
                            });
                        }
                    }
                    catch
                    { }
                }
                return ds;
            }
            catch
            {
                return new List<Friend>();
            }
        }

        public List<Bitmap> GetCheckPoint(string uid)
        {
            danhSachBanDang.Clear();
            List<Bitmap> bitmaps= new List<Bitmap>();
            try
            {
                waiter.Until<bool>((IWebDriver _driver) => ((IJavaScriptExecutor)_driver).ExecuteScript("return document.readyState", new object[0]).Equals("complete"));
            }
            catch
            {
                return null;
            }
            try
            {
                waiter.Until<bool>((IWebDriver _driver) => _driver.FindElements(By.XPath("//img")).Count > 3);
            }
            catch
            {
                return null;
            }
            try
            {
                ReadOnlyCollection<IWebElement> webElements = driver.FindElements(By.XPath("//img"));
                if (webElements.Count != 0)
                {
                    int num = 0;
                    for (int i = 1; i < webElements.Count - 1; i++)
                    {
                        try
                        {
                            string attribute = webElements[i].GetAttribute("src");
                            attribute = attribute.Remove(attribute.Length - "&thumbnail_version=2".Length);
                            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(attribute);
                            httpWebRequest.AllowWriteStreamBuffering = true;
                            WebResponse response = httpWebRequest.GetResponse();
                            Bitmap bitmap = new Bitmap(Image.FromStream(response.GetResponseStream()));
                            response.Close();
                            bitmaps.Add(bitmap);
                        }
                        catch
                        {
                            num++;
                            if (num != 3)
                            {
                                webElements = driver.FindElements(By.XPath("//img"));
                                bitmaps.Clear();
                                i = 0;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                    ReadOnlyCollection<IWebElement> webElements1 = driver.FindElementsByTagName("label");
                    for (int j = 0; j < webElements1.Count; j++)
                    {
                        string name = webElements1[j].Text;
                        List<Friend> dsTemp = danhSachBanRoot.Where(model => model.Name.Equals(name)).ToList();
                        //this.names.Add(); // Lấy ra tên
                        danhSachBanDang.Add(dsTemp);
                    }
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            return bitmaps;
        }
        public LoginFacebook(ChromeDriver dri)
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
        public bool chonRandom()
        {
            try
            {
                int num = (new Random()).Next(1, 6);
                driver.FindElementByXPath(string.Concat("//fieldset/label[", num, "]")).Click();
                ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementById('checkpointSubmitButton-actual-button').scrollIntoView(true)", new object[0]);
                driver.FindElementById("checkpointSubmitButton-actual-button").Click();
                WaitForJqueryAjax();
               return true;
            }
            catch
            {
                return false;
            }
        }
        public void WaitForJqueryAjax()
        {
            try
            {
                for (int i = 300; i > 0; i--)
                {
                    Thread.Sleep(1000);
                    if ((bool)((IJavaScriptExecutor)driver).ExecuteScript("return window.jQuery == undefined", new object[0]) || 
                        (bool)((IJavaScriptExecutor)driver).ExecuteScript("return window.jQuery.active == 0", new object[0]))
                    {
                        break;
                    }
                }
            }
            catch
            {
            }
        }
        public bool clickToiKhongBiet()
        {
            bool flag;
            try
            {
                int count = danhSachBanDang.Count;
                driver.FindElementByXPath(string.Concat("//fieldset/label[", count, "]")).Click();
                ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementById('checkpointSubmitButton-actual-button').scrollIntoView(true)", new object[0]);
                driver.FindElementById("checkpointSubmitButton-actual-button").Click();
                WaitForJqueryAjax();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
        public string loginFB(TaiKhoanModel taiKhoan)
        {
            try
            {
                if (string.IsNullOrEmpty(taiKhoan.Cookie))
                {
                    taiKhoan.TrangThai = "Đang đăng nhập bằng tài khoản";
                    driver.Navigate().GoToUrl("https://m.facebook.com/");
                    driver.FindElementById("m_login_email").SendKeys(taiKhoan.TaiKhoan);
                    driver.FindElementById("m_login_password").SendKeys(taiKhoan.MatKhau);
                    driver.FindElementByName("login").Click();
                }
                else
                {
                    taiKhoan.TrangThai = "Đang đăng nhập bằng cookie";
                    SetCookies(taiKhoan.Cookie);
                }

                try
                {
                    waiter.Until<bool>((IWebDriver _driver) => _driver.FindElements(By.Id("checkpointSubmitButton-actual-button")).Count > 0);
                }
                catch
                {
                    return "Không bị checkpoint hoặc sai mật khẩu";
                }
                driver.FindElementById("checkpointSubmitButton-actual-button").Click();
                try
                {
                   waiter.Until<bool>((IWebDriver _driver) => _driver.FindElements(By.XPath("//input[@value=\"3\"]")).Count > 0);
                }
                catch
                {
                    return "Không có kiểu checkpoint hình ảnh";
                }
                driver.FindElementByXPath("//input[@value=\"3\"]").FindElement(By.XPath("..")).FindElement(By.XPath("..")).FindElement(By.XPath("..")).Click();
                driver.FindElementById("checkpointSubmitButton-actual-button").Click();
                try
                {
                    waiter.Until<bool>((IWebDriver _driver) => (_driver.FindElements(By.Id("checkpointSubmitButton-actual-button")).Count <= 0 ? false : _driver.FindElements(By.XPath("//input[@value=\"3\"]")).Count == 0));
                }
                catch
                {
                    return "Không có kiểu checkpoint hình ảnh";
                }
                driver.FindElementById("checkpointSubmitButton-actual-button").Click();
                try
                {
                   waiter.Until<bool>((IWebDriver _driver) => _driver.FindElements(By.XPath("//img")).Count > 3);
                }
                catch
                {
                    return "Lỗi!!! Không load được ảnh";
                }
                return "Đang gỡ checkpoint hình ảnh";
            }
            catch
            {
                return "Lỗi!!!";
            }
        }

        public void GoCheckpoint(TaiKhoanModel taiKhoanModel)
        {
            danhSachBanRoot = DocDanhSachTuFile(PATH_FOLDER + "\\" + taiKhoanModel.UID + ".txt");
            string login = loginFB(taiKhoanModel);
            taiKhoanModel.TrangThai = login;
            if (!login.Equals("Đang gỡ checkpoint hình ảnh"))
            {
                taiKhoanModel.TrangThai = "Không có kiểu checkpoint hình ảnh";
                return;
            }
            else
            {
                taiKhoanModel.TrangThai = "Đang gỡ checkpoint hình ảnh";
                int result = 0;
                int chonBua = 0;
                // -----------------
                Loop:
                var checkPoint = GetCheckPoint(taiKhoanModel.UID);
                if (checkPoint == null)
                {
                    taiKhoanModel.TrangThai = "Không thể lấy hình ảnh";
                    return;
                }
                else
                {
                    #region
                    if (checkPoint.Count > 0)
                    {
                        string friendInImage = "";
                        foreach (var itemC in checkPoint)
                        {
                            foreach (var item in danhSachBanDang)
                            {
                                foreach (var itemCheckpoint in item)
                                {
                                    if (itemCheckpoint.ImageCheckpoint == null)
                                    {
                                        itemCheckpoint.ImageCheckpoint =
                                            SoSanhAnh.getInstance.GetImage(itemCheckpoint.Image);
                                    }
                                    if (itemCheckpoint.ImageCheckpoint != null)
                                    {
                                        if (SoSanhAnh.getInstance.SoSanh(itemC, itemCheckpoint.ImageCheckpoint) > 80)
                                        {
                                            friendInImage = itemCheckpoint.Name;
                                            break;
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(friendInImage))
                                {
                                    break;
                                }
                            }
                            if (!string.IsNullOrEmpty(friendInImage))
                            {
                                break;
                            }
                        }
                        if (string.IsNullOrEmpty(friendInImage))
                        {
                            chonBua++;
                            taiKhoanModel.TrangThai = "Chọn bừa: " + chonBua + "| Chọn đúng: " + result;
                            chonRandom();
                        }
                        else
                        {
                            if (chonName(friendInImage))
                            {
                                result++;
                                taiKhoanModel.TrangThai = "Chọn bừa: " + chonBua + "| Chọn đúng: " + result;
                            }
                            else
                            {
                                taiKhoanModel.TrangThai = "Không tìm thấy bạn bè hoặc đã xong";
                                clickToiKhongBiet();
                            }
                        }
                    }
                    else
                    {
                        taiKhoanModel.TrangThai = "Không thể lấy hình ảnh hoặc đã chọn xong";
                        return;
                    }
                    goto Loop;
                    #endregion
                }
                // Đổi mật khẩu

                // ----------------------------
            }
            #region Who is the best??
            //if (true) // So sánh hình ảnh
            //{
            //    num++;
            //    if (num >= 3)
            //    {
            //        chonRandom();
            //        taiKhoanModel.TrangThai = "Chọn random";
            //    }
            //    else if (!clickToiKhongBiet())
            //    {
            //        taiKhoanModel.TrangThai = "Lỗi!!! Click tôi không biết";
            //        return;
            //    }
            //    else
            //    {
            //        taiKhoanModel.TrangThai = "Continue..";
            //       // num1--;
            //    }
            //}
            //else
            //{
            //    taiKhoanModel.TrangThai = "OK...";
            //}
            // num1++;



            //try
            //{
            //    if (!string.IsNullOrEmpty(taiKhoanModel.Cookie))
            //    {
            //        taiKhoanModel.TrangThai = "Đang đang nhập bằng cookie";
            //        SetCookies(taiKhoanModel.Cookie);
            //    }
            //    else
            //    {
            //        taiKhoanModel.TrangThai = "Đang đang nhập bằng tài khoản, mật khẩu.";
            //        DienTaiKhoanMatKhau(taiKhoanModel.TaiKhoan, taiKhoanModel.MatKhau);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string s = ex.Message;
            //}

            //int _countLogin = 0;

            //Run:
            //// Trường hợp phải đăng nhập lại
            //if (ElementIsVisible(TenDangNhap) && ElementIsVisible(MatKhau))
            //{
            //    if (_countLogin == 2)
            //    {
            //        taiKhoanModel.TrangThai = "Tài khoản mật khẩu không chính xác!!";
            //        return;
            //    }
            //    _countLogin++;
            //    DienTaiKhoanMatKhau(taiKhoanModel.TaiKhoan, taiKhoanModel.MatKhau);
            //    goto Run;
            //}
            //// Click Next lưu mật khẩu
            //else if (ElementsIsVisible(By.XPath("//div//div//div//a")))
            //{
            //    taiKhoanModel.TrangThai = "Chọn lưu mật khẩu";
            //    if (ElementIsVisible(LuuMatKhau[0]))
            //    {
            //        LuuMatKhau[0].Click();
            //    }
            //}
            //else if (ElementIsVisible(ButtonNext)) // Click next xác minh
            //{
            //    ButtonNext.SendKeys(Keys.Enter);
            //}
            //else if (ElementIsVisible(ButtonNextCheckpoint)) // Countinue
            //{
            //    ButtonNextCheckpoint.SendKeys(Keys.Enter);
            //}

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
        public bool chonName(string name)
        {
            bool flag;
            try
            {
                driver.FindElementByXPath("//fieldset").FindElement(By.XPath(string.Concat("//span[. = '", name.Trim(), "']"))).Click();
                ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementById('checkpointSubmitButton-actual-button').scrollIntoView(true)", new object[0]);
                driver.FindElementById("checkpointSubmitButton-actual-button").Click();
                this.WaitForJqueryAjax();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
        public Bitmap Resize(Bitmap old, int newW, int newH)
        {
            Bitmap bitmap;
            try
            {
                Rectangle rectangle = new Rectangle(0, 0, newW, newH);
                Bitmap bitmap1 = new Bitmap(newW, newH);
                bitmap1.SetResolution(old.HorizontalResolution, old.VerticalResolution);
                using (Graphics graphic = Graphics.FromImage(bitmap1))
                {
                    graphic.CompositingMode = CompositingMode.SourceCopy;
                    graphic.CompositingQuality = CompositingQuality.HighQuality;
                    graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphic.SmoothingMode = SmoothingMode.HighQuality;
                    graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    using (ImageAttributes imageAttribute = new ImageAttributes())
                    {
                        imageAttribute.SetWrapMode(WrapMode.TileFlipXY);
                        graphic.DrawImage(old, rectangle, 0, 0, old.Width, old.Height, GraphicsUnit.Pixel, imageAttribute);
                    }
                }
                bitmap = bitmap1;
            }
            catch
            {
                bitmap = null;
            }
            return bitmap;
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
