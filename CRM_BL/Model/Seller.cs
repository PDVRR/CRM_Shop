using System;
using System.Collections.Generic;

namespace CRM_BL.Model
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Check> Checks { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
