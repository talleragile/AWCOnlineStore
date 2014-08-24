using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AWCOnlineStore
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Populate the shopping cart the first time the page is accessed.
            if (Page.IsPostBack == false)
            {
                PopulateShoppingCartList();
            }
        }

        protected void UpdateBtn_Click(object sender, ImageClickEventArgs e)
        {
            // Update the Shopping Cart and then Repopulate the List
            UpdateShoppingCartDatabase();
            PopulateShoppingCartList();
        }

        protected void CheckoutBtn_Click(object sender, ImageClickEventArgs e)
        {

            // Update Shopping Cart
            UpdateShoppingCartDatabase();

            // If cart is not empty, proceed on to checkout page
            AWC.BusinessLayer.ShoppingCart cart = new AWC.BusinessLayer.ShoppingCart();

            // Calculate shopping cart ID
            String cartId = cart.GetShoppingCartId();

            // If the cart isn't empty, navigate to checkout page
            if (cart.GetItemCount(cartId) != 0)
            {
                Response.Redirect("Checkout.aspx");
            }
            else
            {
                MyError.Text = "You can't proceed to the Check Out page with an empty cart.";
            }
        }

        void PopulateShoppingCartList()
        {

            AWC.BusinessLayer.ShoppingCart cart = new AWC.BusinessLayer.ShoppingCart();

            // Obtain current user's shopping cart ID
            String cartId = cart.GetShoppingCartId();

            // If no items, hide details and display message
            if (cart.GetItemCount(cartId) == 0)
            {
                DetailsPanel.Visible = false;
                MyError.Text = "There are currently no items in your shopping cart.";
            }
            else
            {

                // Databind Gridcontrol with Shopping Cart Items
                MyList.DataSource = cart.GetItems(cartId);
                MyList.DataBind();

                //Update Total Price Label
                lblTotal.Text = String.Format("{0:c}", cart.GetTotal(cartId));
            }
        }

        void UpdateShoppingCartDatabase()
        {

            AWC.BusinessLayer.ShoppingCart cart = new AWC.BusinessLayer.ShoppingCart();

            // Obtain current user's shopping cart ID
            String cartId = cart.GetShoppingCartId();

            // Iterate through all rows within shopping cart list
            for (int i = 0; i < MyList.Items.Count; i++)
            {

                // Obtain references to row's controls
                TextBox quantityTxt = (TextBox)MyList.Items[i].FindControl("Quantity");
                CheckBox remove = (CheckBox)MyList.Items[i].FindControl("Remove");

                // Wrap in try/catch block to catch errors in the event that someone types in
                // an invalid value for quantity
                int quantity;
                try
                {
                    quantity = Int32.Parse(quantityTxt.Text);

                    // If the quantity field is changed or delete is checked
                    if (quantity != (int)MyList.DataKeys[i] || remove.Checked == true)
                    {

                        Label lblProductID = (Label)MyList.Items[i].FindControl("ProductID");

                        if (quantity == 0 || remove.Checked == true)
                        {
                            cart.RemoveItem(cartId, Int32.Parse(lblProductID.Text));
                        }
                        else
                        {
                            cart.UpdateItem(cartId, Int32.Parse(lblProductID.Text), quantity);
                        }
                    }
                }
                catch
                {
                    MyError.Text = "There has been a problem with one or more of your inputs.";
                }
            }
        }



    }
}
