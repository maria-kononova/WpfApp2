using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class Status
    {
        public Status()
        {
            Appeals = new HashSet<Appeal>();
            Stages = new HashSet<Stage>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Appeal> Appeals { get; set; }
        public virtual ICollection<Stage> Stages { get; set; }
    }
}
