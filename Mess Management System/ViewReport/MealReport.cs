using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mess_Management_System.Manager;
using Mess_Management_System.Model;

namespace Mess_Management_System.ViewReport
{
    public partial class MealReport : Form
    {
        public MealReport()
        {
            InitializeComponent();
        }

       

        private void MealReport_Load(object sender, EventArgs e)
        {
            GetMemberList();

        }

        MealManager mealManager = new MealManager();
        MemberManager memberManager = new MemberManager();

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

            int count = 1;
            double total = 0;

            string date = DateTime.Now.Month.ToString();
            //DateTime startDate = Convert.ToDateTime(dateTimePicker.Text);
            //DateTime endDate = Convert.ToDateTime(dateTimePicker.Text).AddDays(-7);

            int id = (int)memberComboBox.SelectedValue;

            List<MealView> getList = mealManager.Last7MealViews(id,date);

            foreach (var meallist in getList)
            {
                total += meallist.TotalMeal;
   
               ListViewItem item = new ListViewItem();

                item.Text = count++.ToString();
                item.SubItems.Add(meallist.MealDate.ToString());
                item.SubItems.Add(meallist.TotalMeal.ToString());
                item.SubItems.Add(total.ToString());

                last7mealListView.Items.Add(item);



            }



        }






        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void memberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     



    }
}
