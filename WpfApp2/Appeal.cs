using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class Appeal
    {
        public Appeal()
        {
            //Appealproblems = new HashSet<Appealproblem>();
            Stages = new HashSet<Stage>();
        }

        public int Id { get; set; }
        public int? Client { get; set; }
        public int? Equipment { get; set; }
        public DateOnly? DateStart { get; set; }
        public DateOnly? DateEnd { get; set; }
        public int? Status { get; set; }
        public string?Problem  { get; set; }

        public virtual Client? ClientNavigation { get; set; }
        public virtual Equipment? EquipmentNavigation { get; set; }
        public virtual Status? StatusNavigation { get; set; }
        //public virtual ICollection<Appealproblem> Appealproblems { get; set; }
        public virtual ICollection<Stage> Stages { get; set; }

        public int returnPlusOne(int i)
        {
            return i + 1;
        }
    }
}
