using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mess_Management_System.Model;

namespace Mess_Management_System.Gateway
{
    class MealGateway
    {

        private string connectionstr = ConfigurationManager.ConnectionStrings["MealManagement"].ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private string query;


        public int saveMeal(Meal meal)
        {
            connection= new SqlConnection(connectionstr);
            connection.Open();

            query = "INSERT INTO DailyMeal (MemberID, MealDate, TotalMeal) VALUES('" + meal.MemberID + "', '" +
                    meal.MealDate + "', '" + meal.TotalMeal + "' ) ";

            command = new SqlCommand(query,connection);

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;

        }


        public List<MealView> GetDailyMeal(string date)
        {
            
            connection= new SqlConnection(connectionstr);
            connection.Open();

            query =
                "SELECT * FROM DailyMeal JOIN Members ON Members.MemberID = DailyMeal.MemberID WHERE MONTH(MealDate) = '" +
                date + "' ORDER BY  DailyMeal.MealDate ";

            command = new SqlCommand(query,connection);

            reader = command.ExecuteReader();

            List<MealView> mealViews = new List<MealView>();
            while (reader.Read())
            {
                MealView mealView = new MealView();

               
                mealView.MemberName = (string)reader["MemberName"];
                mealView.MealDate = (DateTime)reader["MealDate"];
                mealView.TotalMeal = (double)reader["TotalMeal"];
                mealView.MealID = (int)reader["MealID"];
                mealView.MemberID = (int)reader["MemberID"];

                mealViews.Add(mealView);

            }
            reader.Close();
            connection.Close();

            return mealViews;

        }


        public bool isExistMeal(Meal meal)
        {
            connection = new SqlConnection(connectionstr);
            connection.Open();

            query = "SELECT * FROM DailyMeal WHERE MemberID = '" + meal.MemberID +
                    "' AND MealDate = '" + meal.MealDate + "'  ";

            command = new SqlCommand(query,connection);

            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;

            connection.Close();
            return isExist;

        }





        public int UpdateMeal(Meal meal )
        {
            
            connection = new SqlConnection(connectionstr);
            connection.Open();

            query = "UPDATE DailyMeal SET  TotalMeal = '" + meal.TotalMeal + "' WHERE  MemberID = '" + meal.MemberID +
                    "' AND MealDate = '" + meal.MealDate + "' ";

            command = new SqlCommand(query,connection);
            int rowAffected = command.ExecuteNonQuery();

            connection.Close();
            return rowAffected;

        }



        public int RemoveMeal( int id)
        {
            connection = new SqlConnection(connectionstr);
            connection.Open();

            query = " DELETE FROM DailyMeal WHERE MealID = '" + id + "' ";

            command = new SqlCommand(query,connection);

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;


        }


        public List<MealView> Last7MealViews(int id, string date)
        {
            
            connection = new SqlConnection(connectionstr);
            connection.Open();

            query =
                "SELECT TOP 5 DailyMeal.MemberID, DailyMeal.MealDate, DailyMeal.TotalMeal,  Members.MemberName  FROM DailyMeal JOIN Members ON DailyMeal.MemberID = Members.MemberID where DailyMeal.MemberID = '"+id+"'  AND MONTH(MealDate) = '" +
                date + "' order by DailyMeal.MealDate DESC";

            command = new SqlCommand(query,connection);
            reader = command.ExecuteReader();

            List<MealView> mealViewsList = new List<MealView>();

            while (reader.Read())
            {
                MealView mealView = new MealView();

                mealView.MemberID = (int)reader["MemberID"];
                mealView.MemberName = (string) reader["MemberName"];
                mealView.MealDate = (DateTime) reader["MealDate"];
                mealView.TotalMeal = (double) reader["TotalMeal"];

               mealViewsList.Add(mealView);

            }
            reader.Close();

            connection.Close();
            return mealViewsList;

        }


        public List<MealView> MealPerPerson(int id, string date)
        {

            connection = new SqlConnection(connectionstr);
            connection.Open();

            query =
                "SELECT  sum(DailyMeal.TotalMeal) as TotalMeal FROM DailyMeal JOIN Members ON DailyMeal.MemberID = Members.MemberID where DailyMeal.MemberID = '" + id + "'  AND MONTH(MealDate) = '" +
                date + "' ";

            command = new SqlCommand(query, connection);
            reader = command.ExecuteReader();

            List<MealView> mealViewsList = new List<MealView>();

            while (reader.Read())
            {
                MealView mealView = new MealView();

       //         mealView.MemberID = (int)reader["MemberID"];
          //      mealView.MemberName = (string)reader["MemberName"];
       //         mealView.MealDate = (DateTime)reader["MealDate"];
                mealView.TotalMeal = (double)reader["TotalMeal"];

                mealViewsList.Add(mealView);

            }
            reader.Close();

            connection.Close();
            return mealViewsList;

        }




    }
}
