using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment8.Test
{
    /// <summary>
    /// Class for creating a custom order attribute by extending Attribute class
    /// </summary>
    public class OrderedTestAttribute : Attribute
    {
        public int Order { get; set; }


        public OrderedTestAttribute(int order)
        {
            Order = order;
        }
    }
}
