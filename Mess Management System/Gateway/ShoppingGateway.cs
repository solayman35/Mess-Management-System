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
    class ShoppingGateway
    {

        private string connectionstr = ConfigurationManager.ConnectionStrings["MealManagement"].ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private string query;



        public int SaveDailyShopping(Shopping shopping)
        {
            connection= new SqlConnection(connectionstr);
            connection.Open();

            query = "INSERT INTO DailyShopping (MemberID, ShoppingDate, ShoppingCost ) VALUES('" + shopping.MemberID + "', '" + shopping.ShoppingDate + "', '" + shopping.ShoppingCost + "') ";

            command = new SqlCommand(query,connection);
            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;


        }


        public List<ShoppingView> GetShoppinglList(string date)
        {
            connection = new SqlConnection(connectionstr);
            connection.Open();

            query =
                "SELECT * FROM DailyShopping JOIN Members ON  DailyShopping.MemberID = Members.MemberID WHERE MONTH(ShoppingDate) = '" +
                date + "' ORDER BY Members.MemberID  ";

            command = new SqlCommand(query,connection);
            reader = command.ExecuteReader();

            List<ShoppingView> shoppingViewList = new List<ShoppingView>();

            while (reader.Read())
            {
                ShoppingView shoppingView = new ShoppingView();

                shoppingView.MemberName = (string)reader["MemberName"];
                shoppingView.MemberID = (int) reader["MemberID"];
                shoppingView.ShoppingCost = (int) reader["ShoppingCost"];
                shoppingView.ShoppingDate = (DateTime) reader["ShoppingDate"];
                shoppingView.ShoppingID = (int) reader["ShoppingID"];

                shoppingViewList.Add(shoppingView);

            }
            reader.Close();
            connection.Close();

            return shoppingViewList;

        }



        public int UpdateDailyShopping(Shopping shopping)
        {
            connection = new SqlConnection(connectionstr);
            connection.Open();

            query = "UPDATE DailyShopping SET ShoppingCost = '" + shopping.ShoppingCost + "' WHERE MemberID = '" +
                    shopping.MemberID + "' AND ShoppingDate = '" + shopping.ShoppingDate + "' ";

            command = new SqlCommand(query,connection);

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();
            return rowAffected;

        }

        public int DEleteShoppingItem(int ID)
        {

            connection = new SqlConnection(connectionstr);
            connection.Open();

            query = "DELETE FROM DailyShopping WHERE  ShoppingID = '" + ID + "' ";

            command= new SqlCommand(query,connection);

            int rowAffceted = command.ExecuteNonQuery();

            connection.Close();

            return rowAffceted;


        }


        public List<ShoppingView> GetShoppingReport(string date)
        {
            connection = new SqlConnection(connectionstr);
            connection.Open();

            query =
                "SELECT * FROM DailyShopping JOIN Members ON Members.MemberID = DailyShopping.MemberID WHERE  MONTH(ShoppingDate) = '" +
                date + "' ORDER By DailyShopping.ShoppingDate ";

            command = new SqlCommand(query,connection);
            reader = command.ExecuteReader();

            List<ShoppingView>  shoppingViewReport = new List<ShoppingView>();
            while (reader.Read())
            {
                ShoppingView shoppingListView = new ShoppingView();

                shoppingListView.MemberID = (int)reader["MemberID"];
                shoppingListView.MemberName = (string) reader["MemberName"];
                shoppingListView.ShoppingID = (int) reader["ShoppingID"];
                shoppingListView.ShoppingDate = (DateTime) reader["ShoppingDate"];
                shoppingListView.ShoppingCost = (int) reader["ShoppingCost"];


                shoppingViewReport.Add(shoppingListView);

            }

            reader.Close();
            connection.Close();

            return shoppingViewReport;


        }





    }
}
