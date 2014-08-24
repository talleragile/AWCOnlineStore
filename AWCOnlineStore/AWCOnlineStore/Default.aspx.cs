using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AWCOnlineStore
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cadena = "pass";
            // Customize welcome message if personalization cookie is present
            if (Request.Cookies["ASPNETCommerce_FullName"] != null)
            {
                WelcomeMsg.Text = "Welcome " + Request.Cookies["ASPNETCommerce_FullName"].Value;
            }
        }
    }
}
