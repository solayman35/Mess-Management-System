using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mess_Management_System.Gateway;
using Mess_Management_System.Model;

namespace Mess_Management_System.Manager
{
    internal class MealManager
    {

        private MealGateway mealGateway = new MealGateway();

        public string saveMeal(Meal meal)
        {
            bool isExist = mealGateway.isExistMeal(meal);
            if (isExist)
            {
                return "Already Exist this Item ";
            }


            int rowAffected = mealGateway.saveMeal(meal);

            if (rowAffected > 0)
            {
                return "Meal added Successfully";
            }

            return "Failed to Add Meal !";
        }


        public List<MealView> GetDailyMeal(string date)
        {
            return mealGateway.GetDailyMeal(date);

        }



        public string UpdateMeal(Meal meal)
        {
            int rowAffected = mealGateway.UpdateMeal(meal);

            if (rowAffected > 0)
            {
                return "Meal Updated Successfully";
            }

            return "Failed to Updated Meal !";


        }



        public string RemoveMeal(int id)
        {
            int rowAffected = mealGateway.RemoveMeal(id);

            if (rowAffected > 0)
            {
                return "Meal Remove Successfully";
            }

            return "Failed to Remove Meal !";
        }



        public List<MealView> Last7MealViews(int id ,string date)
        {
            return mealGateway.Last7MealViews(id,date);
        }


        public List<MealView> MealPerPerson(int id, string date)
        {
            return mealGateway.MealPerPerson(id, date);
        }


    }
}
