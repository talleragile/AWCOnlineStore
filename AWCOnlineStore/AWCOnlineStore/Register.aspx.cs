using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ASPNET.StarterKit.Commerce {

    public class Register : System.Web.UI.Page {

        protected System.Web.UI.WebControls.TextBox Name;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
        protected System.Web.UI.WebControls.TextBox Email;
        protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
        protected System.Web.UI.WebControls.TextBox Password;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
        protected System.Web.UI.WebControls.TextBox ConfirmPassword;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
        protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
        protected System.Web.UI.WebControls.Label MyError;
        protected System.Web.UI.WebControls.ImageButton RegisterBtn;
    
        public Register() {
            Page.Init += new System.EventHandler(Page_Init);
        }

        //*******************************************************
        //
        // The RegisterBtn_Click event handler is used on this page to
        // add a new user into the Commerce Starter Kit Customers database.
        //
        // The event handler then migrates any items stored in the user's
        // temporary (non-persistent) shopping cart to their
        // permanent customer account, adds a cookie to the client
        // (so that we can personalize the home page's welcome
        // message), and then redirects the browser back to the
        // originating page.
        //
        //*******************************************************

        private void RegisterBtn_Click(object sender, System.Web.UI.ImageClickEventArgs e) {
            // Only attempt a login if all form fields on the page are valid
            if (Page.IsValid == true) {

                // Store off old temporary shopping cart ID
                AWC.BusinessLayer.ShoppingCart shoppingCart = new AWC.BusinessLayer.ShoppingCart();
                String tempCartId = shoppingCart.GetShoppingCartId();

                // Add New Customer to CustomerDB database
                AWC.BusinessLayer.Customers accountSystem = new AWC.BusinessLayer.Customers();
                String customerId = accountSystem.AddCustomer(Name.Text, Email.Text, AWC.BusinessLayer.Security.Encrypt(Password.Text));

		    if (customerId != "") {

			    // Set the user's authentication name to the customerId
			    FormsAuthentication.SetAuthCookie(customerId, false);

			    // Migrate any existing shopping cart items into the permanent shopping cart
			    shoppingCart.MigrateCart(tempCartId, customerId);

			    // Store the user's fullname in a cookie for personalization purposes
			    Response.Cookies["ASPNETCommerce_FullName"].Value = Server.HtmlEncode(Name.Text);

			    // Redirect browser back to shopping cart page
			    Response.Redirect("ShoppingCart.aspx");
		        }
		        else {
			        MyError.Text = "Registration failed:&nbsp; That email address is already registered.<br><img align=left height=1 width=92 src=images/1x1.gif>";
		        }
            }
        }
        
        private void Page_Load(object sender, System.EventArgs e) {
            // Put user code to initialize the page here
        }

        private void Page_Init(object sender, EventArgs e) {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
        }

		#region Web Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {    
			this.RegisterBtn.Click += new System.Web.UI.ImageClickEventHandler(this.RegisterBtn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

    }
}
