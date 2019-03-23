using GoCheckPoint.BaseModel;
using GoCheckPoint.Model;
using GoCheckPoint.Run;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        public ChromeDriver driver;

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
                if (!item.IsRun)
                {
                    item.TrangThai = "Đang đăng nhập";
                    await Task.Run(() => { Run(item); });
                    ClearMemory();
                    CloseAllTabChrome();
                    item.IsRun = true;
                }
                else
                {
                    item.TrangThai = "Tài khoản này đã được chạy";
                }
            }
        }

        public void Run(TaiKhoanModel taiKhoanModel)
        {
            LoginFacebook loginFacebook = new LoginFacebook(driver);
            loginFacebook.GoCheckpoint(taiKhoanModel);
        }

        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            //double soSanh =  Handle.SoSanhAnh.getInstance.SoSanh(
            //    Handle.SoSanhAnh.getInstance.GetImage("https://scontent.xx.fbcdn.net/v/t1.0-0/q83/p75x225/12417824_10153781403843605_853243620985875767_n.jpg?_nc_cat=110&_nc_ht=scontent.xx&oh=6affed873bd1ac072c1a4375cf3d8403&oe=5D229656"),
            //    Handle.SoSanhAnh.getInstance.GetImage("https://scontent.xx.fbcdn.net/v/t1.0-0/p75x225/1935914_106858108886_2602058_n.jpg?_nc_cat=100&_nc_ht=scontent.xx&oh=ad926dabc5c7288d44535be309aec224&oe=5D204085"));
            if (string.IsNullOrEmpty(txtTenTaiKhoan.Text) || string.IsNullOrEmpty(txtMatKhau.Password) || string.IsNullOrEmpty(txtUID.Text))
            {
                MessageBox.Show("Tài khoản và mật khẩu bắt buộc phải nhập!!",
                    "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            danhSachTaiKhoan.Add(new TaiKhoanModel()
            {
                STT = danhSachTaiKhoan.Count + 1 + "",
                TaiKhoan = txtTenTaiKhoan.Text,
                MatKhau = txtMatKhau.Password,
                Cookie = txtCookie.Text,
                TrangThai = "Đang đợi...",
                UID = txtUID.Text,
                IsRun = false
            });
            ClearText();
        }

        public void ClearText()
        {
            txtTenTaiKhoan.Text = "";
            txtMatKhau.Password = "";
            txtCookie.Text = "";
            txtUID.Text = "";
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
