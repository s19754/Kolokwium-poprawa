using System;
using System.Collections.Generic;

#nullable disable

namespace efDataBase.Models
{
    public partial class Membership
    {
        public int TeamID { get; set; }
        public int MemberID { get; set; }
        public DateTime MembershipDate { get; set; }

        public virtual Team Team { get; set; }
        public virtual Member Member { get; set; }
    }
}
