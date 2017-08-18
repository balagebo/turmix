using System;
using System.Collections.Generic;


namespace TurmixLog
{
    public class Auto : IComparable<Auto>
    {

		private static System.Text.RegularExpressions.Regex rendex = new System.Text.RegularExpressions.Regex(@"[A-Za-z]{3}-\d{3}");

		public static System.Text.RegularExpressions.Regex Rendex
		{
			get { return Auto.rendex; }
			set { Auto.rendex = value; }
		}

		private static int autoIndex;

		public static int AutoIndex
		{
			get { return Auto.autoIndex; }
			set { Auto.autoIndex = value; }
		}

		private int[] csovek = new int[7];

		private int cimSzam;

		private float lizingdij;

		public float Lizingdij
		{
			get { return lizingdij; }
			set { lizingdij = value; }
		}

		private int[] jozsaiFuvarok = new int[3];

		public int ElsoJozsa
		{
			get { return jozsaiFuvarok[0]; }
		}

		public int DeJozsa
		{
			get { return jozsaiFuvarok[1]; }
		}

		public int DuJozsa
		{
			get { return jozsaiFuvarok[2]; }
		}

		private int osszM3;

		public int OsszM3
		{
			get { return osszM3; }
			set { osszM3 = value; }
		}

		private float TrutymoIdo
		{
			
			get {
				float ido = 5.5f;

				if (tartalyMeret <= 5)
					ido = Properties.Settings.Default.sziv5;
				else if (tartalyMeret <= 10)
					ido = Properties.Settings.Default.sziv10;
				else if (tartalyMeret <= 12)
					ido = Properties.Settings.Default.sziv12;
				else
					ido = Properties.Settings.Default.szivegyeb;

				return ido;
			}
			
		}

		public static int CompareByKapacitas(Auto egy, Auto mas)
		{
			if (egy.Kapacitas == mas.Kapacitas)
				return egy.Rendszam.CompareTo(mas.Rendszam);
			return egy.Kapacitas.CompareTo(mas.Kapacitas);
		}

		public Auto(string rendszam)
		{
			this.rendszam = rendszam;

			for (int a = 0; a < managers.Length; a++)
			{
				managers[a] = new NapszakManager();
			}
		}

		private int index;

		public int Index
		{
			get { return index; }
			set { index = value; }
		}

		private int csohossz;

		public int Csohossz
		{
			get { return csohossz; }
			set { csohossz = value; }
		}

		public float CsoSzereles
		{
			get
			{
				float csoSzereles = 0f;

				csoSzereles += csovek[0] * Properties.Settings.Default.cso1;
				csoSzereles += csovek[1] * Properties.Settings.Default.cso2;
				csoSzereles += csovek[2] * Properties.Settings.Default.cso3;
				csoSzereles += csovek[3] * Properties.Settings.Default.cso4;
				csoSzereles += csovek[4] * Properties.Settings.Default.cso5;
				csoSzereles += csovek[5] * Properties.Settings.Default.cso6;
				csoSzereles += csovek[6] * Properties.Settings.Default.csoegyeb;

				return csoSzereles;
			}

		}

		private float fogyasztas;

		public float Fogyasztas
		{
			get { return fogyasztas; }
			set { fogyasztas = value; }
		}

		private string sofor = "";

		public string Sofor
		{
			get { return sofor; }
			set { 
				sofor = value;
			}
		}
		private string seged = "";

		public string Seged
		{
			get { return seged; }
			set { 
				seged = value;
				if (seged != null && seged.Trim() != "")
					szemelyzet = 2;
				else
					szemelyzet = 1;
			}
		}

		private int kicsiCim;

		public int KicsiCim
		{
			get { return kicsiCim; }
			set { kicsiCim = value; }
		}
		private int nagyCim;

		public int NagyCim
		{
			get { return nagyCim; }
			set { nagyCim = value; }
		}


		private int szemelyzet = 1;

		public int Szemelyzet
		{
			get { return szemelyzet; }
		}

        private string rendszam;

        public string Rendszam
        {
            get { return rendszam; }
            set { rendszam = value; }
        }
        private int tartalyMeret = 5;

        public int Kapacitas
        {
            get { return tartalyMeret; }
            set { 
				tartalyMeret = value;
			}
        }

        private NapszakManager[] managers = new NapszakManager[3];	

		public void SetNapszakFordulok(int nsz, int val)
		{
			managers[nsz].MaxCimSzam = val;
		}

		public bool IsEmpty
		{
			get
			{
				foreach (NapszakManager man in managers)
				{
					if (!man.Empty)
						return false;
				}
				return true;
			}
		}

		public int OsszTavolsag
		{
			get
			{
				int ret = 0;
				for (int a = 0; a < 3; a++)
				{
					ret += managers[a].NapszakTav;
				}
				return ret;
			}
		}

		public int OsszCim
		{
			get
			{
				return kicsiCim + nagyCim;
			}
		}

		public int FoglaltDebrecen
		{
			get
			{
                return Math.Max(0, kicsiCim + nagyCim); //- OsszCimJozsa);
			}
		}

