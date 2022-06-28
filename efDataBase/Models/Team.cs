using System;
using System.Collections.Generic;

#nullable disable

namespace efDataBase.Models
{
    public partial class Team
    {
        public Team()
        {
            Memberships = new List<Membership>();
        }

        public int TeamID { get; set; }
        public int OrganizationID { get; set; }
        public string TeamName { get; set; }
        public string? TeamDescription { get; set; }

        public virtual ICollection<Membership> Memberships { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
