﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mess_Management_System.Model
{
    class ShoppingView
    {

        public int ShoppingID { set; get; }
        public int MemberID { set; get; }
        public string MemberName { set; get; }
        public DateTime ShoppingDate { set; get; }
        public int ShoppingCost { set; get; }

    }
}
