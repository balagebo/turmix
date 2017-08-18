using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurmixLog
{
	public struct CimOsszesito
	{

        public int Elsofuvar
        {
            get { return elsoLE5 + elsoTizes; }
        }

        public int Delelott
        {
            get { return deLE5 + deTizes; }
        }

        public int Delutan
        {
            get { return duLE5 + duTizes; }
        }

		public int ElsofuvarKisDeb
		{
            get { return elsoLE5 - elsoLE5Jo; }
		}

		public int DelelottKisDeb
		{
            get { return deLE5 - deLE5Jo; }
		}
	
		public int DelutanKisDeb
		{
            get { return duLE5 - duLE5Jo; }
		}

        public int ElsofuvarNagyDeb
        {
            get { return elsoTizes - elsoTizesJo; }
        }

        public int DelelottNagyDeb
        {
            get { return deTizes - deTizesJo; }
        }

        public int DelutanNagyDeb
        {
            get { return duTizes - duTizesJo; }
        }    

        public int ElsofuvarOsszDeb
        {
            get { return ElsofuvarKisDeb + ElsofuvarNagyDeb; }
        }

        public int DelelottOsszDeb
        {
            get { return DelelottKisDeb + DelelottNagyDeb; }
        }

        public int DelutanOsszDeb
        {
            get { return DelutanKisDeb + DelutanNagyDeb; }
        }

        public int ElsofuvarOsszJozsa
        {
            get { return elsoLE5Jo + elsoTizesJo; }
        }

        public int DelelottOsszJozsa
        {
            get { return deLE5Jo + deTizesJo; }
        }

        public int DelutanOsszJozsa
        {
            get { return duLE5Jo + duTizesJo; }
        }

		int elsoLE5;

		public int ElsoLE5
		{
			get { return elsoLE5; }
			set { elsoLE5 = value; }
		}

		int deLE5;

		public int DeLE5
		{
			get { return deLE5; }
			set { deLE5 = value; }
		}

		int duLE5;

		public int DuLE5
		{
			get { return duLE5; }
			set
			{
				duLE5 = value;

			}
		}

        int elsoLE5Jo;

        public int ElsoLE5Jo
        {
            get { return elsoLE5Jo; }
            set { elsoLE5Jo = value; }
        }

        int deLE5Jo;

        public int DeLE5Jo
        {
            get { return deLE5Jo; }
            set { deLE5Jo = value; }
        }

        int duLE5Jo;

        public int DuLE5Jo
        {
            get { return duLE5Jo; }
            set { duLE5Jo = value; }
        }

        public int OsszLE5Jozsa
        {
            get
            {
                return elsoLE5Jo + deLE5Jo + duLE5Jo;
            }
        }

        public int OsszLE5Deb
        {
            get
            {
                return OsszLE5 - OsszLE5Jozsa;
            }
        }

		public int OsszLE5
		{
			get
			{
				return elsoLE5 + deLE5 + duLE5;
			}
		}


		int elsoTizes;

		public int ElsoTizes
		{
			get { return elsoTizes; }
			set { elsoTizes = value; }
		}

		int deTizes;

		public int DeTizes
		{
			get { return deTizes; }
			set { deTizes = value; }
		}

		int duTizes;

		public int DuTizes
		{
			get { return duTizes; }
			set { duTizes = value; }
		}

        int elsoTizesJo;

        public int ElsoTizesJozsa
        {
            get { return elsoTizesJo; }
            set { elsoTizesJo = value; }
        }

        int deTizesJo;

        public int DeTizesJozsa
        {
            get { return deTizesJo; }
            set { deTizesJo = value; }
        }

        int duTizesJo;

        public int DuTizesJozsa
        {
            get { return duTizesJo; }
            set { duTizesJo = value; }
        }

        public int OsszTizesJozsa
        {
            get
            {
                return elsoTizesJo + deTizesJo + duTizesJo;
            }
        }

        public int OsszTizesDeb
        {
            get
            {
                return OsszTizes - OsszTizesJozsa;
            }
        }

        public int OsszTizes
        {
            get
            {
                return elsoTizes + deTizes + duTizes;
            }
        }

		int kism3;

		public int Kism3
		{
			get { return kism3; }
			set { kism3 = value; }
		}

		int nagym3;

		public int Nagym3
		{
			get { return nagym3; }
			set { nagym3 = value; }
		}

        int kism3Jo;

        public int Kism3Jozsa
        {
            get { return kism3Jo; }
            set { kism3Jo = value; }
        }

        int nagym3Jo;

        public int Nagym3Jozsa
        {
            get { return nagym3Jo; }
            set { nagym3Jo = value; }
        }

        public int Kism3Deb
        {
            get { return kism3 - kism3Jo; }
        }

        public int Nagym3Deb
        {
            get { return nagym3 - nagym3Jo; }
        }

        public int Osszm3
        {
            get { return kism3 + nagym3; }
        }

        public int Osszm3Jo
        {
            get { return kism3Jo + nagym3Jo; }
        }

        public int Osszm3Deb
        {
            get { return Osszm3 - Osszm3Jo; }
        }

		public int OsszJozsai
		{
			get
			{
				return OsszLE5Jozsa + OsszTizesJozsa;
			}
		}

		public int OsszDebrecen
		{
			get
			{
                return OsszLE5Deb + OsszTizesDeb;
			}
		}

		public int OsszEgesz
		{
			get
			{
                return OsszLE5 + OsszTizes;
			}
		}

		public void UpdateWith(WorkData tempData)
		{
            bool jozsai = tempData.Jozsai;

			
				switch (tempData.Napszak)
				{
					case 1:
                        if (tempData.WorkCapacity <= WorkData.BigCapacityLimit)
                        {
                            elsoLE5++;
                            if (jozsai)
                                elsoLE5Jo++;
                        }
                        else
                        {
                            elsoTizes++;
                            if (jozsai)
                                elsoTizesJo++;
                        }
						break;
					case 2:
                        if (tempData.WorkCapacity <= WorkData.BigCapacityLimit)
                        {
                            deLE5++;
                            if (jozsai)
                                deLE5Jo++;
                        }
                        else
                        {
                            deTizes++;
                            if (jozsai)
                                deTizesJo++;
                        }
						break;
					case 3:
                        if (tempData.WorkCapacity <= WorkData.BigCapacityLimit)
                        {
                            duLE5++;
                            if (jozsai)
                                duLE5Jo++;
                        }
                        else
                        {
                            duTizes++;
                            if (jozsai)
                                duTizesJo++;
                        }
						break;
				}
				if (tempData.WorkCapacity <= WorkData.BigCapacityLimit)
				{
                    kism3 += tempData.WorkCapacity;
                    if (jozsai) 
					    kism3Jo += tempData.WorkCapacity;
				}
				else
				{
                    nagym3 += tempData.WorkCapacity;
                    if (jozsai)
                        nagym3Jo += tempData.WorkCapacity;
				}
			
		}

	}
}
