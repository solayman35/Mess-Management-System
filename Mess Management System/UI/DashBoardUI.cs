using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mess_Management_System.UI;
using Mess_Management_System.ViewReport;

namespace Mess_Management_System
{
    public partial class DashBoardUI : Form
    {
        public DashBoardUI()
        {
            InitializeComponent();
        }

      
        private void aDDMEMBERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemberUI memberUi = new MemberUI();
            memberUi.Show();

        }

        private void aDDDEPOSITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemberUI memberUi = new MemberUI();
            memberUi.Show();

        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DashBoardUI dashBoardUi = new DashBoardUI();
            dashBoardUi.Show();
        }

        private void aDDDAILYSHOPPINGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShoppingUI shoppingUi = new ShoppingUI();
            shoppingUi.Show();
        }

        private void vIEWSHOPPINGREPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShoppingReport shoppingReport = new ShoppingReport();
            shoppingReport.Show();
        }

        private void DashBoardUI_Load(object sender, EventArgs e)
        {

        }

        private void aDDMEALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MealUI mealUi = new MealUI();
            mealUi.Show();
        }

        private void lASTWEEKMEALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MealReport meal = new MealReport();
            meal.Show();
        }

        private void aDDDEPOSITToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DepositUI depositUi = new DepositUI();
            depositUi.Show();
        }

        private void vIEWDEPOSITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepositReport depositReport = new DepositReport();
            depositReport.Show();
        }

        private void mONTHLYREPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyReport monthlyReport = new MonthlyReport();
            monthlyReport.Show();
        }

        private void aBOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUI aboutUi = new AboutUI();
            aboutUi.Show();
        }

        private void mEALREPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyMealReport report = new MonthlyMealReport();
            report.Show();
        }

       
    



    }
}
