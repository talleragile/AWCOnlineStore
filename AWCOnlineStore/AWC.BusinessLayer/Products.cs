using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AWC.BusinessLayer
{
    public class Products
    {
        public List<AWC.Entities.Category> GetProductCategories()
        {
            // Obtain list of menu categories and databind to list control
            AWC.DataLayer.ProductsDB products = new AWC.DataLayer.ProductsDB();
            return products.GetProductCategories();
        }

        public List<AWC.Entities.ProductDictionary> GetMostPopularProductsOfWeek()
        {
            AWC.DataLayer.ProductsDB products = new AWC.DataLayer.ProductsDB();
            return products.GetMostPopularProductsOfWeek();
        }

        public List<AWC.Entities.Product> GetProducts(int categoryID)
        {
            AWC.DataLayer.ProductsDB products = new AWC.DataLayer.ProductsDB();
            return products.GetProducts(categoryID);
        }

        public List<AWC.Entities.ProductDictionary> GetProductsAlsoPurchased(int productID)
        {
            AWC.DataLayer.ProductsDB products = new AWC.DataLayer.ProductsDB();
            return products.GetProductsAlsoPurchased(productID);
        }

        public AWC.Entities.Product GetProductDetails(int productID)
        {
            AWC.DataLayer.ProductsDB products = new AWC.DataLayer.ProductsDB();
            return products.GetProductDetails(productID);
        }

        public List<AWC.Entities.Product> SearchProductDescriptions(string searchString)
        {
            AWC.DataLayer.ProductsDB products = new AWC.DataLayer.ProductsDB();
            return products.SearchProductDescriptions(searchString);
        }
        
        
    }
}
