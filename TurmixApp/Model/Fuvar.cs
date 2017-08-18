using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurmixLog
{
	public class Fuvar
	{
		private List<WorkData> ids = new List<WorkData>();

		private int dist;

		public int Distance
		{
			get { return //HasJozsai ? 0 : 
                dist; }
			set { dist = value; }
		}

		public bool HasJozsai
		{
			get
			{
				foreach (WorkData wd in ids)
				{
					if (wd.Jozsai)
						return true;
				}
				return false;
			}
		}

		public int InsideAddressCount
		{
			get
			{
				int ret = 0;
				foreach (WorkData wd in ids)
				{
					if (!wd.Jozsai)
						ret++;
				}
				return ret;
			}

		}

		public void AddWorkData(WorkData wd)
		{
			ids.Add(wd);
		}

		public bool IsEmpty
		{
			get
			{
				return ids.Count == 0;
			}
		}

		public int Length
		{
			get
			{
				return ids.Count;
			}
		}

		public bool RemoveWorkData(WorkData wd)
		{
			return ids.Remove(wd);
		}

		public List<WorkData> IdSet
		{

			get
			{
				return ids;
			}
		}

		internal void Clear()
		{
			ids.Clear();
		}
	}
}
