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
    public partial class DepositReport : Form
    {
        public DepositReport()
        {
            InitializeComponent();
        }

        private void DepositReport_Load(object sender, EventArgs e)
        {
            GetMemberList();

            string month = String.Format("{0:MMMM}",DateTime.Now);
            monthLabel.Text = month;

        }


        MemberManager memberManager = new MemberManager();
        DepositManager depositManager = new DepositManager();

        public void GetMemberList()
        {
            Member defaultMember = new Member();

            defaultMember.MemberID = -1;
            defaultMember.MemberName = "-- SELECT MEMBER --";

            List<Member> memberLists = memberManager.getMember();

            memberLists.Insert(0, defaultMember);
            MemberComboBox.DataSource = memberLists;
            MemberComboBox.DisplayMember = "MemberName";
            MemberComboBox.ValueMember = "MemberID";


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            depositReportlistView.Items.Clear();

            int count = 1;
            int total = 0;

            int id = (int)MemberComboBox.SelectedValue;
            string date = DateTime.Now.Month.ToString();

            List<DepositView> viewDeposit = depositManager.DepositReportList(id, date);

            foreach (var depositView in viewDeposit)
            {
               ListViewItem item = new ListViewItem();

                item.Text = count++.ToString();
                item.SubItems.Add(depositView.DepositDate.ToString());
                item.SubItems.Add(depositView.DepositAmount.ToString());
                item.SubItems.Add((total += depositView.DepositAmount).ToString());


                depositReportlistView.Items.Add(item);

            }



        }

       




    }
}
