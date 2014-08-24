using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// borrar!
using System.Data;
using System.Data.SqlClient;

namespace AWC.BusinessLayer
{
    public class ShoppingCart
    {
        public SqlDataReader GetItems(string cartID)
        {
            AWC.DataLayer.ShoppingCartDB shoppingcart = new AWC.DataLayer.ShoppingCartDB();
            return shoppingcart.GetItems(cartID);
        }

        public String GetShoppingCartId()
        {
            AWC.DataLayer.ShoppingCartDB shoppingcart = new AWC.DataLayer.ShoppingCartDB();
            return shoppingcart.GetShoppingCartId();
        }

         public decimal GetTotal(string cartID) {
             AWC.DataLayer.ShoppingCartDB shoppingcart = new AWC.DataLayer.ShoppingCartDB();
             return shoppingcart.GetTotal(cartID);
         }

         public int GetItemCount(string cartID)
         {
             AWC.DataLayer.ShoppingCartDB shoppingcart = new AWC.DataLayer.ShoppingCartDB();
             return shoppingcart.GetItemCount(cartID);
         }

         public void AddItem(string cartID, int productID, int quantity)
         {
             AWC.DataLayer.ShoppingCartDB shoppingcart = new AWC.DataLayer.ShoppingCartDB();
             shoppingcart.AddItem(cartID,productID,quantity);
         }

         public void UpdateItem(string cartID, int productID, int quantity)
         {
             AWC.DataLayer.ShoppingCartDB shoppingcart = new AWC.DataLayer.ShoppingCartDB();
             shoppingcart.UpdateItem(cartID, productID, quantity);
         }

         public void RemoveItem(string cartID, int productID)
         {
             AWC.DataLayer.ShoppingCartDB shoppingcart = new AWC.DataLayer.ShoppingCartDB();
             shoppingcart.RemoveItem(cartID, productID);
         }

         public void MigrateCart(String oldCartId, String newCartId)
         {
             AWC.DataLayer.ShoppingCartDB shoppingcart = new AWC.DataLayer.ShoppingCartDB();
             shoppingcart.MigrateCart(oldCartId, newCartId);
         }

         public void EmptyCart(string cartID)
         {
             AWC.DataLayer.ShoppingCartDB shoppingcart = new AWC.DataLayer.ShoppingCartDB();
             shoppingcart.EmptyCart(cartID);
         }

       
    }
}
