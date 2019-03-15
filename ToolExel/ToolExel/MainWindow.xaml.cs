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
        NotifiableCollection<Email> danhSachTaiKhoan = new NotifiableCollection<Email>();
        public MainWindow()
        {
            InitializeComponent();
            dataGridDanhSachTaiKhoan.DataContext = danhSachTaiKhoan;
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            if (danhSachTaiKhoan.Count > 0)
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
                                    email.STT = (danhSachTaiKhoan.Count + 1).ToString();
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
                                    if (email.SoBan != -1 && !string.IsNullOrEmpty(email.Mail) && email.Mail.Contains("@yahoo.com") && !email.Mail.Contains(".vn"))
                                    {
                                        List<string> regex = email.Mail.Split(new[] { ".com" }, StringSplitOptions.None).ToList();
                                        if (string.IsNullOrEmpty(regex[regex.Count - 1]))
                                        {
                                            danhSachTaiKhoan.Add(email);
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
                MessageBox.Show("FIle excel lỗi!!");
            }

        }
        public void XuatDuLieu(string path)
        {
            List<Email> ds = danhSachTaiKhoan.Where(model => KiemTra(model) && KiemTraQuocGia(model)).ToList();
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
                MessageBox.Show("Xuất file thất bại !!!!");
                return;
            }
            MessageBox.Show("Xuất file thành công !!!!");
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {

            if (danhSachTaiKhoan.Count > 0)
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
        public bool KiemTraQuocGia(Email email)
        {
            List<string> ds = txtDanhSachQuocGia.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
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

        private void BtnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            danhSachTaiKhoan.Clear();
            txtDanhSachQuocGia.Text = "";
            txtTaiKhoan.Text = "";
            var excelProcesses = Process.GetProcessesByName(txtPath.Text);
            foreach (var process in excelProcesses)
            {
                if (process.MainWindowTitle == $"Microsoft Excel - {txtPath.Text}") ; // String.Format for pre-C# 6.0 
                {
                    process.Kill();
                }
            }
            txtPath.Text = "";

        }
    }
}