		public void SetNapszakTavolsag(int nsz, int fuvar, int val)
		{
			managers[nsz].SetDistance(fuvar, val);
		}

		public int GetNapszakFordulok(int nsz)
		{
			return managers[nsz].MaxCimSzam;
		}

		public int GetNapszakJozsa(int nsz)
		{
			return jozsaiFuvarok[nsz];
		}

		public int GetNapszakDebrecen(int nsz)
		{
			return managers[nsz].MaxCimSzam - jozsaiFuvarok[nsz];
		}

		public bool RemoveFuvar(WorkData ma)
		{
			bool ret = false;
			//if (!ma.Jozsai)
			{
				ret = managers[ma.Napszak - 1].RemoveId(ma);
				if (ret)
				{

					csohossz -= ma.CsoHossz;
					osszM3 -= ma.WorkCapacity;

					if (ma.WorkCapacity >= WorkData.BigCapacityLimit)
						nagyCim--;
					else
						kicsiCim--;

					if (ma.CsoHossz > 0)
					{
						if (ma.CsoHossz <= 8)
							csovek[0]--;
						else if (ma.CsoHossz <= 16)
							csovek[1]--;
						else if (ma.CsoHossz <= 24)
							csovek[2]--;
						else if (ma.CsoHossz <= 32)
							csovek[3]--;
						else if (ma.CsoHossz <= 40)
							csovek[4]--;
						else if (ma.CsoHossz <= 48)
							csovek[5]--;
						else
							csovek[6]--;
					}
                    if (ma.Jozsai)
                    {
                        jozsaiFuvarok[ma.Napszak - 1]--;
                    }
					ma.Kiosztott = ma.Processed = false;
					
				}
			}
			return ret;
		}

		public void AddFuvar(List<WorkData> adat, int tav)
		{
			if (adat.Count == 0)
				return;

			Fuvar fuv = new Fuvar();
			fuv.Distance = tav;

			foreach (WorkData ma in adat)
			{
				ma.Kiosztott = true;
				csohossz += ma.CsoHossz;
				osszM3 += ma.WorkCapacity;
				if (ma.WorkCapacity >= WorkData.BigCapacityLimit)
					nagyCim++;
				else
					kicsiCim++;

				if (ma.CsoHossz > 0)
				{
					if (ma.CsoHossz <= 8)
						csovek[0]++;
					else if (ma.CsoHossz <= 16)
						csovek[1]++;
					else if (ma.CsoHossz <= 24)
						csovek[2]++;
					else if (ma.CsoHossz <= 32)
						csovek[3]++;
					else if (ma.CsoHossz <= 40)
						csovek[4]++;
					else if (ma.CsoHossz <= 48)
						csovek[5]++;
					else
						csovek[6]++;
				}

				if (ma.Jozsai)
				{
					jozsaiFuvarok[ma.Napszak - 1]++;
				}

				fuv.AddWorkData(ma);

			}

			managers[adat[0].Napszak - 1].AddFuvarAt(fuv);
		}

        public void AddFuvar(WorkData ma, int tav)
        {
            Fuvar fuv = new Fuvar();
            fuv.Distance = tav;

            ma.Kiosztott = true;
            csohossz += ma.CsoHossz;
            osszM3 += ma.WorkCapacity;
            if (ma.WorkCapacity >= WorkData.BigCapacityLimit)
                nagyCim++;
            else
                kicsiCim++;

            if (ma.CsoHossz > 0)
            {
                if (ma.CsoHossz <= 8)
                    csovek[0]++;
                else if (ma.CsoHossz <= 16)
                    csovek[1]++;
                else if (ma.CsoHossz <= 24)
                    csovek[2]++;
                else if (ma.CsoHossz <= 32)
                    csovek[3]++;
                else if (ma.CsoHossz <= 40)
                    csovek[4]++;
                else if (ma.CsoHossz <= 48)
                    csovek[5]++;
                else
                    csovek[6]++;
            }

            if (ma.Jozsai)
            {
                jozsaiFuvarok[ma.Napszak - 1]++;
            }

            fuv.AddWorkData(ma);
            managers[ma.Napszak - 1].AddFuvarAt(fuv);
            
        }

		public void AddJozsaiFuvar(WorkData ma)
		{
			Fuvar fuv = new Fuvar();

			ma.Kiosztott = true;
			fuv.AddWorkData(ma);

			jozsaiFuvarok[ma.Napszak - 1]++;
			managers[ma.Napszak - 1].AddFuvarAt(fuv);
		}

		public bool IsJozsaiAuto
		{
			get
			{
                return jozsaiFuvarok[0] > 0 || jozsaiFuvarok[1] > 0 || jozsaiFuvarok[2] > 0;
			}
		}

		public int OsszCimJozsa
		{
			get
			{
				int ret = 0;
				for (int a = 0; a < 3; a++)
				{
					ret += jozsaiFuvarok[a];
				}
				return ret;
			}
		}

