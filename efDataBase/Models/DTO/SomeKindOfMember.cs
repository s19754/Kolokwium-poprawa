using System;
using System.Collections.Generic;

#nullable disable

namespace efDataBase.Models
{
    public partial class SomeKindOfMember
    {
        public SomeKindOfMember()
        {
        }

        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string? MemberNickname { get; set; }
        public SomeKindOfMembership MembershipDate { get; set; }

    }
}
