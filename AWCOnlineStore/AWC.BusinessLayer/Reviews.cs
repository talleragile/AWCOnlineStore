using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Borrar
using System.Data;
using System.Data.SqlClient;

namespace AWC.BusinessLayer
{
    public class Reviews
    {
        public SqlDataReader GetReviews(int productID)
        {
            AWC.DataLayer.ReviewsDB productReviews = new AWC.DataLayer.ReviewsDB();
            return productReviews.GetReviews(productID);
        }

        public void AddReview(int productID, string customerName, string customerEmail, int rating, string comments)
        {
            AWC.DataLayer.ReviewsDB productReviews = new AWC.DataLayer.ReviewsDB();
            productReviews.AddReview(productID, customerName,customerEmail, rating, comments);            
        }
    }
}
