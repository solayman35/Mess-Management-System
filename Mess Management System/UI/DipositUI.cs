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

namespace Mess_Management_System.UI
{
    public partial class DepositUI : Form
    {

        MemberManager memberManager = new MemberManager();
        DepositManager depositManager = new DepositManager();
      


        public DepositUI()
        {
            InitializeComponent();
        }

   

        private void DipositUI_Load(object sender, EventArgs e)
        {
            GetMemberList();
            GetDepositList();
        }


        public void GetMemberList()
        {
           Member  defaultMember = new Member();

            defaultMember.MemberID = -1;
            defaultMember.MemberName = "-- SELECT MEMBER --";

            List<Member> memberLists = memberManager.getMember();

            memberLists.Insert(0,defaultMember);
            MemberComboBox.DataSource = memberLists;
            MemberComboBox.DisplayMember = "MemberName";
            MemberComboBox.ValueMember = "MemberID";


        } 


        private void btnSave_Click(object sender, EventArgs e)
        {
            Deposit deposit = new Deposit();

            deposit.MemberID = (int)MemberComboBox.SelectedValue;
            deposit.DepositAmount = Convert.ToInt32(AmountTextBox.Text);
            deposit.DepositDate = Convert.ToDateTime(dateTimePicker.Text);


            if (btnSave.Text == "Save")
            {
                string Message = depositManager.saveDepositAmount(deposit);
                MessageBox.Show(Message);

                GetDepositList();
                ResetAll();

            }
            else
            {
                deposit.DepositID = Convert.ToInt32(hiddenLabel.Text);

                string Message = depositManager.GetDepositUpdate(deposit);
                MessageBox.Show(Message);

                GetDepositList();
                ResetAll();
            }
           
        }



        private void GetDepositListView()
        {
            GetDepositList();
        }

        private void GetDepositList()
        {
            int total = 0;
            int count = 1;
            string date = DateTime.Now.Month.ToString();

            DepositListView.Items.Clear();

            List<DepositView> viewlist = depositManager.GetDeposiitList(date);


            foreach (var view in viewlist)
            {
                total += view.DepositAmount;

                ListViewItem item = new ListViewItem();

                item.Text = count++.ToString();
                item.SubItems.Add(view.MemberName);
                item.SubItems.Add(view.DepositAmount.ToString());
                item.SubItems.Add(total.ToString());

                item.Tag = view;

                DepositListView.Items.Add(item);
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void ResetAll()
        {
            MemberComboBox.Text = string.Empty;
            AmountTextBox.Text = string.Empty;
            hiddenLabel.Text = string.Empty;
        }

       
        private void DepositListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            ListViewItem selectedItem = DepositListView.SelectedItems[0];

            DepositView depositView = (DepositView)selectedItem.Tag;

            MemberComboBox.Text = depositView.MemberName;
            AmountTextBox.Text = depositView.DepositAmount.ToString();
            dateTimePicker.Text = depositView.DepositDate.ToString();

            hiddenLabel.Text = depositView.DepositID.ToString();

            btnSave.Text = "Update";

            

        }


        private void btnRemove_Click(object sender, EventArgs e)
        {

            DialogResult dialog = MessageBox.Show("Do you want to Remove Deposit Item ?", "Delete", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {

                int getId = Convert.ToInt32(hiddenLabel.Text);

                string Message = depositManager.DeleteDeposit(getId);
                MessageBox.Show(Message);

                GetDepositList();
                ResetAll();

            }

          

        }




    }
}
