using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AWCOnlineStore
{
    public partial class ReviewAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack != true)
            {

                // Obtain ProductID of Product to Review
                int productID = Int32.Parse(Request["productID"]);

                // Populate Product Name on Page
                AWC.BusinessLayer.Products products = new AWC.BusinessLayer.Products();
                ModelName.Text = products.GetProductDetails(productID).ModelName;

                // Store ProductID in Page State to use on PostBack
                ViewState["productID"] = productID;
            }
        }

        protected void ReviewAddBtn_Click(object sender, ImageClickEventArgs e)
        {
            // Only add the review if all fields on the page are valid
            if (Page.IsValid == true)
            {

                // Obtain ProductID from Page State
                int productID = (int)ViewState["productID"];

                // Obtain Rating number of RadioButtonList
                int rating = Int32.Parse(Rating.SelectedItem.Value);

                // Add Review to ReviewsDB.  HtmlEncode before entry
                AWC.BusinessLayer.Reviews review = new AWC.BusinessLayer.Reviews();
                review.AddReview(productID, Server.HtmlEncode(Name.Text), Server.HtmlEncode(Email.Text), rating, Server.HtmlEncode(Comment.Text));

                // Redirect client back to the originating product details page
                Response.Redirect("ProductDetails.aspx?ProductID=" + productID);
            }
        }
    }
}
