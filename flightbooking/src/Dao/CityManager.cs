using flightbooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightbooking.Dao
{
    class CityManager
    {
		public static List<City> citys = new List<City>();

		static CityManager()
		{
			citys.Add(new City("Auckland"));
			citys.Add(new City("Wellington"));
			citys.Add(new City("Christchurch"));
			citys.Add(new City("Queenstown"));
			citys.Add(new City("Taibei China"));
			citys.Add(new City("ShangHai"));
			citys.Add(new City("BeiJing"));
			citys.Add(new City("London"));
			citys.Add(new City("New York"));
			citys.Add(new City("Paris"));

		}
		public static List<City> getCitys()
		{
			return citys;
		}

		public static int getSize()
		{
			return citys.Count;
		}
	}
}
