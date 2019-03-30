using Bussiness.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class Model : BindableBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        private string _stt;
        public string TrangThai
        {
            get { return _stt; }
            set
            {
                if (_stt != value)
                {
                    _stt = value;
                    RaisePropertyChanged("TrangThai");
                }
            }
        }
        public TienTe _TienTe { get; set; }
        public MuiGio _MuiGio { get; set; }
        public QuocGia _QuocGia { get; set; }
        public LoaiTien _LoaiTien { get; set; }
        public string SoThe { get; set; }
        public string Thang { get; set; }
        public string Nam { get; set; } 
        public string MaBaoMat { get; set; }
        public string TenTaiKhoanQuangCao { get; set; }
    }
}
