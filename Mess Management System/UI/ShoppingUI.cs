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
    public partial class ShoppingUI : Form
    {
        public ShoppingUI()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ShoppingUI_Load(object sender, EventArgs e)
        {
            GetMemberList();
            GetShoppingList();


            string CurrentMonth = String.Format("{0:MMMM}", DateTime.Now);
            monthLabel.Text = CurrentMonth;

        }


        ShoppingManager shoppingManager = new ShoppingManager();
        MemberManager memberManager = new MemberManager();
        Shopping shopping = new Shopping();


        public void GetMemberList()
        {
            
            Member defaultMember = new Member();

            defaultMember.MemberName = "-- SELECT MEMBER --";
            defaultMember.MemberID = -1;

            List<Member> members = memberManager.getMember();

            members.Insert(0,defaultMember);

            memberComboBox.DataSource = members;
            memberComboBox.DisplayMember = "MemberName";
            memberComboBox.ValueMember = "MemberID";


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            shopping.MemberID = (int)memberComboBox.SelectedValue;
            shopping.ShoppingDate = Convert.ToDateTime(dateTimePicker.Text);
            shopping.ShoppingCost = Convert.ToInt32(CostTextBox.Text);

            if (btnSave.Text == "Save")
            {
                string Message = shoppingManager.SaveDailyShopping(shopping);

                MessageBox.Show(Message);

                GetShoppingList();
                Resetall();

            }
            else
            {
                shopping.ShoppingID = Convert.ToInt32(btnHidden.Text);

                string Message = shoppingManager.UpdateDailyShopping(shopping);
                MessageBox.Show(Message);


                GetShoppingList();
                Resetall();

            }


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Resetall();
        }

        private void Resetall()
        {
            memberComboBox.Text = String.Empty;
            CostTextBox.Text = String.Empty;
            btnHidden.Text = String.Empty;

            btnSave.Text = "Save";

            // btnRemove.Enabled = false;
        }


        private void GetShoppingList()
        {
            int total = 0;
           

            string date = DateTime.Now.Month.ToString();

            ShoppingListView.Items.Clear();

            List<ShoppingView> shoppingViewList = shoppingManager.GetShoppinglList(date);

            foreach (var shoppingView in shoppingViewList)
            {
                total += shoppingView.ShoppingCost;

              
                ListViewItem item = new ListViewItem();
                item.Text = shoppingView.ShoppingDate.ToString();
                item.SubItems.Add(shoppingView.MemberName);
                item.SubItems.Add(shoppingView.ShoppingCost.ToString());
                item.SubItems.Add(total.ToString());

                item.Tag = shoppingView;

                ShoppingListView.Items.Add(item);

            }

        }


        private void ShoppingListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {


            ListViewItem selectedItem = ShoppingListView.SelectedItems[0];

            ShoppingView shoppingView = (ShoppingView)selectedItem.Tag;

            memberComboBox.Text = shoppingView.MemberName;
            CostTextBox.Text = shoppingView.ShoppingCost.ToString();
            dateTimePicker.Text = shoppingView.ShoppingDate.ToString();

            btnHidden.Text = shoppingView.ShoppingID.ToString();


            btnSave.Text = "Update";


        }


        private void btnRemove_Click(object sender, EventArgs e)
        {

            DialogResult dialog = MessageBox.Show("Do you want to Delete this Shopping Item?", "Delete",
                MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                int getId = Convert.ToInt32(btnHidden.Text);

                string Message = shoppingManager.DEleteShoppingItem(getId);
                MessageBox.Show(Message);

                btnSave.Text = "Save";

                GetShoppingList();
                Resetall();

            }


        }

       




        private void ShoppingListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      





    }
}
