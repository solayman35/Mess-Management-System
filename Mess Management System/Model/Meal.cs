using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mess_Management_System.Model
{
    class Meal
    {
        public int MealID { set; get; }
        public int MemberID { set; get; }
        public double TotalMeal { set; get; }
        public DateTime MealDate { set; get; }


    }
}
