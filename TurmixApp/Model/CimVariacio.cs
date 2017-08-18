using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurmixLog
{
	public class CimVariacio : IComparable<CimVariacio>
	{
		int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}
		string cim;

		public string Cim
		{
			get { return cim; }
			set { cim = value; }
		}

		private string info;

		public string Info
		{
			get { return info; }
			set { info = value; }
		}

		private bool check;

		public bool Check
		{
			get { return check; }
			set { check = value; }
		}

		private int kob;

		public int Kob
		{
			get { return kob; }
			set { kob = value; }
		}

		private string megjegyzes;

		public string Megjegyzes
		{
			get { return megjegyzes; }
			set { megjegyzes = value; }
		}

		private bool deleted;

		public bool Deleted
		{
			get { return deleted; }
			set { deleted = value; }
		}

		#region IComparable<CimVariacio> Members

		public int CompareTo(CimVariacio other)
		{
			return cim.CompareTo(other.cim);
		}

		#endregion
	}
}
