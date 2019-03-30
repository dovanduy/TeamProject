using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Models
{
    public class LoaiTien : BindableBase
    {
        private string _nameLoaiTien;
        public string NameLoaiTien
        {
            get { return _nameLoaiTien; }
            set
            {
                if (_nameLoaiTien != value)
                {
                    _nameLoaiTien = value;
                    RaisePropertyChanged("NameLoaiTien");
                }
            }
        }
        private string _valueLoaiTien;
        public string ValueLoaiTien
        {
            get { return _valueLoaiTien; }
            set
            {
                if (_valueLoaiTien != value)
                {
                    _valueLoaiTien = value;
                    RaisePropertyChanged("ValueLoaiTien");
                }
            }
        }
    }
}
