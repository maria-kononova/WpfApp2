using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class Stage
    {
        public Stage()
        {
            Resources = new HashSet<Resource>();
        }

        public int Id { get; set; }
        public int? Appeal { get; set; }
        public int? Employeer { get; set; }
        public DateOnly? Date { get; set; }
        public int? Status { get; set; }
        public string? Comment { get; set; }

        public virtual Appeal? AppealNavigation { get; set; }
        public virtual Employeer? EmployeerNavigation { get; set; }
        public virtual Status? StatusNavigation { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}
