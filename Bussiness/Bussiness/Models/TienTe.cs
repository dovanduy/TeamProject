using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Models
{
    public class TienTe : BindableBase
    {
        private string _nameTienTe;
        public string NameTienTe
        {
            get { return _nameTienTe; }
            set
            {
                if (_nameTienTe != value)
                {
                    _nameTienTe = value;
                    RaisePropertyChanged("NameTienTe");
                }
            }
        }
        private string _valueTienTe;
        public string ValueTienTe
        {
            get { return _valueTienTe; }
            set
            {
                if (_valueTienTe != value)
                {
                    _valueTienTe = value;
                    RaisePropertyChanged("ValueTienTe");
                }
            }
        }
    }
}
