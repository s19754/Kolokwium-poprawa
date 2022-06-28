using System;
using System.Collections.Generic;

#nullable disable

namespace efDataBase.Models
{
    public partial class SomeKindOfMusician
    {
        public SomeKindOfMusician()
        {
 
        }


        public virtual Member Track { get; set; }
    }
}
