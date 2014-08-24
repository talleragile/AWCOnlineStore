using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AWCOnlineStore
{
    public partial class _PopularItems : System.Web.UI.UserControl
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            productList.DataBind();
            
            if (productList.Items.Count == 0)
            {
                productList.Visible = false;
            }
        }      
      
    }
}