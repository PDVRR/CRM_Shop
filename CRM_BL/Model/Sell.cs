﻿namespace CRM_BL.Model
{
    public class Sell
    {
        public int Id { get; set; }
        public int CheckId { get; set; }
        public int ProductId { get; set; }

        public virtual Check Check { get; set; }

        public virtual Product Product { get; set; }
    }
}
