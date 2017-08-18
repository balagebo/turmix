using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurmixLog
{
	public class Repository : IComparer<KeyValuePair<int, WorkData>>
	{

		private Dictionary<int, Dictionary<int, WorkData>> munkaAdat;

		public Repository()
		{
			munkaAdat = new Dictionary<int, Dictionary<int, WorkData>>();
			for (int a = 0; a < 3; a++)
			{
				munkaAdat.Add(a, new Dictionary<int, WorkData>());
			}
		}

		public int Length
		{
			get
			{
				int cnt = 0;
				for (int a = 0; a < 3; a++)
				{
					cnt += munkaAdat[a].Count;
				}
				return cnt;
			}
		}

		public void Add(WorkData m)
		{
			munkaAdat[m.Napszak - 1].Add(m.Number, m);
		}

		public Dictionary<int, WorkData> GetNapszakAdat(int nsz)
		{
			return munkaAdat[nsz];
		}

		public WorkData Get(int nsz, int key)
		{
			return munkaAdat[nsz][key];
		}

		public long GetFuvarlapByIndex(int nsz, int index)
		{
			if (munkaAdat[nsz].Count > index)
				return munkaAdat[nsz].Values.ElementAt(index).WorksheetNumber;
			else return -1L;
		}

		public void Clear()
		{
			for (int a = 0; a < 3; a++)
			{
				munkaAdat[a].Clear();
			}
		}

		public WorkData Find(int id)
		{
			WorkData tm;
			if (munkaAdat[0].ContainsKey(id))
			{
				tm = munkaAdat[0][id];
				return tm;
			}
			if (munkaAdat[1].ContainsKey(id))
			{
				tm = munkaAdat[1][id];
				return tm;
			}
			if (munkaAdat[2].ContainsKey(id))
			{
				tm = munkaAdat[2][id];
				return tm;
			}
			return null;
		}

		public Dictionary<int, WorkData> GetOsszAdat()
		{
			Dictionary<int, WorkData> dic = new Dictionary<int, WorkData>();
			for (int a = 0; a < 3; a++)
			{
				foreach (int id in munkaAdat[a].Keys)
					dic.Add(id, munkaAdat[a][id]);
			}
			return dic;
		}

        public List<WorkData> GetOsszList()
        {
            List<WorkData> dic = new List<WorkData>();
            for (int a = 0; a < 3; a++)
            {
                dic.AddRange(munkaAdat[a].Values);
            }
            return dic;
        }

		#region IComparer<KeyValuePair<int,MunkaAdat>> Members

		public int Compare(KeyValuePair<int, WorkData> x, KeyValuePair<int, WorkData> y)
		{
			if (x.Value.WorkCapacity == y.Value.WorkCapacity)
				return 0;
			return x.Value.WorkCapacity > y.Value.WorkCapacity ? -1 : 1;
		}

		#endregion
	}
}
