using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class Equipment
    {
        public Equipment()
        {
            Appeals = new HashSet<Appeal>();
        }

        public int Id { get; set; }
        public string? SerialNumber { get; set; }
        public int? Type { get; set; }

        public virtual Typequipment? TypeNavigation { get; set; }
        public virtual ICollection<Appeal> Appeals { get; set; }
    }
}
