using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAppBusiness.ViewModel
{
    public class AccountTypeViewMode
    {
        public int id { get; set; }
        public string accType { get; set; }
        public Nullable<decimal> rate { get; set; }
    }
}
