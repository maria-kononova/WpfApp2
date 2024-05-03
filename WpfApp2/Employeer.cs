using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class Employeer
    {
        public Employeer()
        {
            Purchases = new HashSet<Purchase>();
            Stages = new HashSet<Stage>();
        }

        public int Id { get; set; }
        public int? Post { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? User { get; set; }

        public virtual Post? PostNavigation { get; set; }
        public virtual User? UserNavigation { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Stage> Stages { get; set; }
    }
}
