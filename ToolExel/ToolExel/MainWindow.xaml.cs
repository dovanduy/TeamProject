using Aspose.Cells;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToolExel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Email> danhSachTaiKhoanTatCa = new List<Email>();
        List<Email> danhSachHienThi = new List<Email>();
        NotifiableCollection<QuocGia> danhSachQuocGia = new NotifiableCollection<QuocGia>() {
            new QuocGia() { TenQuocGia = "Tất cả"},
            new QuocGia() { TenQuocGia = "VN"},
            new QuocGia() { TenQuocGia = "Vietnam"},
            new QuocGia() { TenQuocGia = "US"},
            new QuocGia() { TenQuocGia = "Australia"},
            new QuocGia() { TenQuocGia = "United States"},
            new QuocGia() { TenQuocGia = "Singapore"},
            new QuocGia() { TenQuocGia = "GB"},
            new QuocGia() { TenQuocGia = "Democratic Republic of the Congo"},
            new QuocGia() { TenQuocGia = "CA"},
            new QuocGia() { TenQuocGia = "Pakistan"},
            new QuocGia() { TenQuocGia = "United Kingdom"},
            new QuocGia() { TenQuocGia = "SE"},
            new QuocGia() { TenQuocGia = "ID"},
            new QuocGia() { TenQuocGia = "DK"},
            new QuocGia() { TenQuocGia = "Hong Kong"},
            new QuocGia() { TenQuocGia = "NL"},
            new QuocGia() { TenQuocGia = "HR"},

        };
        NotifiableCollection<LoaiMail> danhSachMail = new NotifiableCollection<LoaiMail>() {
            new LoaiMail(){ TenLoaiMail="Tất cả"},
            new LoaiMail(){ TenLoaiMail="@yahoo.com"},
            new LoaiMail(){ TenLoaiMail="@facebook.com"},
            new LoaiMail(){ TenLoaiMail="@hotmail.com"},
            new LoaiMail(){ TenLoaiMail="@msn.com"},
            new LoaiMail(){ TenLoaiMail="@goanwap.com"},
            new LoaiMail(){ TenLoaiMail="@ymail.com"},
            new LoaiMail(){ TenLoaiMail="@gmail.com"},
        };

        public MainWindow()
        {
            InitializeComponent();
            stQuocGia.DataContext = danhSachQuocGia;
            stLoaiMail.DataContext = danhSachMail;
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            if (danhSachTaiKhoanTatCa.Count > 0)
            {
                MessageBox.Show("Khổng thể làm việc với nhiều file 1 lúc");
                return;
            }
            ModifyInMemory.ActivateMemoryPatching();
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (openFile.ShowDialog() == true)
            {
                txtPath.Text = openFile.FileName;
                DocDuLieu(openFile.FileName);
            }
        }

        public void DocDuLieu(string filePath)
        {
            try
            {
                for (int j = 0; j < 10; j++)
                {
                    try
                    { 
                    Workbook workbook = new Workbook(filePath);
                    Cells cells = workbook.Worksheets[j].Cells;
                        try
                        {
                            int lastrow = cells.EndCellInColumn((short)0).Row;
                            for (int i = 0; i <= lastrow; i++)
                            {
                                try
                                {
                                    int lostColumn = cells.EndCellInRow(i).Column;
                                    Email email = new Email();
                                    email.STT = (danhSachTaiKhoanTatCa.Count + 1).ToString();
                                    try
                                    {
                                        email.UID = cells[i, CellsHelper.ColumnNameToIndex("B")].Value.ToString();
                                    }
                                    catch { }
                                    try
                                    {
                                        email.Name = cells[i, CellsHelper.ColumnNameToIndex("C")].Value.ToString();
                                    }
                                    catch { }
                                    try
                                    {
                                        email.Mail = cells[i, CellsHelper.ColumnNameToIndex("G")].Value.ToString();
                                    }
                                    catch { }
                                    try
                                    {
                                        email.SoBan = int.Parse(cells[i, CellsHelper.ColumnNameToIndex("Q")].Value.ToString());
                                    }
                                    catch { }
                                    try
                                    {
                                        email.QuocGia = (cells[i, CellsHelper.ColumnNameToIndex("I")].Value.ToString());
                                    }
                                    catch { }
                                    if (email.SoBan != -1 && !string.IsNullOrEmpty(email.Mail) && !email.Mail.Contains(".vn"))
                                    {
                                        List<string> regex = email.Mail.Split(new[] { ".com" }, StringSplitOptions.None).ToList();
                                        if (string.IsNullOrEmpty(regex[regex.Count - 1]))
                                        {
                                            danhSachTaiKhoanTatCa.Add(email);
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
                MessageBox.Show("File excel lỗi!!","Thông báo",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            ReLoadData(cbLoaiMail.SelectedItem as LoaiMail, cbQuocGia.SelectedItem as QuocGia);
            MessageBox.Show("Load xong!","Thông báo",MessageBoxButton.OK,MessageBoxImage.Information);
        }
        public void ReLoadData(LoaiMail loaiMail, QuocGia quocGia)
        {
            danhSachHienThi.Clear();
            var temp = danhSachTaiKhoanTatCa.Where(model => loaiMail.TenLoaiMail.Equals("Tất cả") ? true : (model.Mail.Contains(loaiMail.TenLoaiMail))).ToList();
            int i = 1;
            foreach (var item in temp)
            {
                if (quocGia.TenQuocGia.Equals("Tất cả") ? true : item.QuocGia.Contains(quocGia.TenQuocGia))
                {
                    item.STT = i.ToString();
                    danhSachHienThi.Add(item);
                    i++;
                }
            }
            dataGridDanhSachTaiKhoan.DataContext = null;
            dataGridDanhSachTaiKhoan.DataContext = danhSachHienThi;
            txtTongSo.Text = danhSachHienThi.Count.ToString();
        }
        public void XuatDuLieu(string path)
        {
            List<Email> ds = danhSachHienThi.Where(model => KiemTra(model) /*&& KiemTraQuocGia(model)*/).ToList();
            try
            {

                Workbook wb = new Workbook();
                Worksheet sheet = wb.Worksheets[0];
                sheet.Cells.ImportCustomObjects(ds,
                        new string[] { "STT" , "UID", "Name", "Mail", "QuocGia", "SoBan" },
                        true,
                        0,
                        0,
                        ds.Count,
                        true,
                        "dd/mm/yyyy",
                        false);
                wb.Worksheets[0].AutoFitColumns();
                wb.Save(path + ".xlsx", SaveFormat.Xlsx);
            }
            catch
            {
                MessageBox.Show("Xuất file thất bại !!!!","Thông báo",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("Xuất file thành công !!!!","Thông báo",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {

            if (danhSachTaiKhoanTatCa.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                if (save.ShowDialog() == true)
                {
                    XuatDuLieu(save.FileName);
                }
            }
            else
            {
                MessageBox.Show("Chưa có dữ liệu export!!!!");
            }
        }
        public bool KiemTra(Email email)
        {
            List<string> ds = txtTaiKhoan.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (ds.Count == 0)
            {
                return true;
            }
            foreach (var item in ds)
            {
                if (ds.Contains(email.Mail))
                {
                    return true;
                }
            }
            return false;
        }
        public void setData()
        {
            danhSachHienThi.Clear();
            dataGridDanhSachTaiKhoan.DataContext = danhSachHienThi;
        }


        private void BtnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            danhSachTaiKhoanTatCa.Clear();
            danhSachHienThi.Clear();           
            txtTaiKhoan.Text = "";
            var excelProcesses = Process.GetProcessesByName(txtPath.Text);
            foreach (var process in excelProcesses)
            {
                if (process.MainWindowTitle == $"Microsoft Excel - {txtPath.Text}")
                {
                    process.Kill();
                }
            }
            txtPath.Text = "";
            dataGridDanhSachTaiKhoan.DataContext = null;
            txtTongSo.Text = danhSachHienThi.Count.ToString();

        }

        private void CbQuocGia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ReLoadData(cbLoaiMail.SelectedItem as LoaiMail, cbQuocGia.SelectedItem as QuocGia);
            }
            catch
            {

            }
            finally
            {
            }
        }

        private void CbLoaiMail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ReLoadData(cbLoaiMail.SelectedItem as LoaiMail, cbQuocGia.SelectedItem as QuocGia);
            }
            catch
            {

            }
            finally
            {
            }
        }

    }
}
