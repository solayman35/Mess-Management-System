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

namespace Mess_Management_System
{
    public partial class MemberUI : Form
    {
        public MemberUI()
        {
            InitializeComponent();
            GetMemberList();
        }


        MemberManager memberManager = new MemberManager();


        private void btnSave_Click(object sender, EventArgs e)
        {

            Member member = new Member();

            member.MemberName = nameTextBox.Text;
            member.MemberEmail = emailTextBox.Text;
            member.MemberPhone = phoneTextBox.Text;

            if (btnSave.Text == "Save")
            {
                string Message = memberManager.SaveMembers(member);
                MessageBox.Show(Message);
                GetMemberList();
                ResetAll();
               

            }
            else
            {
                member.MemberID = Convert.ToInt32(hiddenLabel.Text);

                string Message = memberManager.UpdateMember(member);
                MessageBox.Show(Message);
                GetMemberList();
                ResetAll();
                
            }

           
        }

        private void GetMemberList()
        {
            MemberListView.Items.Clear();

            List<Member> memberList = memberManager.getMember();

            foreach (Member person in memberList)
            {
                ListViewItem item = new ListViewItem();

                item.Text = person.MemberName;
                item.SubItems.Add(person.MemberEmail);
                item.SubItems.Add(person.MemberPhone);

                item.Tag = person;

                MemberListView.Items.Add(item);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void ResetAll()
        {
            nameTextBox.Clear();
            emailTextBox.Clear();
            phoneTextBox.Clear();

            hiddenLabel.Text = String.Empty;
           

        }


        private void MemberListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            ListViewItem selectedItem = MemberListView.SelectedItems[0];

            Member member = (Member)selectedItem.Tag;

            nameTextBox.Text = member.MemberName;
            emailTextBox.Text = member.MemberEmail;
            phoneTextBox.Text = member.MemberPhone;
            hiddenLabel.Text = member.MemberID.ToString();

            btnSave.Text = "Update";
           

        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to Delete Member?", "Delete", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                int id = Convert.ToInt32(hiddenLabel.Text);

                string Message = memberManager.DeleteMember(id);

                MessageBox.Show(Message);

                GetMemberList();
                ResetAll();

            }

        }




        private void MemberListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      
    }
}
