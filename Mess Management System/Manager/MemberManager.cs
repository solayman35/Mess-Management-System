using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mess_Management_System.Gateway;
using Mess_Management_System.Model;

namespace Mess_Management_System.Manager
{
    class MemberManager
    {

        MemberGateway memberGateway = new MemberGateway();

        public string SaveMembers(Member member)
        {
            bool isExist = memberGateway.isMemberExist(member);
            if (isExist)
            {
                return " Email or Phone Number Already Exist! ";
            }


            int rowAffected = memberGateway.SaveMembers(member);


            if (rowAffected > 0)
            {
                return "Member Add Successfully ";
            }
            return "Member Add Failed! ";
        }


        public List<Member> getMember()
        {

            return memberGateway.getMember();

        }

        public string UpdateMember(Member member)
        {

            int rowAffected = memberGateway.UpdateMember(member);

            if (rowAffected > 0)
            {
                return " Update Successfully";
            }
            return "Update to Failed";
        }


        public string DeleteMember(int id)
        {
            int rowAffected = memberGateway.DeleteMember(id);

            if (rowAffected > 0)
            {
                return " Delete Successfully";
            }
            return "Failed to Delete ! ";
        }




    }
} 
