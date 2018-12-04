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
    public partial class MonthlyReport : Form
    {
        public MonthlyReport()
        {
            InitializeComponent();
        }


        private void MonthlyReport_Load(object sender, EventArgs e)
        {
            getMealandCost();
            GetMemberList();

        }


        ShoppingManager shoppingManager = new ShoppingManager();
        MealManager mealManager = new MealManager();
        MemberManager memberManager = new MemberManager();
        DepositManager depositManager = new DepositManager();


        public int GetTotalShoppingCost()
        {

            string date = DateTime.Now.Month.ToString();

            List<ShoppingView> shoppingViews = shoppingManager.GetShoppinglList(date);

            int totalShoppingCost = 0;

            foreach (var view in shoppingViews)
            {
                totalShoppingCost += view.ShoppingCost;
            }

            return totalShoppingCost;
        }


        public double getTotalMeal()
        {

            string date = DateTime.Now.Month.ToString();

            List<MealView> mealViews = mealManager.GetDailyMeal(date);

            double totalMeal = 0;

            foreach (var view in mealViews)
            {
                totalMeal += view.TotalMeal;
            }

            return totalMeal;
        }

        public double GetMealPerCost()
        {
            double perMealCost = GetTotalShoppingCost()/getTotalMeal();
            return perMealCost;
        }


        public void getMealandCost()
        {

            costLabel.Text = GetTotalShoppingCost().ToString();
            mealLabel.Text = getTotalMeal().ToString();
            mealPerCost.Text = GetMealPerCost().ToString();

        }

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
            
            int id = (int) memberComboBox.SelectedValue;
            String date = DateTime.Now.Month.ToString();


            List<DepositView> depositViews = depositManager.DepositAmountPerPerson(id,date);

            int totalDeposit = 0;
            foreach (var view in depositViews)
            {
                totalDeposit += view.DepositAmount;
               
            }


            List<MealView> mealViews = mealManager.MealPerPerson(id,date);

            double totalMeal = 0;
            foreach (var view in mealViews)
            {
                totalMeal += view.TotalMeal;
            }

            depositAmount.Text = totalDeposit.ToString();
            mealCount.Text = totalMeal.ToString();

            double totalCost = (totalMeal*GetMealPerCost());
            totalMealCost.Text = totalCost.ToString();
            remainingAmount.Text = ( totalDeposit - totalCost).ToString();





        }

        private void label11_Click(object sender, EventArgs e)
        {



        }





    }
}