		public int OsszFordulo
		{
			get
			{
				int ret = 0;
				for (int a = 0; a < 3; a++)
				{
                    ret += managers[a].MaxCimSzam; //- jozsaiFuvarok[a];
				}
				return ret;
			}
		}

		public int OsszForduloSzam
		{
			get
			{
				int ret = 0;
				for (int a = 0; a < 3; a++)
				{
					ret += managers[a].ForduloSzam;
				}
				return ret;
			}
		}

		public List<WorkData> GetFuvarAt(int nsz, int menet)
		{
			return managers[nsz].GetFuvarAt(menet).IdSet;
		}

		public List<WorkData> OsszesMunkalap(int nsz)
		{

			return managers[nsz].GetAllId;
		}

		public int FuvarHossz(int nsz, int fuvar)
		{
			return managers[nsz].GetDistance(fuvar);
		}

		public double NapszakFuvarHossz(int nsz)
		{
			return managers[nsz].NapszakTav;
		}

		public int NapszakFuvarDebCimek(int nsz)
		{
			return managers[nsz].Cimek;
		}

		public int FuvarCimek(int nsz, int f)
		{
			return managers[nsz].GetFuvarAt(f).Length;
		}

		public int SzabadCimek(int nsz)
		{
            return managers[nsz].MaradekCim; //- jozsaiFuvarok[nsz];
		}

		public int NapszakForduloSzam(int nsz)
		{
			return managers[nsz].ForduloSzam;
		}

        public int OsszSzabadCimek
        {
            get
            {
                int ret = 0;
                for (int a = 0; a < 3; a++)
                {
                    ret += managers[a].MaradekCim; //-jozsaiFuvarok[a];
                }
                return ret;
            }
        }

        public int FoldUtHossz
        {
            get
            {
                int ret = 0;
                for (int a = 0; a < 3; a++)
                {
                    ret += managers[a].FoldTav;
                }
                return ret;
            }
        }

		public float Ber
		{
			get
			{
				float ber = 0f;
				if (tartalyMeret >= WorkData.BigCapacityLimit)
				{
					ber = Properties.Settings.Default.nagysoforber + Properties.Settings.Default.nagysoforjar;
					if (szemelyzet > 1)
						ber += Properties.Settings.Default.nagysegedber + Properties.Settings.Default.nagysegedjar;
				}
				else
				{
					ber = Properties.Settings.Default.kissoforber + Properties.Settings.Default.kissoforjar;
					if (szemelyzet > 1)
						ber += Properties.Settings.Default.kissegedber + Properties.Settings.Default.kissegedjar;
				}
				return ber;
			}
		}

		public int OsszKoltseg
		{
			get
			{

				return (int)Math.Round(KoltsegTenyezo);
			}
		}

		public float CumiTenyezo
		{
			get
			{
				//if (jozsaiAuto)
					//return 0f;
				float cs = CsoSzereles;
                float foldutBonus = Properties.Settings.Default.foldutSeb - Properties.Settings.Default.speed;
				if (KettenUlnek)
					cs *= (1f - Properties.Settings.Default.kettenUlnekBonus / 100);
				return (OsszTavolsag / Properties.Settings.Default.speed * 60 + FoldUtHossz / foldutBonus * 60) + cs + TrutymoIdo * OsszForduloSzam;
					
			}
		}

		public string MikorVegezStr
		{
			get
			{
				return MikorVegez.ToString("HH:mm");
			}
		}

		public DateTime MikorVegez
		{
			get
			{
				DateTime dt = DateTime.Now.Date.AddHours(6).AddMinutes(CumiTenyezo);

				if (dt.Hour >= 12)
					dt = dt.AddMinutes(Properties.Settings.Default.ebedido);

				return dt;
			}
		}

		public bool KettenUlnek
		{
			get
			{
				return szemelyzet > 1;
			}
		}

		public string Info
		{
			get
			{
				return string.Format("{0} [{1}]", rendszam, tartalyMeret.ToString());
			}
		}

		public float KoltsegTenyezo
		{
			get
			{
				float koltseg = 0f;
                
				int nap = Properties.Settings.Default.workDays;
				if (OsszCim > 0 && OsszCim == OsszFordulo)
				{
					koltseg = Ber / nap + fogyasztas * Properties.Settings.Default.benzinar * OsszTavolsag / 100 + lizingdij / nap;
					if (Properties.Settings.Default.costbonusactive)
					{
						koltseg *= (100 + Properties.Settings.Default.costbonus) / 100;
					}
                   
				}
				return koltseg;
			}
		}

		#region IComparable<Auto> Members

		public int CompareTo(Auto other)
		{
			if (KoltsegTenyezo == other.KoltsegTenyezo)
			{
				if (tartalyMeret == other.tartalyMeret)
				{
					return rendszam.CompareTo(other.rendszam);
				}
				else
				{
					return tartalyMeret > other.tartalyMeret ? 1 : -1;
				}
			}
			return (KoltsegTenyezo).CompareTo(other.KoltsegTenyezo);
		}

		#endregion

		
	}
}
