using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class User
    {
        public User()
        {
            Clients = new HashSet<Client>();
            Employeers = new HashSet<Employeer>();
        }

        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public int? Role { get; set; }

        public virtual Role? RoleNavigation { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Employeer> Employeers { get; set; }
    }
}
