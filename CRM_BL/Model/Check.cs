﻿using System;
using System.Collections.Generic;

namespace CRM_BL.Model
{
    public class Check
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }

        public DateTime Created { get; set; }

        public virtual ICollection<Sell> Sells { get; set; }

        public decimal Price { get; set; }
        public override string ToString()
        {
            return $"№{Id} от {Created.ToString("dd.MM.yy hh:mm:ss")}";
        }
    }
}
