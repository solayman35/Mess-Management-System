using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Mess_Management_System.Gateway;
using Mess_Management_System.Model;

namespace Mess_Management_System.Manager
{
    class DepositManager
    {

        DepositGateway depositGateway = new DepositGateway();

        public string saveDepositAmount(Deposit deposit)
        {
            int rowAffected = depositGateway.saveDepositAmount(deposit);

            if (rowAffected > 0)
            {
                return "Deposit Successfully";
            }

            return "Deposit Failed ! ";
        }


        public List<DepositView> GetDeposiitList(string date)
        {

            return depositGateway.GetDeposiitList(date);

        }


        public string GetDepositUpdate(Deposit deposit)
        {

            int rowAffected = depositGateway.GetDepositUpdate(deposit);

            if (rowAffected > 0)
            {
                return "UPADATE Successfully";
            }

            return "UPADATE Failed!";
        }


        public string DeleteDeposit(int id)
        {
            int rowAffected = depositGateway.DeleteDeposit(id);

            if (rowAffected > 0)
            {
                return "Delete Deposit Successfully";
            }
            return "Delete Deposit Failed!";

        }


        public List<DepositView> DepositReportList(int id, string date)
        {

            return depositGateway.DepositReportList(id,date);
        }



        public List<DepositView> DepositAmountPerPerson(int id, string date)
        {
            return depositGateway.DepositAmountPerPerson(id, date);
        }



    }
}
