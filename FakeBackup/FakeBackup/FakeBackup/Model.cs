using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBackup
{
    public class Model : BindableBase
    {
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
    }
}
