using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class Resource
    {
        public int Stage { get; set; }
        public int Material { get; set; }
        public string? Count { get; set; }

        public virtual Material MaterialNavigation { get; set; } = null!;
        public virtual Stage StageNavigation { get; set; } = null!;
    }
}
