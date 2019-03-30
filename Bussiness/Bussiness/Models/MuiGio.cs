using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Models
{
    public class MuiGio : BindableBase
    {
        private string _nameMuiGio;
        public string NameMuiGio
        {
            get { return _nameMuiGio; }
            set
            {
                if (_nameMuiGio != value)
                {
                    _nameMuiGio = value;
                    RaisePropertyChanged("NameMuiGio");
                }
            }
        }
        private string _valueMuiGio;
        public string ValueMuiGio
        {
            get { return _valueMuiGio; }
            set
            {
                if (_valueMuiGio != value)
                {
                    _valueMuiGio = value;
                    RaisePropertyChanged("ValueMuiGio");
                }
            }
        }
    }
}
