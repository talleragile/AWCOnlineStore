using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AWCOnlineStore
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Obtain ProductID from QueryString
            int ProductID = Int32.Parse(Request.Params["ProductID"]);

            // Obtain Product Details
            AWC.BusinessLayer.Products products = new AWC.BusinessLayer.Products();
            AWC.Entities.Product myProductDetails = products.GetProductDetails(ProductID);

            // Update Controls with Product Details
            desc.Text = myProductDetails.Description;
            UnitCost.Text = String.Format("{0:c}", myProductDetails.UnitCost);
            ModelName.Text = myProductDetails.ModelName;
            ModelNumber.Text = myProductDetails.ModelNumber.ToString();
            ProductImage.ImageUrl = "ProductImages/" + myProductDetails.ProductImage;
            addToCart.NavigateUrl = "AddToCart.aspx?ProductID=" + ProductID;

            ReviewList.ProductID = ProductID;
            AlsoBoughtList.ProductID = ProductID;
        }
    }
}
