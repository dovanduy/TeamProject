using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bussiness
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IWebDriver dr;
        Random random = new Random();
        public string RandomString(int length)
        { 
            const string chars = "qwertyu iopasdfg hjklzxcvbnm ABCDEFGHIJK LMNOPQRS TUVWXY Z0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        NotifiableCollection<Model> danhSachCookie = new NotifiableCollection<Model>();
        public MainWindow()
        {
            ClearMemory();
            CloseAllTabChrome();
            InitializeComponent();
            dataGridDanhSachTaiKhoan.DataContext = danhSachCookie;
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
        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            InputDataLogin inputDataLogin = new InputDataLogin(true);
            inputDataLogin.Chon += (_sender, _args) =>
            {
                string dataCallback = (_sender as InputDataLogin).txtDataInput.Text;
                List<string> ds = dataCallback.Split(new char[] { '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (var item in ds)
                {
                    danhSachCookie.Add(new Model() { Name = item, TrangThai = "Đang chờ!!" });
                }
                (_sender as InputDataLogin).Close();
            };
            inputDataLogin.ShowDialog();
        }
        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            RunMain();
            if (dr != null)
            {
                dr.Close();
                dr.Quit();
            }
        }
        public async void RunMain()
        {
            foreach (var item in danhSachCookie)
            {
               await Task.Run(() => { Run(item); });
                ClearMemory();
                CloseAllTabChrome();
            }
        }
        public void Run(Model model)
        {
            model.TrangThai = "Đang tạo BM";
            var getMail = new GetEmail(this.dr);
            getMail.SetCookies(model.Name);
            if (getMail.RunGetMail())
            {
                getMail.TaoBussiness(getMail.Email);
                model.TrangThai = getMail.Email;
                return;
            }
            else
            {
                model.TrangThai = getMail.Email;
                return;
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            CloseAllTabChrome();
            ClearMemory();
        }
    }
}