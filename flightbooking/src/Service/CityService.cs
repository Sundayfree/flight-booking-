using flightbooking.Dao;
using flightbooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightbooking.Service
{
    class CityService
    {
		public List<City> getList()
		{
			return CityManager.getCitys();
		}
		public int getSize()
		{
			return CityManager.getSize();
		}
	}
}
