using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AWC.DataLayer {
        
    public class OrdersDB {

        public List<AWC.Entities.Order> GetCustomerOrders(String customerID) 
        {
         
            List<AWC.Entities.Order> list = new List<AWC.Entities.Order>();

            // Create Instance of Connection and Command Object
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand("CMRC_OrdersList", myConnection);

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure;

            // Add Parameters to SPROC
            SqlParameter parameterCustomerid = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            parameterCustomerid.Value = Int32.Parse(customerID);
            myCommand.Parameters.Add(parameterCustomerid);

            // Execute the command
            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (result.Read())
            {
                list.Add(new AWC.Entities.Order() { 
                    OrderID=result.GetInt32(0),
                    OrderTotal = result.GetDecimal(1),
                    OrderDate = result.GetDateTime(2),
                    ShipDate = result.GetDateTime(3)
                });
            }
            return list;
        }

        public AWC.Entities.Order GetOrderDetails(int orderID, string customerID) 
        {
            // Create Instance of Connection and Command Object
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlDataAdapter myCommand = new SqlDataAdapter("CMRC_OrdersDetail", myConnection);

            // Mark the Command as a SPROC
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            // Add Parameters to SPROC
            SqlParameter parameterOrderID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
            parameterOrderID.Value = orderID;
            myCommand.SelectCommand.Parameters.Add(parameterOrderID);

            SqlParameter parameterCustomerID = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            parameterCustomerID.Value = Int32.Parse(customerID);
            myCommand.SelectCommand.Parameters.Add(parameterCustomerID);

            SqlParameter parameterOrderDate = new SqlParameter("@OrderDate", SqlDbType.DateTime, 8);
            parameterOrderDate.Direction = ParameterDirection.Output;
            myCommand.SelectCommand.Parameters.Add(parameterOrderDate);

            SqlParameter parameterShipDate = new SqlParameter("@ShipDate", SqlDbType.DateTime, 8);
            parameterShipDate.Direction = ParameterDirection.Output;
            myCommand.SelectCommand.Parameters.Add(parameterShipDate);

            SqlParameter parameterOrderTotal = new SqlParameter("@OrderTotal", SqlDbType.Money, 8);
            parameterOrderTotal.Direction = ParameterDirection.Output;
            myCommand.SelectCommand.Parameters.Add(parameterOrderTotal);

            // Create and Fill the DataSet
            DataSet myDataSet = new DataSet();
            myCommand.Fill(myDataSet, "OrderItems");
            
            // ship date is null if order doesn't exist, or belongs to a different user
            if (parameterShipDate.Value != DBNull.Value) {
            
                // Create and Populate OrderDetails Struct using
                // Output Params from the SPROC, as well as the
                // populated dataset from the SqlDataAdapter

                AWC.Entities.Order myOrderDetails = new AWC.Entities.Order();

                myOrderDetails.OrderDate = (DateTime)parameterOrderDate.Value;
                myOrderDetails.ShipDate = (DateTime)parameterShipDate.Value;
                myOrderDetails.OrderTotal = (decimal)parameterOrderTotal.Value;
                myOrderDetails.OrderItems = myDataSet;

                // Return the DataSet
                return myOrderDetails;
            }
            else
                return null;
        }

        public int PlaceOrder(string customerID, string cartID) 
        {
            // Create Instance of Connection and Command Object
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand("CMRC_OrdersAdd", myConnection);

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure;

            // Add Parameters to SPROC
            SqlParameter parameterCustomerID = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            parameterCustomerID.Value = Int32.Parse(customerID);
            myCommand.Parameters.Add(parameterCustomerID);

            SqlParameter parameterCartID = new SqlParameter("@CartID", SqlDbType.NVarChar, 50);
            parameterCartID.Value = cartID;
            myCommand.Parameters.Add(parameterCartID);

            SqlParameter parameterShipDate = new SqlParameter("@ShipDate", SqlDbType.DateTime, 8);
            parameterShipDate.Value = CalculateShippingDate(customerID, cartID);
            myCommand.Parameters.Add(parameterShipDate);

            SqlParameter parameterOrderDate = new SqlParameter("@OrderDate", SqlDbType.DateTime, 8);
            parameterOrderDate.Value = DateTime.Now;
            myCommand.Parameters.Add(parameterOrderDate);

            SqlParameter parameterOrderID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
            parameterOrderID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterOrderID);

            // Open the connection and execute the Command
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            // Return the OrderID
            return (int)parameterOrderID.Value;
        }

        public DateTime CalculateShippingDate(String customerID, string cartID)
        {
            Random x = new Random();
            double myrandom = (double)x.Next(0, 3);
            return DateTime.Now.AddDays(myrandom);
        }

    }
}

