using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AWCOnlineStore
{
    public partial class _AlsoBought : System.Web.UI.UserControl
    {
        public int ProductID;

        protected void Page_Load(object sender, EventArgs e)
        {
            alsoBoughtDataSource.SelectParameters["productID"].DefaultValue = ProductID.ToString();
            
            alsoBoughtList.DataBind();

            // Hide the list if no items are in it
            if (alsoBoughtList.Items.Count == 0)
            {
                alsoBoughtList.Visible = false;
            }

        }
    }
}