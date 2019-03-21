using GoCheckPoint.BaseModel;
using GoCheckPoint.Model;
using GoCheckPoint.Run;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GoCheckPoint
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        NotifiableCollection<TaiKhoanModel> danhSachTaiKhoan = new NotifiableCollection<TaiKhoanModel>();
        public IWebDriver driver;

        public Main()
        {
            InitializeComponent();
            dataGridDanhSachTaiKhoan.DataContext = danhSachTaiKhoan;
            ClearMemory();
            CloseAllTabChrome();
        }

        private void BtnChay_Click(object sender, RoutedEventArgs e)
        {
            GoCheckPoint();
        }

        public async void GoCheckPoint()
        {
            foreach (var item in danhSachTaiKhoan)
            {
                await Task.Run(()=> { Run(item); });
                ClearMemory();
                CloseAllTabChrome();
            }
        }

        public void Run(TaiKhoanModel taiKhoanModel)
        {
            LoginFacebook loginFacebook = new LoginFacebook(driver);
            loginFacebook.GoCheckpoint(taiKhoanModel);
            // Nếu có nhập cookie
            //if(!string.IsNullOrEmpty(taiKhoanModel.Cookie))
            //{
            //    // Đăng nhập cookie
            //    taiKhoanModel.TrangThai = "Đang đang nhập bằng cookie";
            //    loginFacebook.SetCookies(taiKhoanModel.Cookie);
            //    if (loginFacebook.KiemTraCookieDied())
            //    {
            //        taiKhoanModel.TrangThai = "Cookie died!! Đang nhập bằng tài khoản";
            //        // Nếu cookie died!
            //        loginFacebook.DienTaiKhoanMatKhau(taiKhoanModel.TaiKhoan, taiKhoanModel.MatKhau);
            //    }
            //    else
            //    {
            //        taiKhoanModel.TrangThai = "Xác minh!!";
            //        // Đề phòng xác minh
            //        loginFacebook.XacMinh();
            //    }
            //}
            //else
            //{
            //    taiKhoanModel.TrangThai = "Đang đang nhập bằng tài khoản, mật khẩu";
            //    // Nếu ko nhập cookie
            //    loginFacebook.DienTaiKhoanMatKhau(taiKhoanModel.TaiKhoan, taiKhoanModel.MatKhau);
            //}
            //if (loginFacebook.KiemTraCookieDied())
            //{
            //    //Kiểm tra nếu vẫn còn ở đăng nhập.
            //    taiKhoanModel.TrangThai = "Tài khoản mật khẩu không chính xác!!";
            //    return;
            //}
            //taiKhoanModel.TrangThai = "Đang gỡ checkpoint";
            //// Bắt đầu kiểm tra gỡ checkpoitn
            //loginFacebook.GoCheckpoint(taiKhoanModel);
        }

        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenTaiKhoan.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Tài khoản và mật khẩu bắt buộc phải nhập!!",
                    "Thông báo",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            danhSachTaiKhoan.Add(new TaiKhoanModel() {
                STT = danhSachTaiKhoan.Count + 1 + "",
                TaiKhoan = txtTenTaiKhoan.Text,
                MatKhau = txtMatKhau.Text,
                Cookie = txtCookie.Text,
                TrangThai = "Đang đợi..."
            });
            ClearText();
        }

        public void ClearText()
        {
            txtTenTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            txtCookie.Text = "";
        }

        public void CloseAllTabChrome()
        {
            Process[] chromeInstances = Process.GetProcessesByName("chrome");
            foreach (Process p in chromeInstances)
            {
                try
                {
                    p.Kill();
                }
                catch
                {
                }
            }
        }

        public void ClearMemory()
        {
            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                try
                {
                    chromeDriverProcess.Kill();
                }
                catch
                {
                }
            }
        }
    }
}
