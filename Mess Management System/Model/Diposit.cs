using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mess_Management_System.Model
{
    class Deposit
    {
        public int DepositID { set; get; }
        public int MemberID { set; get; }
        public int DepositAmount { set; get; }
        public DateTime DepositDate { set; get; }

    }
}
