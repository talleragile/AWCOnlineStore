using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AWCOnlineStore
{
    public partial class _Menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Set the curent selection of list
            String selectionId = Request.Params["selection"];

            if (selectionId != null)
            {
                MyList.SelectedIndex = Int32.Parse(selectionId);
            }            
        }
    }
}