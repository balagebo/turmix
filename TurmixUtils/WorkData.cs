using System;
using System.Text.RegularExpressions;

namespace TurmixUtils
{
    public class WorkData
    {

        private static int dummyData = 0;

        public static int DummyData
        {
            get { return WorkData.dummyData++; }
            set { WorkData.dummyData = value; }
        }

        public WorkData()
        {
            fkod = dummyData++;
        }

        private float teljesitett;

        public float Teljesitett
        {
            get { return teljesitett; }
            set { teljesitett = value; }
        }

        private bool isNemkoz;

        public bool IsNemkoz
        {
            get { return isNemkoz; }
            set { isNemkoz = value; }
        }

        private int fkod;

        public int Fkod
        {
            get { return fkod; }
            set { fkod = value; }
        }

        private string rawCim;

        public string RawCim
        {
            get { return rawCim; }
            set { rawCim = value.Trim(); }
        }

        private string megrendelo;

        public string Megrendelo
        {
            get { return megrendelo; }
            set { megrendelo = value.Trim(); }
        }

        private DateTime datum;

        private DateTime printed;

        public DateTime Printed
        {
            get { return printed; }
            set { printed = value; }
        }

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        private string rendszam;

        public string Rendszam
        {
            get { return rendszam; }
            set { rendszam = value; }
        }

		private string worksheetNumber;

        public string WorksheetNumber
        {
            get { return worksheetNumber; }
            set { worksheetNumber = value; }
        }

        private float workCapacity;

        public float WorkCapacity
        {
            get { return workCapacity; }
            set { workCapacity = value; }
        }
        private int tenylegesKobmeter;

        public int TenylegesKobmeter
        {
            get { return tenylegesKobmeter; }
            set { 
                tenylegesKobmeter = value; 
            }
        }

        private string sofor = "";

        public string Sofor
        {
            get { return sofor; }
            set { sofor = value; }
        }
        private string seged = "";

        public string Seged
        {
            get { return seged; }
            set { seged = value; }
        }

        private string seged2 = "";

        public string Seged2
        {
            get { return seged2; }
            set { seged2 = value; }
        }

        private int irSzam;

        public int IranyitoSzam
        {
            get { return irSzam; }
            set { irSzam = value; }
        }

        private string utca;

        public string Utca
        {
            get { return utca; }
            set { 
                utca = value.ToUpper().Trim().TrimEnd('.'); 
                
            }
        }
        private string hazSzam = "";

        public string HazSzam
        {
            get { return hazSzam; }
            set { 
                hazSzam = value.Trim(' ', '.', '\t'); 
            }
        }

        private int csoHossz;

        public int CsoHossz
        {
            get { return csoHossz; }
            set { csoHossz = value; }
        }
        private byte napszak = 4;

        public byte Napszak
        {
            get { return napszak; }
            set { napszak = value; }
        }

		public string Cim
		{
			get
			{
				return string.Format("{0} {1}", utca, hazSzam.Trim());
			}
		}

		public float ValosKapacitas
		{
			get
			{
				return tenylegesKobmeter == 0 ? workCapacity : tenylegesKobmeter;
			}
		}

		public string GetInfo(bool munkaLap, bool kapacitas, bool cso, bool jozsai)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			if (munkaLap)
			{
				sb.AppendFormat("[{0}] ", worksheetNumber);
			}
			sb.Append(Cim);
			if (kapacitas)
			{
				sb.AppendFormat(" [{0}m3 / {1}to]", workCapacity, tenylegesKobmeter);
			}
			if (cso)
			{
				sb.AppendFormat(" - CsH: {0}", csoHossz);
			}
			if (jozsai && this.Jozsai)
			{
				sb.Append(" (Józsai cím)");
			}
			return sb.ToString();
		}

		public bool Jozsai
		{
			get
			{
				return irSzam == 4225;
			}
		}

        private bool kicsi;

        public bool Kicsi
        {
            get { return kicsi; }
            set { kicsi = value; }
        }

        public bool IsEmpty
        {
            get
            {
                return worksheetNumber == null || datum == DateTime.MinValue;
            }
        }


        public override bool Equals(object obj)
        {
            return fkod.Equals(obj);
        }

        public override int GetHashCode()
        {
            return fkod;
        }

    }



    public enum Napszak {
        Elsőfuvar,
        Délelőtt,
        Délután
    }
}
