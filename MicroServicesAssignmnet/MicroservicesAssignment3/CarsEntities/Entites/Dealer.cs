﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsEntities.Entites
{
    public class Dealer
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Guid ExternalID { get; set; }
    }
}
