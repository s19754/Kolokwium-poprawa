using System;
using System.Collections.Generic;

#nullable disable

namespace efDataBase.Models
{
    public partial class SomeKindOfTeam
    {
        public SomeKindOfTeam()
        {
        }

        public string TeamName { get; set; }
        public string? TeamDescription { get; set; }
        public SomeKindOfOrganization Organization { get; set; }

    }
}
