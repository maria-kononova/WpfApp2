using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class Client
    {
        public Client()
        {
            Appeals = new HashSet<Appeal>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateOnly? DateBrithday { get; set; }
        public int? User { get; set; }

        public virtual User? UserNavigation { get; set; }
        public virtual ICollection<Appeal> Appeals { get; set; }
    }
}
