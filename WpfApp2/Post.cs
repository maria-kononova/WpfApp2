using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class Post
    {
        public Post()
        {
            Employeers = new HashSet<Employeer>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Employeer> Employeers { get; set; }
    }
}
