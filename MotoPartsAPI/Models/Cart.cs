using System;
using System.Collections.Generic;

namespace MotoPartsAPI.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int? UserFk { get; set; }
        public int? PartFk { get; set; }
        public int? Quantity { get; set; }
        public DateTime? TransactionDate { get; set; }

        public virtual Parts PartFkNavigation { get; set; }
        public virtual Users UserFkNavigation { get; set; }
    }
}
