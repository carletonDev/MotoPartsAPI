using System;
using System.Collections.Generic;

namespace MotoPartsAPI.Models
{
    public partial class PartCategories
    {
        public PartCategories()
        {
            Parts = new HashSet<Parts>();
        }

        public int CategoryId { get; set; }
        public string PartCategory { get; set; }

        public virtual ICollection<Parts> Parts { get; set; }
    }
}
