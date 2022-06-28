using System;
using System.Collections.Generic;

#nullable disable

namespace efDataBase.Models
{
    public partial class File
    {
        public File()
        {
        }

        public int FileID { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int FileSize { get; set; }
        public int TeamID { get; set; }



        public virtual Team Team { get; set; }
    }
}
