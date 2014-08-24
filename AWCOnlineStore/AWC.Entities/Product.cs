using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AWC.Entities
{
    public class Product
    {
        public int ProductID
        {
            get;
            set;
        }
        public string ModelName
        {
            get;
            set;
        }

        public string ModelNumber
        {
            get;
            set;
        }

        public decimal UnitCost
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string ProductImage
        {
            get;
            set;
        }
    }
}
