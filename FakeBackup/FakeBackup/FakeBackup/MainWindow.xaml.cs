using Leaf.xNet;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using System.Windows.Threading;

namespace FakeBackup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string PATH_FOLDER = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\DataBackup";
        NotifiableCollection<Model> danhSachUID = new NotifiableCollection<Model>();

        public MainWindow()
        {
            InitializeComponent();
            dataGridDanhSachTaiKhoan.DataContext = danhSachUID;
            if (!Directory.Exists(PATH_FOLDER))
            {
                Directory.CreateDirectory(PATH_FOLDER);
            }
        }
        public void Run(Model model, string responceResult)
        {
            List<string> danhSachAnh = new List<string>();
            HttpRequest httpRequest = new HttpRequest();
            bool flag = true;
            model.TrangThai = "Đang Backup!";
            string item = model.UID;
            string backupFolder = PATH_FOLDER + "\\" + item + ".txt";
            if (File.Exists(backupFolder))
            {
                model.TrangThai = "UID này đã được backup!";
                return;
            }

            if (responceResult != "")
            {
                JObject dataJson_fr = JObject.Parse(responceResult);
                if (dataJson_fr != null)
                {
                    if (dataJson_fr["data"] != null)
                    {
                        model.TrangThai = "Đang backup!";
                        int friend = dataJson_fr["data"].Count<JToken>();
                        if (true)
                        {
                            List<string> danhSachId = new List<string>();
                            string URL = "";
                            string responce = "";
                            for (int i = 0; i < friend; i++)
                            {
                                if (dataJson_fr["data"][i]["id"] != null && dataJson_fr["data"][i]["name"] != null)
                                {
                                    string _id = dataJson_fr["data"][i]["id"].ToString();
                                    string _name = dataJson_fr["data"][i]["name"].ToString();
                                    try
                                    {

                                        danhSachId.Add(_id);
                                        URL = string.Concat(new string[] { URL, "{\"method\":\"GET\",\"relative_url\":\"?ids=", _id,
                                            "&fields=id,name,picture,photos.limit(", "15", "){source,width,height}\"}," });
                                        if (danhSachId.Count == 50 ? true : i == friend)
                                        {
                                            URL = string.Concat("[", URL, "]");
                                            string BODY = "";
                                            Dispatcher.Invoke(new Action(() =>
                                            {
                                                BODY = string.Concat(new string[] { "access_token=", (Uri.EscapeDataString(txtToken.Text.Trim())), "&batch=", (Uri.EscapeDataString(URL)) });
                                            }), DispatcherPriority.ContextIdle);

                                            try
                                            {
                                                responce = httpRequest.Post("https://graph.facebook.com", BODY, "application/x-www-form-urlencoded").ToString();
                                            }
                                            catch (Exception ex)
                                            {

                                            }
                                            if (string.IsNullOrEmpty(responce))
                                            {
                                            }
                                            else
                                            {

                                                JArray jArrays = JArray.Parse(responce);
                                                for (int j = 0; j < jArrays.Count; j++)
                                                {
                                                    string id_ = danhSachId[j];
                                                    try
                                                    {
                                                        JObject jObjects2 = JObject.Parse(jArrays[j]["body"].ToString());
                                                        string arr = jObjects2[id_]["photos"]["data"].ToString();
                                                        JArray jArrayDanhSach = JArray.Parse(arr);
                                                        for (int k = 0; k < jArrayDanhSach.Count; k++)
                                                        {
                                                            danhSachAnh.Add(danhSachId[j] + "*" +
                                                                jObjects2[danhSachId[j]]["name"].ToString() + "*" +
                                                                jArrayDanhSach[k]["source"].ToString() + "|" + jArrayDanhSach[k]["width"] + "|" + jArrayDanhSach[k]["height"].ToString());
                                                        }
                                                        danhSachAnh.Add("\r\n");
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.Write(ex);
                                                    }
                                                }

                                            }
                                            URL = "";
                                            danhSachId.Clear();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        flag = false;
                                        model.TrangThai = "Backup thất bại";
                                        GC.Collect();
                                        return;
                                    }
                                    finally
                                    {
                                        GC.Collect();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        flag = false;
                        model.TrangThai = "Backup thất bại";
                        GC.Collect();
                        return;
                    }
                }
            }
            else
            {
                flag = false;
                model.TrangThai = "Backup thất bại";
                GC.Collect();
                return;
            }
            if (flag)
            {
                TaoFile(backupFolder, danhSachAnh);
                model.TrangThai = "Xong";
                GC.Collect();
                return;
            }
        }
        public async void Backup()
        {
            btnBackup.IsEnabled = false;
            if (danhSachUID.Count > 0)
            {
                foreach (var model in danhSachUID)
                {
                    string url = "https://z-m-graph.facebook.com/" + model.UID + "/friends?limit=5000&access_token=" + txtToken.Text;
                    string responceResult = await GetDataJson(url, "");
                    await Task.Run(()=> {
                        Run(model, responceResult);
                    }); 
                }
            }
            btnBackup.IsEnabled = true;

        }
        public void TaoFile(string fileName, List<string> listTimeLine)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    using (File.Create(fileName)) ;
                }
                using (var tw = new StreamWriter(fileName))
                {
                    foreach (String s in listTimeLine)
                        tw.WriteLine(s);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private void btnBackup_Click(object sender, RoutedEventArgs e)
        {
            danhSachUID.Clear();
            List<string> danhSach = txtDanhSachId.Text.Split(new char[] { '\r', '\n' },
               StringSplitOptions.RemoveEmptyEntries).ToList();
            if (danhSach != null)
            {
                foreach (var item in danhSach)
                {
                    danhSachUID.Add(new Model() { UID = item, TrangThai = "Đang chờ!!" });
                }
            }
            if (danhSachUID.Count > 0)
            {
                Backup();
            }

        }
        public async Task<string> GetDataJson(string url, string param)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url + param))
            using (System.Net.Http.HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();

                if (result != null &&
                    result.Length >= 50)
                {
                    return result;
                }
            }
            return "";
        }

    }
}
