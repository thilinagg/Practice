using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAppBusiness.ViewModel
{
    public class CreateAccountViewModel
    {
        public int id { get; set; }
        public string accountNo { get; set; }
        public string holderName { get; set; }
        public string nic { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<int> typeId { get; set; }

        public Nullable<decimal> initialAmmount { get; set; }
    }
}
