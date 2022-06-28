using System;
using System.Collections.Generic;

#nullable disable

namespace efDataBase.Models
{
    public partial class Member
    {
        public Member()
        {
        }

        public int MemberID { get; set; }
        public int OrganizationID { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string? MemberNickname { get; set; }


        public virtual Organization Organization { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
