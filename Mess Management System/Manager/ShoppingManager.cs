using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mess_Management_System.Gateway;
using Mess_Management_System.Model;

namespace Mess_Management_System.Manager
{
    class ShoppingManager
    {

        ShoppingGateway shoppingGateway = new ShoppingGateway();

        public string SaveDailyShopping(Shopping shopping)
        {
            int rowAffected = shoppingGateway.SaveDailyShopping(shopping);

            if (rowAffected > 0)
            {
                return "Shopping Cost Added into List Successfully ";
            }

            return " Fail to Add Shopping Cost ";
        }


        public List<ShoppingView> GetShoppinglList(string date)
        {
            return shoppingGateway.GetShoppinglList(date);

        }

        public string UpdateDailyShopping(Shopping shopping)
        {

            int rowAffected = shoppingGateway.UpdateDailyShopping(shopping);

            if (rowAffected > 0)
            {
                return "Shopping Cost Updated Successfuly ";
            }

            return " Fail to Update Shopping Cost ";
        }


        public string DEleteShoppingItem(int ID)
        {

            int rowAffected = shoppingGateway.DEleteShoppingItem(ID);

            if (rowAffected > 0)
            {
                return "Shopping Item Deleted Successfuly ";
            }

            return " Fail to Delete Shopping Item ";

        }


        public List<ShoppingView> GetShoppingReport( string date)
        {
            return shoppingGateway.GetShoppingReport(date);

        }


      

    }
}
