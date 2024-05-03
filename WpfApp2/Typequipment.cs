using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class Typequipment
    {
        public Typequipment()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
