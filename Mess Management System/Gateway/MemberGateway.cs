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
    class MemberGateway
    {

        private string connectionstr = ConfigurationManager.ConnectionStrings["MealManagement"].ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private string query;


        public int SaveMembers(Member member)
        {
           connection = new SqlConnection(connectionstr);
           connection.Open();

           query = " INSERT INTO Members ( MemberName, MemberEmail, MemberPhone ) VALUES( '" + member.MemberName + "' , '" + member.MemberEmail + "', '" + member.MemberPhone + "' ) ";

           command = new SqlCommand(query,connection);

           int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;

        }


        public bool isMemberExist(Member member)
        {
            
            connection= new SqlConnection(connectionstr);
            connection.Open();

            query = " SELECT * FROM Members WHERE MemberEmail = '" + member.MemberEmail + "' OR MemberPhone = '"+member.MemberPhone+"' ";

            command = new SqlCommand(query,connection);
            reader = command.ExecuteReader();

            bool isExist = reader.HasRows;
            reader.Close();
            connection.Close();

            return isExist;


        }

        public List<Member> getMember()
        {
            connection = new SqlConnection(connectionstr);
            connection.Open();

            query = " SELECT * FROM Members ";

            command = new SqlCommand(query,connection);

            reader = command.ExecuteReader();

            List<Member> members = new List<Member>();
            while (reader.Read())
            {
                Member member = new Member();
                member.MemberID = (int) reader["MemberID"];
                member.MemberName = reader["MemberName"].ToString();
                member.MemberEmail = reader["MemberEmail"].ToString();
                member.MemberPhone = reader["MemberPhone"].ToString();

                members.Add(member);

            }

            reader.Close();
            connection.Close();

            return members;
        }

        public int UpdateMember(Member member)
        {
            
            connection = new SqlConnection(connectionstr);
            connection.Open();

            query = " UPDATE Members SET MemberName = '" + member.MemberName + "', MemberEmail = '" + member.MemberEmail + "', MemberPhone = '"+member.MemberPhone+"'  ";

            command = new SqlCommand(query,connection);

            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }


        public int DeleteMember(int id )
        {
            connection = new SqlConnection(connectionstr);
            connection.Open();

            query = "DELETE  FROM Members WHERE  MemberID = '" +id+ "' ";

            command = new SqlCommand(query,connection);

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;



        }
            



    }
}
