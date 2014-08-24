using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AWC.DataLayer {
  
    public class CustomersDB {

  
        public AWC.Entities.Customer GetCustomerDetails(String customerID) 
        {
            // Create Instance of Connection and Command Object            
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            
            SqlCommand myCommand = new SqlCommand("CMRC_CustomerDetail", myConnection);

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure;

            // Add Parameters to SPROC
            SqlParameter parameterCustomerID = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            parameterCustomerID.Value = Int32.Parse(customerID);
            myCommand.Parameters.Add(parameterCustomerID);

            SqlParameter parameterFullName = new SqlParameter("@FullName", SqlDbType.NVarChar, 50);
            parameterFullName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterFullName);

            SqlParameter parameterEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
            parameterEmail.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterEmail);

            SqlParameter parameterPassword = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            parameterPassword.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterPassword);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            // Create CustomerDetails Struct
            AWC.Entities.Customer myCustomerDetails = new AWC.Entities.Customer();

            // Populate Struct using Output Params from SPROC
            myCustomerDetails.FullName = (string)parameterFullName.Value;
            myCustomerDetails.Password = (string)parameterPassword.Value;
            myCustomerDetails.Email = (string)parameterEmail.Value;

            return myCustomerDetails;
        }

          public String AddCustomer(string fullName, string email, string password) 
        {

            // Create Instance of Connection and Command Object
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand("CMRC_CustomerAdd", myConnection);

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure;

            // Add Parameters to SPROC
            SqlParameter parameterFullName = new SqlParameter("@FullName", SqlDbType.NVarChar, 50);
            parameterFullName.Value = fullName;
            myCommand.Parameters.Add(parameterFullName);

            SqlParameter parameterEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
            parameterEmail.Value = email;
            myCommand.Parameters.Add(parameterEmail);

            SqlParameter parameterPassword = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            parameterPassword.Value = password;
            myCommand.Parameters.Add(parameterPassword);

            SqlParameter parameterCustomerID = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            parameterCustomerID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterCustomerID);

            try {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();

                // Calculate the CustomerID using Output Param from SPROC
                int customerId = (int)parameterCustomerID.Value;

                return customerId.ToString();
            }
            catch {
                return String.Empty;
            }
        }

          public String Login(string email, string password) 
        {

            // Create Instance of Connection and Command Object
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand("CMRC_CustomerLogin", myConnection);

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure;

            // Add Parameters to SPROC
            SqlParameter parameterEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
            parameterEmail.Value = email;
            myCommand.Parameters.Add(parameterEmail);

            SqlParameter parameterPassword = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            parameterPassword.Value = password;
            myCommand.Parameters.Add(parameterPassword);

            SqlParameter parameterCustomerID = new SqlParameter("@CustomerID", SqlDbType.Int, 4);
            parameterCustomerID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterCustomerID);

            // Open the connection and execute the Command
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            int customerId = (int)(parameterCustomerID.Value);

            if (customerId == 0)
            {
                return null;
            }
            else
            {
                return customerId.ToString();
            }


                     
        }
    }
}

