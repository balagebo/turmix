using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurmixLog
{
	public class GLatLng
	{
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

        public GLatLng()
        {
        }

        public bool IsEmpty
        {
            get
            {
                return lat == 0 && lng == 0;
            }
        }

		public GLatLng(double lat, double lng)
		{
			this.lat = lat;
			this.lng = lng;
		}

		public static bool operator ==(GLatLng egy, GLatLng mas)
		{
			return egy.lat == mas.lat && egy.lng == mas.lng;
		}
		public static bool operator !=(GLatLng egy, GLatLng mas)
		{
			return egy.lat != mas.lat || egy.lng != mas.lng;
		}
	}
}
