using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileHelpers;

namespace TurmixBatch
{
    [DelimitedRecord(";")]
    public class TenykobRecord
    {
        
        public string FhKod;
        public string Vonalkod;
        public string Szamla;
        public int SzamlaOsszeg;
        public int Mennyiseg;
        public string Terulet;

        [FieldConverter(ConverterKind.Decimal, ",")]
        public decimal Tamogatas;

        public string Ceg;

        public string Datum;

        public int Alapdij;

        public string AlapdijKezdet;
        public string AlapdijVeg;

        [FieldConverter(ConverterKind.Decimal, ",")]
        public decimal Megtakaritas;

        public string Sofor;
        public string Rendszam;

    }
}
