using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Mess_Management_System.CrystalRrport;
using Mess_Management_System.Manager;
using Mess_Management_System.Model;

namespace Mess_Management_System.ViewReport
{
    public partial class ShoppingReport : Form
    {
        public ShoppingReport()
        {
            InitializeComponent();
        }

        private void ShoppingReport_Load(object sender, EventArgs e)
        {

            //dateTimePicker.Format = DateTimePickerFormat.Custom;
            //dateTimePicker.CustomFormat = "MMMM";


        }



        ShoppingManager shoppingManager = new ShoppingManager();



        private void btnSearch_Click(object sender, EventArgs e)
        {

            shoppingReportListView.Items.Clear();


            int count = 1;
            int total = 0;
           // string date = DateTime.Now.Month.ToString();
           // DateTime d = Convert.ToDateTime(dateTimePicker);
            
            string date = dateTimePicker.Value.Month.ToString();
            List<ShoppingView> shoppingViewReport = shoppingManager.GetShoppingReport(date);

            foreach (var shoppingView in shoppingViewReport)
            {
                total += shoppingView.ShoppingCost;

                ListViewItem item = new ListViewItem();

                item.Text = count++.ToString();
                item.SubItems.Add(shoppingView.ShoppingDate.ToString());
                item.SubItems.Add(shoppingView.MemberName);
                item.SubItems.Add(shoppingView.ShoppingCost.ToString());
                item.SubItems.Add(total.ToString());

                shoppingReportListView.Items.Add(item);


            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
             ShoppingCrystalReport ccReport = new ShoppingCrystalReport();
              ccReport.Show();

            ReportDocument document = new ReportDocument();

            string date = dateTimePicker.Value.Month.ToString();

            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KJKT81T\SQLEXPRESS;Initial Catalog=MEAL-Management-C#;Integrated Security=True");

            string query =
                "SELECT Members.MemberName, DailyShopping.ShoppingDate, DailyShopping.ShoppingCost FROM DailyShopping JOIN Members ON DailyShopping.MemberID = Members.MemberID WHERE MONTH(ShoppingDate) = '" +
                date + "' ORDER BY  DailyShopping.ShoppingDate  ";

            SqlDataAdapter adapter = new SqlDataAdapter(query,connection);
            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet);

            document.Load(@"C:\Users\Mr. Grey\Desktop\Mess Management System\Mess Management System\CrystalRrport\crShoppingReport.rpt");
            document.SetDataSource(dataSet);
            
           crShoppingReport crShopping = new crShoppingReport();
             crShopping.SetDataSource(dataSet);

            ccReport.crvShoppingReport.ReportSource = crShopping;
             ccReport.crvShoppingReport.Refresh();

        }


        //public void GetMonth()
        //{


        //    string date = monthComboBox.SelectedValue.ToString();

        //}













    }
}
