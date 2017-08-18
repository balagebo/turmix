using System;
using System.Collections.Generic;

using System.Text;

namespace TurmixLog
{
	public class NapszakManager
	{
		private int fuvarSzam;
		private int jozsaiak;
		private List<Fuvar> fuvarok = new List<Fuvar>();

      

		public int MaxCimSzam
		{
			get
			{
				return fuvarSzam;
			}
			set
			{
				fuvarSzam = value;
			}
		}

		public int ForduloSzam
		{
			get
			{
				return fuvarok.Count;
			}
		}

		public int MaradekCim
		{
			get
			{
				return fuvarSzam - Cimek;
			}
		}

		public bool RemoveId(WorkData ma)
		{

			foreach (Fuvar fu in fuvarok)
			{
				if (fu.RemoveWorkData(ma))
				{
					if (fu.Length == 0)
						fuvarok.Remove(fu);
					return true;
				}
			}
			return false;
		}

		public void AddFuvarAt(Fuvar fu)
		{
			fuvarok.Add(fu);
		}

		public List<WorkData> GetAllId
		{
			get
			{
				List<WorkData> all = new List<WorkData>();
				
					foreach (Fuvar f in fuvarok)
						all.AddRange(f.IdSet);
				return all;
			}
		}

		public bool Empty
		{

			get
			{
				bool b = true;
				foreach (Fuvar e in fuvarok)
					if (!e.IsEmpty)
					{
						b = false;
						break;
					}
				return b;
			}
		}

		public void SetDistance(int ind, int dist)
		{
			fuvarok[ind].Distance = dist;
		}

		public int GetDistance(int ind)
		{
			return fuvarok[ind].Distance;
		}

		public int NapszakTav
		{
			get
			{
				int tav = 0;
				foreach (Fuvar m in fuvarok)
				{
					tav += m.Distance;
				}
				return tav;
			}
		}

		public int Cimek
		{
			get
			{
				int cim = 0;
					foreach (Fuvar m in fuvarok)
					{
                        cim += m.Length; //m.InsideAddressCount;
					}
				return cim;
			}
		}

		public Fuvar GetFuvarAt(int a)
		{
			if (fuvarok.Count > a)
				return fuvarok[a];
			return null;
		}

        public int FoldTav
        {
            get {
                int ret = 0;
                foreach (Fuvar f in fuvarok)
                {
                    foreach (WorkData wd in f.IdSet)
                    {
                        ret += wd.FoldHossz;
                    }
                }
                return ret;
            }
        }
	}
}
