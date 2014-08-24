using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AWCOnlineStore
{
    public partial class _ReviewList : System.Web.UI.UserControl
    {
        public int ProductID;

        protected void Page_Load(object sender, EventArgs e)
        {
            MyListDataSource.SelectParameters["ProductID"].DefaultValue = ProductID.ToString();
  
            MyList.DataBind();

            AddReview.NavigateUrl = "ReviewAdd.aspx?productID=" + ProductID.ToString();
        }
    }
}