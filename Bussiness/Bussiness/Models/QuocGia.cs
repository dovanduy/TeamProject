using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Models
{
    public class QuocGia : BindableBase
    {
        private string _nameQuocGia;
        public string NameQuocGia
        {
            get { return _nameQuocGia; }
            set
            {
                if (_nameQuocGia != value)
                {
                    _nameQuocGia = value;
                    RaisePropertyChanged("NameQuocGia");
                }
            }
        }
        private string _valueQuocGia;
        public string ValueQuocGia
        {
            get { return _valueQuocGia; }
            set
            {
                if (_valueQuocGia != value)
                {
                    _valueQuocGia = value;
                    RaisePropertyChanged("ValueQuocGia");
                }
            }
        }
    }
}
