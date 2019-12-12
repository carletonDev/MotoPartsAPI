using System;
using System.Collections.Generic;

namespace MotoPartsAPI.Models
{
    public partial class Parts
    {
        public Parts()
        {
            Cart = new HashSet<Cart>();
        }

        public int PartId { get; set; }
        public int? DirtBikeFk { get; set; }
        public string PartName { get; set; }
        public string Picture { get; set; }
        public decimal? Price { get; set; }
        public string PartDescription { get; set; }
        public int? BrandFk { get; set; }
        public int? CategoryFk { get; set; }

        public virtual Brands BrandFkNavigation { get; set; }
        public virtual PartCategories CategoryFkNavigation { get; set; }
        public virtual DirtBikes DirtBikeFkNavigation { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
    }
}
