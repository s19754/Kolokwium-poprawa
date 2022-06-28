using System;
using System.Collections.Generic;

#nullable disable

namespace efDataBase.Models
{
    public partial class Organization
    {
        public Organization()
        {
        }

        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationDomain { get; set; }


        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
