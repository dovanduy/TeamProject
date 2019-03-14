using Aspose.Cells;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
                                    if (email.SoBan != -1 && !email.Mail.Contains(".vn") &&
                                        !string.IsNullOrEmpty(email.Mail) && !email.Mail.Contains("yahoo") && !email.Mail.Contains("yaho"))
                                    {
                                        danhSachTaiKhoan.Add(email);
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
            List<Email> ds = danhSachTaiKhoan.Where(model => KiemTra(model)).ToList();
            try
            {

                Workbook wb = new Workbook();
                Worksheet sheet = wb.Worksheets[0];
                sheet.Cells.ImportCustomObjects(ds,
                        new string[] { "STT" , "UID", "Name", "Mail", "SoBan" },
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

            foreach (var item in ds)
            {
                if (ds.Contains(email.Mail))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
