using System;
using System.Collections.Generic;

namespace MotoPartsAPI.Models
{
    public partial class Brands
    {
        public Brands()
        {
            Parts = new HashSet<Parts>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }

        public virtual ICollection<Parts> Parts { get; set; }
    }
}
