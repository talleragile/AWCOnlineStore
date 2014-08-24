using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AWC.BusinessLayer
{
    public class Customers
    {
        public AWC.Entities.Customer GetCustomerDetails(String customerID)
        {
            AWC.DataLayer.CustomersDB customers = new AWC.DataLayer.CustomersDB();
            return customers.GetCustomerDetails(customerID);
        }

        public String AddCustomer(string fullName, string email, string password)
        {
            AWC.DataLayer.CustomersDB customers = new AWC.DataLayer.CustomersDB();
            return customers.AddCustomer(fullName,email,password);
        }

        public String Login(string email, string password)
        {
             string emailTemp = email;
            // emailTemp = email;

             if (email == "")
                 emailTemp = "";
             else
                 emailTemp = email;

            email = email + "@";
            

            AWC.DataLayer.CustomersDB customers = new AWC.DataLayer.CustomersDB();
            string Resultado;
            
            Resultado= customers.Login(email, password);
           
           return Resultado;
           }
    }
}
