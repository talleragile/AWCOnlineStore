using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AWC.DataLayer {

    public class ProductsDB {
        
        public List<AWC.Entities.Category> GetProductCategories()
        {
            List<AWC.Entities.Category> list = new List<AWC.Entities.Category>();
            // Create Instance of Connection and Command Object
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand("CMRC_ProductCategoryList", myConnection);

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure;

            // Execute the command
            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (result.Read())
            {
                list.Add(new AWC.Entities.Category(){CategoryID=result.GetInt32(0),CategoryName=result.GetString(1)});
            }
            // Return the datareader result
            return list;
        }

        public List<AWC.Entities.Product> GetProducts(int categoryID)
        {
            List<AWC.Entities.Product> list = new List<AWC.Entities.Product>();

            // Create Instance of Connection and Command Object
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand("CMRC_ProductsByCategory", myConnection);

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure;

            // Add Parameters to SPROC
            SqlParameter parameterCategoryID = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
            parameterCategoryID.Value = categoryID;
            myCommand.Parameters.Add(parameterCategoryID);

            // Execute the command
            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (result.Read())
            {
                list.Add(new AWC.Entities.Product() {
                    ProductID = result.GetInt32(0), ModelName = result.GetString(1), UnitCost=result.GetDecimal(2), ProductImage=result.GetString(3)});
            }
            // Return the datareader result
            return list;
        }

        public AWC.Entities.Product GetProductDetails(int productID) {

            // Create Instance of Connection and Command Object
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand("CMRC_ProductDetail", myConnection);

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure;

            // Add Parameters to SPROC
            SqlParameter parameterProductID = new SqlParameter("@ProductID", SqlDbType.Int, 4);
            parameterProductID.Value = productID;
            myCommand.Parameters.Add(parameterProductID);

            SqlParameter parameterUnitCost = new SqlParameter("@UnitCost", SqlDbType.Money, 8);
            parameterUnitCost.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterUnitCost);

            SqlParameter parameterModelNumber = new SqlParameter("@ModelNumber", SqlDbType.NVarChar, 50);
            parameterModelNumber.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterModelNumber);

            SqlParameter parameterModelName = new SqlParameter("@ModelName", SqlDbType.NVarChar, 50);
            parameterModelName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterModelName);

            SqlParameter parameterProductImage = new SqlParameter("@ProductImage", SqlDbType.NVarChar, 50);
            parameterProductImage.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterProductImage);

            SqlParameter parameterDescription = new SqlParameter("@Description", SqlDbType.NVarChar, 3800);
            parameterDescription.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterDescription);

            // Open the connection and execute the Command
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            // Create and Populate ProductDetails Struct using
            // Output Params from the SPROC
            AWC.Entities.Product myProductDetails = new AWC.Entities.Product();

            myProductDetails.ModelNumber = (string)parameterModelNumber.Value;
            myProductDetails.ModelName = (string)parameterModelName.Value;
            myProductDetails.ProductImage = ((string)parameterProductImage.Value).Trim();
            myProductDetails.UnitCost = (decimal)parameterUnitCost.Value;
            myProductDetails.Description = ((string)parameterDescription.Value).Trim();

            return myProductDetails;
        }

        public List<AWC.Entities.ProductDictionary> GetProductsAlsoPurchased(int productID)
        {
            List<AWC.Entities.ProductDictionary> list = new List<AWC.Entities.ProductDictionary>();

            // Create Instance of Connection and Command Object
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand("CMRC_CustomerAlsoBought", myConnection);

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure;

            // Add Parameters to SPROC
            SqlParameter parameterProductID = new SqlParameter("@ProductID", SqlDbType.Int, 4);
            parameterProductID.Value = productID;
            myCommand.Parameters.Add(parameterProductID);

            // Execute the command
            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (result.Read())
            {
                list.Add(new AWC.Entities.ProductDictionary() { ProductId = result.GetInt32(0), ModelName = result.GetString(1) });
            }
            // Return the datareader result
            return list;

        }

        public List<AWC.Entities.ProductDictionary> GetMostPopularProductsOfWeek()
        {
            List<AWC.Entities.ProductDictionary> list = new List<AWC.Entities.ProductDictionary>();

            // Create Instance of Connection and Command Object
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand("CMRC_ProductsMostPopular", myConnection);

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure;

            // Execute the command
            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (result.Read())
            {
                list.Add(new AWC.Entities.ProductDictionary(){ProductId=result.GetInt32(0),ModelName=result.GetString(2)});
            }
            
            return list;
        }

        public List<AWC.Entities.Product> SearchProductDescriptions(string searchString)
        {
            List<AWC.Entities.Product> list = new List<AWC.Entities.Product>();

            // Create Instance of Connection and Command Object
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand("CMRC_ProductSearch", myConnection);

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure;

            // Add Parameters to SPROC
            SqlParameter parameterSearch = new SqlParameter("@Search", SqlDbType.NVarChar, 255);
            parameterSearch.Value = searchString;
            myCommand.Parameters.Add(parameterSearch);

            // Execute the command
            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (result.Read())
            {
                list.Add(new AWC.Entities.Product()
                {
                    ProductID = result.GetInt32(0),
                    ModelName = result.GetString(1),
                    ModelNumber = result.GetString(2),
                    UnitCost = result.GetDecimal(3),
                    ProductImage = result.GetString(4)
                });
            }
            // Return the datareader result
            return list;
        }
    }
}