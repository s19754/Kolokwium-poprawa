using System;
using System.Collections.Generic;

#nullable disable

namespace efDataBase.Models
{
    public partial class SomeSortOfZamowienieWyrobCukierniczy
    {

        public string Nazwa { get; set; }
        public float CenaZaSzt { get; set; }
        public string Typ { get; set; }
        public int Ilosc { get; set; }
        public string? Uwagi { get; set; }

    }
}
