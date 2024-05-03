using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class Purchase
    {
        public int Id { get; set; }
        public int? Material { get; set; }
        public int? Count { get; set; }
        public DateOnly? Date { get; set; }
        public int? Employeer { get; set; }

        public virtual Employeer? EmployeerNavigation { get; set; }
        public virtual Material? MaterialNavigation { get; set; }
    }
}
