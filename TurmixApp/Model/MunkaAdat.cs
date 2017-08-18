using System;
using System.Text.RegularExpressions;

namespace TurmixLog
{
    public class WorkData
    {
        private static Regex kisreg = new Regex(@"avia|(kis|kicsi)(\s|\w)*(aut|kocs)", RegexOptions.IgnoreCase);

        public static System.Globalization.NumberFormatInfo colonNumberFormat;
        public static System.Globalization.NumberFormatInfo pointNumberFormat;

        static WorkData() {
           
            colonNumberFormat = new System.Globalization.NumberFormatInfo();
            colonNumberFormat.NumberDecimalSeparator = ",";
            pointNumberFormat = new System.Globalization.NumberFormatInfo();
            pointNumberFormat.NumberDecimalSeparator = ".";
        }

        private DateTime datum;

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }


		private static bool showWorksheetNumber;

		public static bool ShowWorksheetNumber
		{
			get { return WorkData.showWorksheetNumber; }
			set { WorkData.showWorksheetNumber = value; }
		}

		private static int bigCapacityLimit = 10;

		public static int BigCapacityLimit
		{
			get { return WorkData.bigCapacityLimit; }
			set { WorkData.bigCapacityLimit = value; }
		}

		private long worksheetNumber;

        public long WorksheetNumber
        {
            get { return worksheetNumber; }
            set { worksheetNumber = value; }
        }

        private int workCapacity;

        public int WorkCapacity
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

        private int irSzam;

        public int IranyitoSzam
        {
            get { return irSzam; }
            set { irSzam = value; }
        }

        private double lat;

        public double Lat
        {
            get { return lat; }
            set { lat = value; }
        }

        private double lng;

        public double Lng
        {
            get { return lng; }
            set { lng = value; }
        }

        private double foldLng;

        public double FoldLng
        {
            get { return foldLng; }
            set { foldLng = value; }
        }

        private int foldHossz;

        public int FoldHossz
        {
            get { return foldHossz; }
            set { foldHossz = value; }
        }

        private double foldLat;

        public double FoldLat
        {
            get { return foldLat; }
            set { foldLat = value; }
        }

        private string utca;

        public string Utca
        {
            get { return utca; }
            set { 
                utca = value.ToUpper().Trim().TrimEnd('.'); 
                
            }
        }
        private string hazSzam;

        public string HazSzam
        {
            get { return hazSzam; }
            set { 
                hazSzam = value.Trim(); 
            }
        }

		private string csoStr;

		public string CsoStr
		{
			get { return csoStr; }
			set { csoStr = value; }
		}

        private int csoHossz;

        public int CsoHossz
        {
            get { return csoHossz; }
            set { csoHossz = value; }
        }
        private int napszak = -1;

        public int Napszak
        {
            get { return napszak; }
            set { napszak = value; }
        }

		private string megjegyzes = "";

		public string Megjegyzes
		{
			get { return megjegyzes; }
			set { 
				megjegyzes = value;
                if (kisreg.IsMatch(megjegyzes))
                {
                    problematic = true;
                }
			}
		}

        private string szolgaltato = "turmix";

        public string Szolgaltato
        {
            get { return szolgaltato; }
            set { szolgaltato = value; }
        }

        public bool IsTranzit
        {
            get
            {
                return szolgaltato != "turmix";
            }
        }

		public string Cim
		{
			get
			{
				return string.Format("{0} {1}", utca, hazSzam.Trim());
			}
		}

		public int ValosKapacitas
		{
			get
			{
				return tenylegesKobmeter == 0 ? workCapacity : tenylegesKobmeter;
			}
		}

        private float hossz;

        public float Hossz
        {
            get { return hossz; }
            set { hossz = value; }
        }

        private float folduthossz;

        public float Folduthossz
        {
            get { return folduthossz; }
            set { folduthossz = value; }
        }

		private int number;

		public int Number
		{
			get { return number; }
			set { number = value; }
		}

		private bool kiosztott;

		public bool Kiosztott
		{
			get { return kiosztott; }
			set { kiosztott = value; }
		}

		public int Csoport
		{
			get
			{
				return workCapacity >= BigCapacityLimit ? 2 : 1;
			}
		}

        private string fhkod;

