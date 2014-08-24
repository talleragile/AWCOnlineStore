using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// borrar!
using System.Data;
using System.Data.SqlClient;

namespace AWC.BusinessLayer
{
    public class Orders
    {
        public List<AWC.Entities.Order> GetCustomerOrders(String customerID)
        {
            AWC.DataLayer.OrdersDB orders = new AWC.DataLayer.OrdersDB();
            return orders.GetCustomerOrders(customerID);
        }

        public AWC.Entities.Order GetOrderDetails(int orderID, string customerID)
        {
            AWC.DataLayer.OrdersDB orders = new AWC.DataLayer.OrdersDB();
            return orders.GetOrderDetails(orderID,customerID);
        }

        public int PlaceOrder(string customerID, string cartID)
        {
            AWC.DataLayer.OrdersDB orders = new AWC.DataLayer.OrdersDB();
            return orders.PlaceOrder(customerID, cartID);
        }
    }
}
