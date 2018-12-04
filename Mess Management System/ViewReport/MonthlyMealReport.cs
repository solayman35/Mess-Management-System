using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Mess_Management_System.Manager;
using Mess_Management_System.Model;

namespace Mess_Management_System.ViewReport
{
    public partial class MonthlyMealReport : Form
    {
        public MonthlyMealReport()
        {
            InitializeComponent();
        }

        private void MonthlyMealReport_Load(object sender, EventArgs e)
        {
            GetMemberList();
        }



        MemberManager memberManager = new MemberManager();
        ReportDocument document = new ReportDocument();

        public void GetMemberList()
        {

            Member defaultMember = new Member();

            defaultMember.MemberName = "-- SELECT MEMBER --";
            defaultMember.MemberID = -1;

            List<Member> members = memberManager.getMember();

            members.Insert(0, defaultMember);

            memberComboBox.DataSource = members;
            memberComboBox.DisplayMember = "MemberName";
            memberComboBox.ValueMember = "MemberID";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int id = (int)memberComboBox.SelectedValue;
            string date = dateTimePicker.Value.Month.ToString();


            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-KJKT81T\SQLEXPRESS;Initial Catalog=MEAL-Management-C#;Integrated Security=True");

            string query =
                "SELECT DailyMeal.MemberID, Members.MemberName, DailyMeal.MealDate, DailyMeal.TotalMeal FROM DailyMeal JOIN Members ON Members.MemberID = DailyMeal.MemberID WHERE DailyMeal.MemberID = '" +
                id + "' OR MONTH(MealDate) = '" + date + "' ORDER BY  DailyMeal.MealDate ";

            SqlDataAdapter adapter = new SqlDataAdapter(query,connection);
            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet);

            document.Load(@"C:\Users\Mr. Grey\Desktop\Mess Management System\Mess Management System\CrystalRrport\crMealReport.rpt");
            document.SetDataSource(dataSet);
            document.SetParameterValue("memberID",memberComboBox.SelectedValue);    //FOR PARAMETER
            document.SetParameterValue("Date", dateTimePicker.Value.Month);         //FOR PARAMETER
            crvMealReport.ReportSource = document;

        }

       
    }
}
