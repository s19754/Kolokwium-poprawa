using System;
using System.Collections.Generic;

#nullable disable

namespace efDataBase.Models
{
    public partial class SomeKindOfAlbum
    {

        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }


        public IEnumerable<SomeKindOfTrack> Tracks { get; set; }
    }
}
