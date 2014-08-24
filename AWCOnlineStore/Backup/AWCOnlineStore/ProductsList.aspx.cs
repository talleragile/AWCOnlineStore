using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AWCOnlineStore
{
    public partial class ProductsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Obtain categoryId from QueryString
            int categoryId = Int32.Parse(Request.Params["CategoryID"]);

            // Obtain products and databind to an asp:datalist control
            AWC.BusinessLayer.Products productCatalogue = new AWC.BusinessLayer.Products();

            MyList.DataSource = productCatalogue.GetProducts(categoryId);
            MyList.DataBind();
        }
    }
}
