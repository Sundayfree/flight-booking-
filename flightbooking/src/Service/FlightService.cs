using flightbooking.Dao;
using flightbooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightbooking.Service
{
    class FlightService
    {
		public List<Flight> GetFlights()
		{
			return FlightManager.getFlights();
		}
	}
}
