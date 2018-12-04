using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mess_Management_System.UI;
using Mess_Management_System.ViewReport;

namespace Mess_Management_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

                     Application.Run(new LogInUI());
                     Application.Run(new DashBoardUI());
                     Application.Run(new MemberUI());
                     Application.Run(new DepositUI());
                     Application.Run(new ShoppingUI());
                     Application.Run(new MealUI());
                     Application.Run(new DepositReport());
                     Application.Run(new ShoppingReport());             
                     Application.Run(new MealReport());
                     Application.Run(new MonthlyMealReport());
                     Application.Run(new MonthlyReport());
                    

        }
    }
}
