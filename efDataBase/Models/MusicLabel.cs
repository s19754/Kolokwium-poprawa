using System;
using System.Collections.Generic;

#nullable disable

namespace efDataBase.Models
{
    public partial class MusicLabel
    {
        public MusicLabel()
        {
        }

        public int IdMusicLabel { get; set; }
        public string Name { get; set; }


        public virtual ICollection<Album> Albums { get; set; }
    }
}