        public string FhKod
        {
            get { return fhkod; }
            set { fhkod = value; }
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

		private bool processed;

		public bool Processed
		{
			get { return processed; }
			set { processed = value; }
		}

		private int autoAdat = -1;

		public int AutoAdat
		{
			get { return autoAdat; }
			set { autoAdat = value; }
		}

		private int tempFordulo = -1;

		public int TempFordulo
		{
			get { return tempFordulo; }
			set { tempFordulo = value; }
		}

		private bool problematic;

		public bool Problematic
		{
			get { return problematic; }
			set { problematic = value; }
		}

        private string rendszam;

        public string Rendszam
        {
            get { return rendszam; }
            set { rendszam = value; }
        }

        private int fkod;

        public int Fkod
        {
            get { return fkod; }
            set { fkod = value; }
        }

		public void WriteXmlTo(System.Xml.XmlTextWriter xml)
		{
			xml.WriteStartElement("workUnit");
			xml.WriteAttributeString("lat", lat.ToString());
			xml.WriteAttributeString("lng", lng.ToString());
			xml.WriteAttributeString("workCapacity", workCapacity.ToString());
			xml.WriteAttributeString("realm3", tenylegesKobmeter.ToString());
			xml.WriteAttributeString("period", napszak.ToString());
			xml.WriteAttributeString("id", number.ToString());
			xml.WriteAttributeString("street", utca);
			xml.WriteAttributeString("house", hazSzam);
			xml.WriteAttributeString("zip", irSzam.ToString());
			xml.WriteAttributeString("pipe", csoHossz.ToString());
			xml.WriteAttributeString("sheetNo", worksheetNumber.ToString());
			xml.WriteAttributeString("prob", problematic.ToString());
            xml.WriteAttributeString("foldlat", foldLat.ToString());
            xml.WriteAttributeString("foldlng", foldLng.ToString());
            xml.WriteAttributeString("foldhossz", foldHossz.ToString());
            
			xml.WriteCData(megjegyzes);
			xml.WriteEndElement();

		}

		public void ParseFromXml(System.Xml.XmlNode workNode)
		{

			workCapacity = int.Parse(workNode.Attributes[2].Value);
			tenylegesKobmeter = int.Parse(workNode.Attributes[3].Value);
			napszak = int.Parse(workNode.Attributes[4].Value);
			number = int.Parse(workNode.Attributes[5].Value);
			utca = workNode.Attributes[6].Value;
			hazSzam = workNode.Attributes[7].Value;
			irSzam = int.Parse(workNode.Attributes[8].Value);
			csoHossz = int.Parse(workNode.Attributes[9].Value);
			worksheetNumber = long.Parse(workNode.Attributes[10].Value);
			problematic = bool.Parse(workNode.Attributes[11].Value);
			megjegyzes = workNode.FirstChild.Value;
		}

        public void ParseFold(System.Xml.XmlNode workNode)
        {
            try
            {
                foldLat = double.Parse(workNode.Attributes[12].Value, pointNumberFormat);
                foldLng = double.Parse(workNode.Attributes[13].Value, pointNumberFormat);
                foldHossz = int.Parse(workNode.Attributes[14].Value, pointNumberFormat);
            }
            catch (IndexOutOfRangeException)
            {
            }
            catch (FormatException)
            {
                foldLat = double.Parse(workNode.Attributes[12].Value, colonNumberFormat);
                foldLng = double.Parse(workNode.Attributes[13].Value, colonNumberFormat);
                foldHossz = int.Parse(workNode.Attributes[14].Value, colonNumberFormat);
            }
        }

        public void ParseKoord(System.Xml.XmlNode workNode)
        {
            try {
                lat = double.Parse(workNode.Attributes[0].Value, pointNumberFormat);
                lng = double.Parse(workNode.Attributes[1].Value, pointNumberFormat);
            }
            catch (FormatException)
            {
                lat = double.Parse(workNode.Attributes[0].Value, colonNumberFormat);
                lng = double.Parse(workNode.Attributes[1].Value, colonNumberFormat);
            }
        }

		/*public string TrimmedUtca
		{
			get
			{
				return utca.EndsWith(" U") || utca.EndsWith(" U.") ? utca.Substring(0, utca.LastIndexOf(' ')).Trim(' ') :

			}
		}*/

		public static int CompareByNumber(WorkData m1, WorkData m2)
		{
			return m1.number.CompareTo(m2.number);
		}
    }



    public enum Napszak {
        Elsőfuvar,
        Délelőtt,
        Délután
    }
}
