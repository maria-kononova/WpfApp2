using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class Material
    {
        public Material()
        {
            Purchases = new HashSet<Purchase>();
            Resources = new HashSet<Resource>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Cost { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}
