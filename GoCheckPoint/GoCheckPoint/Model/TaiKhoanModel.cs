using GoCheckPoint.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoCheckPoint.Model
{
    public class TaiKhoanModel : BindableBase
    {
        public bool IsRun { get; set; }
        private string _stt;
        public string STT
        {
            get { return _stt; }
            set
            {
                if (_stt != value)
                {
                    _stt = value;
                    RaisePropertyChanged("STT");
                }
            }
        }
        private string _uid;
        public string UID
        {
            get { return _uid; }
            set
            {
                if (_uid != value)
                {
                    _uid = value;
                    RaisePropertyChanged("UID");
                }
            }
        }

        private string _taiKhoan;
        public string TaiKhoan
        {
            get { return _taiKhoan; }
            set
            {
                if (_taiKhoan != value)
                {
                    _taiKhoan = value;
                    RaisePropertyChanged("TaiKhoan");
                }
            }
        }

        private string _matkhau;
        public string MatKhau
        {
            get { return _matkhau; }
            set
            {
                if (_matkhau != value)
                {
                    _matkhau = value;
                    RaisePropertyChanged("MatKhau");
                }
            }
        }

        private string _cookie;
        public string Cookie
        {
            get { return _cookie; }
            set
            {
                if (_cookie != value)
                {
                    _cookie = value;
                    RaisePropertyChanged("Cookie");
                }
            }
        }

        private string _trangThai;
        public string TrangThai
        {
            get { return _trangThai; }
            set
            {
                if (_trangThai != value)
                {
                    _trangThai = value;
                    RaisePropertyChanged("TrangThai");
                }
            }
        }
    }
}
