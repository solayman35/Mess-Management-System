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
    class DepositGateway
    {

        private string connectionstr = ConfigurationManager.ConnectionStrings["MealManagement"].ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private string query;



        public int saveDepositAmount(Deposit deposit)
        {
            
            connection = new SqlConnection(connectionstr);
            connection.Open();

            query = "INSERT INTO Deposits ( MemberID, DepositAmount, DepositDate) VALUES( '" + deposit.MemberID + "', '" + deposit.DepositAmount + "', '" + deposit.DepositDate + "') ";

            command = new SqlCommand(query,connection);

            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;

        }


        public List<DepositView> GetDeposiitList(string date)
        {
            connection = new SqlConnection(connectionstr);
            connection.Open();

            query = "SELECT * FROM Deposits JOIN  Members ON Deposits.MemberID= Members.MemberID WHERE MONTH(DepositDate) = '" + date + "' order by Members.MemberName ";
       
            command= new SqlCommand(query,connection);

            reader = command.ExecuteReader();

            List<DepositView> depositList = new List<DepositView>();

            while (reader.Read())
            {
                DepositView deposits = new DepositView();

                deposits.DepositAmount = (int)reader["DepositAmount"];
                deposits.MemberName = (string)reader["MemberName"];
                deposits.DepositDate = (DateTime) reader["DepositDate"];
                deposits.DepositID = (int) reader["DepositID"];
                deposits.MemberID = (int)reader["MemberID"];

                depositList.Add(deposits);
            }

            reader.Close();
            connection.Close();

            return depositList;

        }


        public int GetDepositUpdate(Deposit deposit)
        {
            connection = new SqlConnection(connectionstr);
            connection.Open();

            query = " UPDATE Deposits SET DepositAmount = '" + deposit.DepositAmount + "'  WHERE MemberID = '" + deposit.MemberID + "' AND DepositDate = '"+deposit.DepositDate+"' ";

            command = new SqlCommand(query,connection);

            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;

        }

        public int DeleteDeposit(int id)
        {
            connection= new SqlConnection(connectionstr);
            connection.Open();

            query = "DELETE FROM Deposits WHERE DepositID = '" + id + "' ";

            command = new SqlCommand(query,connection);

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;

        }



        public List<DepositView> DepositReportList( int id, string date)
        {
            
            connection = new SqlConnection(connectionstr);
            connection.Open();

            query =
                "SELECT * FROM  Deposits JOIN Members ON Members.MemberID = Deposits.MemberID  WHERE Members.MemberID = '" +
                id + "'  AND MONTH(DepositDate) = '" + date + "' ORDER BY  Members.MemberName  ";

            command = new SqlCommand(query,connection);
            reader = command.ExecuteReader();

            List<DepositView> depositView = new List<DepositView>();
            while (reader.Read())
            {
                DepositView itemView = new DepositView();

                
                itemView.MemberName = (string) reader["MemberName"];          
                itemView.DepositAmount = (int) reader["DepositAmount"];
                itemView.DepositID = (int) reader["DepositID"];
                itemView.MemberID = (int) reader["MemberID"];
                itemView.DepositDate = (DateTime)reader["DepositDate"];

                depositView.Add(itemView);

            }
            reader.Close();
            connection.Close();

            return depositView;

        }


        public List<DepositView> DepositAmountPerPerson(int id, string date)
        {

            connection = new SqlConnection(connectionstr);
            connection.Open();

            query =
                "SELECT sum(Deposits.DepositAmount) as DepositAmount FROM  Deposits JOIN Members ON Members.MemberID = Deposits.MemberID  WHERE Members.MemberID = '" +
                id + "'  AND MONTH(DepositDate) = '" + date + "' ";

            command = new SqlCommand(query, connection);
            reader = command.ExecuteReader();

            List<DepositView> depositView = new List<DepositView>();
            while (reader.Read())
            {
                DepositView itemView = new DepositView();


        //        itemView.MemberName = (string)reader["MemberName"];
                itemView.DepositAmount = (int)reader["DepositAmount"];
      //          itemView.DepositID = (int)reader["DepositID"];
       //         itemView.MemberID = (int)reader["MemberID"];
          //      itemView.DepositDate = (DateTime)reader["DepositDate"];

                depositView.Add(itemView);

            }
            reader.Close();
            connection.Close();

            return depositView;

        } 






    }
}
