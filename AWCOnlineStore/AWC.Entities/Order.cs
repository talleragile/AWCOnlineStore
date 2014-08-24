using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AWC.Entities
{
    public class Order
    {
        public int OrderID
        {
            get;
            set;
        }

        public DateTime OrderDate
        {
            get;
            set;
        }
        public DateTime ShipDate
        {
            get;
            set;
        }
        public decimal OrderTotal
        {
            get;
            set;
        }
        public DataSet OrderItems
        {
            get;
            set;
        }
    }
}
