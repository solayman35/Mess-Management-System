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
    public partial class MealUI : Form
    {
        public MealUI()
        {
            InitializeComponent();
        }

        private void MealUI_Load(object sender, EventArgs e)
        {
            GetMemberList();
            GetDailyMeal();

            string month = String.Format("{0:MMMM}", DateTime.Now);
            monthLabel.Text = month;


        }


        Meal meal = new Meal();
        MealManager mealManager = new MealManager();
        MemberManager memberManager = new MemberManager();


        public void GetMemberList()
        {
            Member defaultMember = new Member();

            defaultMember.MemberName = "-- SELECT MEMBER --";
            defaultMember.MemberID = -1;

            List<Member> getMember = memberManager.getMember();

            getMember.Insert(0, defaultMember);

            memberComboBox.DataSource = getMember;
            memberComboBox.DisplayMember = "MemberName";
            memberComboBox.ValueMember = "MemberID";
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            meal.MemberID = (int)memberComboBox.SelectedValue;
            meal.MealDate = Convert.ToDateTime(dateTimePicker.Text);
            meal.TotalMeal = Convert.ToDouble(mealTextBox.Text);

            if (btnSave.Text == "Save")
            {
                string Message = mealManager.saveMeal(meal);
                MessageBox.Show(Message);
                Reset();
                GetDailyMeal();

            }
            else
            {
                meal.MealID = Convert.ToInt32(hiddenLabel.Text);

                string Message = mealManager.UpdateMeal(meal);
                MessageBox.Show(Message);
                Reset();
                GetDailyMeal();
            }

        }


        private void GetDailyMeal()
        {
            mealListView.Items.Clear();

            int count = 1;
            string date = DateTime.Now.Month.ToString();

            List<MealView> mealViewList = mealManager.GetDailyMeal(date);

            foreach (var view in mealViewList)
            {
                
                ListViewItem item = new ListViewItem();

                item.Text = count++.ToString();
                item.SubItems.Add(view.MemberName);
                item.SubItems.Add(view.MealDate.ToString());
                item.SubItems.Add(view.TotalMeal.ToString());
                item.Tag = view;


                mealListView.Items.Add(item);

            }

        }

        private void mealListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            ListViewItem seklectedItem = mealListView.SelectedItems[0];

            MealView mealView = (MealView) seklectedItem.Tag;

           memberComboBox.Text = mealView.MemberName;
            dateTimePicker.Text = mealView.MealDate.ToString();
           mealTextBox.Text = mealView.TotalMeal.ToString();

            hiddenLabel.Text = mealView.MealID.ToString();

            btnSave.Text = "Update";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            memberComboBox.Text = String.Empty;
            mealTextBox.Text = String.Empty;
            hiddenLabel.Text = String.Empty;
            btnSave.Text = "Save";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            DialogResult dialog = MessageBox.Show("Do you want to Remove meal Item ?", "Delete", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                int id = Convert.ToInt32(hiddenLabel.Text);
                string Message = mealManager.RemoveMeal(id);

                MessageBox.Show(Message);

                Reset();
                btnSave.Text = "Save";
                GetDailyMeal();
            }


        }
    }
}
