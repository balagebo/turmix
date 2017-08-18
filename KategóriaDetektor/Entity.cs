using System;
using System.Text.RegularExpressions;

namespace KategóriaDetektor
{
    public class Entity
    {

        private string fkod;

        public string Fkod
        {
            get { return fkod; }
            set { fkod = value; }
        }

        private UInt16 irSzam;

        public UInt16 IranyitoSzam
        {
            get { return irSzam; }
            set { irSzam = value; }
        }

        private string utca;

        public string Utca
        {
            get { return utca; }
            set { 
                utca = value.ToUpper().TrimEnd('.'); 
                
            }
        }

        private string helyseg;

        public string Helyseg
        {
            get { return helyseg; }
            set { helyseg = value.ToUpper(); }
        }


        private string hazSzam = "";

        public string HazSzam
        {
            get { return hazSzam; }
            set { 
                hazSzam = value.Trim(' ', '.', '\t'); 
            }
        }

        private byte kat;

        public byte Kategoria
        {
            get { return kat; }
            set { kat = value; }
        }

		public string Cim
		{
			get
			{
				return string.Format("{0} {1}", utca, hazSzam.Trim());
			}
		}

		

		public bool Jozsai
		{
			get
			{
				return irSzam == 4225;
			}
		}

        public bool IsEmpty
        {
            get
            {
                return fkod == null || kat == 0;
            }
        }
    }
}
