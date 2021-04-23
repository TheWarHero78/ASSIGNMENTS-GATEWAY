using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment8.Test
{
    public class OrderedTestAttribute : Attribute
    {
        public int Order { get; set; }


        public OrderedTestAttribute(int order)
        {
            Order = order;
        }
    }
}
