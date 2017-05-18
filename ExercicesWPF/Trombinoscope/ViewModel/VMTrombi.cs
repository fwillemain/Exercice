using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trombinoscope
{
    public class VMTrombi : ViewModelBase
    {
        public List<Employé> LstEmployé { get; set; }
        public VMTrombi()
        {
            LstEmployé = DAL.GetEmployésWithPhoto();
        }
    }
}
