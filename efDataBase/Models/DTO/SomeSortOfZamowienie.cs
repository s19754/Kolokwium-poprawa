using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efDataBase.Models.DTO
{
    public class SomeSortOfZamowienie
    {
        public DateTime DataPrzyjecia { get; set; }
        public DateTime? DataRealizacji { get; set; }
        public string? Uwagi { get; set; }
        public SomeSortOfOsoba Klient { get; set; }
        public SomeSortOfOsoba Pracownik { get; set; }
        public IEnumerable<SomeSortOfZamowienieWyrobCukierniczy> WyrobyCukiernicze { get; set; }
    }
}
