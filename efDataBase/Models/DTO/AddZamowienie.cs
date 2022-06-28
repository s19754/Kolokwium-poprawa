using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efDataBase.Models.DTO
{
    public class AddZamowienie
    {
        public DateTime DataPrzyjecia { get; set; }
        public DateTime? DataRealizacji { get; set; }
        public string? Uwagi { get; set; }
        public IEnumerable<SomeSortOfWyrobCukierniczy> WyrobyCukiernicze { get; set; }
    }
}
