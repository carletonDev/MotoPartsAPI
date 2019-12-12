using System;
using System.Collections.Generic;

namespace MotoPartsAPI.Models
{
    public partial class DirtBikes
    {
        public DirtBikes()
        {
            Parts = new HashSet<Parts>();
        }

        public int DirtBikeId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? MakeYear { get; set; }

        public virtual ICollection<Parts> Parts { get; set; }
    }
}
