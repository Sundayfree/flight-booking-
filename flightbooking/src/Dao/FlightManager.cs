using flightbooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightbooking.Dao
{
    class FlightManager
    {
		private static List<Flight> flights = new List<Flight>();

		static FlightManager()
		{
			flights.Add(new Flight("A320", "Auckland", "Wellington", "$100", "$200"));
			flights.Add(new Flight("A320", "Wellington", "Auckland", "$120", "200"));
			flights.Add(new Flight("A320", "Auckland", "Christchurch", "$120", "$200"));
			flights.Add(new Flight("A320", "Auckland", "Queenstown", "$100", "$200"));
			flights.Add(new Flight("A320", "Queenstown", "Auckland", "$110", "$200"));
			flights.Add(new Flight("A320", "Queenstown", "Wellington", "$110", "$200"));
			flights.Add(new Flight("A320", "Christchurch", "Wellington", "$120", "$200"));
			flights.Add(new Flight("A320", "Christchurch", "Auckland", "$120", "$200"));

			flights.Add(new Flight("A310", "Auckland", "Wellington", "$150", "$300"));
			flights.Add(new Flight("A310", "Wellington", "Auckland", "$120", "$200"));
			flights.Add(new Flight("A310", "Auckland", "Christchurch", "$100", "$200"));
			flights.Add(new Flight("A310", "Auckland", "Queenstown", "$110", "$200"));
			flights.Add(new Flight("A310", "Queenstown", "Auckland", "$120", "$200"));
			flights.Add(new Flight("A310", "Queenstown", "Wellington", "$310", "$200"));
			flights.Add(new Flight("A310", "Christchurch", "Wellington", "$120", "$200"));
			flights.Add(new Flight("A310", "Christchurch", "Auckland", "$220", "$200"));

			flights.Add(new Flight("A330", "Auckland", "Wellington", "$100", "$200"));
			flights.Add(new Flight("A330", "Wellington", "Auckland", "$120", "$200"));
			flights.Add(new Flight("A330", "Auckland", "Christchurch", "$120", "$200"));
			flights.Add(new Flight("A330", "Auckland", "Queenstown", "$100", "$200"));
			flights.Add(new Flight("A330", "Queenstown", "Auckland", "$110", "$200"));
			flights.Add(new Flight("A330", "Queenstown", "Wellington", "$110", "$200"));
			flights.Add(new Flight("A330", "Christchurch", "Wellington", "$120", "$200"));
			flights.Add(new Flight("A330", "Christchurch", "Auckland", "$120", "$200"));


			flights.Add(new Flight("J211", "Wellington", "Christchurch", "$120", "$200"));
			flights.Add(new Flight("J211", "Wellington", "Queenstown", "$110", "$200"));
			flights.Add(new Flight("J211", "Wellington", "Auckland", "$110", "$200"));

			flights.Add(new Flight("J301", "Wellington", "Christchurch", "$120", "$200"));
			flights.Add(new Flight("J301", "Wellington", "Queenstown", "$110", "$200"));
			flights.Add(new Flight("J301", "Wellington", "Auckland", "$110", "$200"));


			flights.Add(new Flight("J210", "Auckland", "Wellington", "$100", "$200"));
			flights.Add(new Flight("J210", "Wellington", "Auckland", "$120", "$200"));
			flights.Add(new Flight("J210", "Auckland", "Christchurch", "$120", "$200"));
			flights.Add(new Flight("J210", "Auckland", "Queenstown", "$100", "$200"));
			flights.Add(new Flight("J210", "Queenstown", "Auckland", "$110", "$200"));
			flights.Add(new Flight("J210", "Queenstown", "Wellington", "$110", "$200"));
			flights.Add(new Flight("J210", "Christchurch", "Wellington", "$120", "$200"));
			flights.Add(new Flight("J210", "Christchurch", "Auckland", "$120", "$200"));

			flights.Add(new Flight("A550", "Auckland", "Taibei China", "$300", "$400"));
			flights.Add(new Flight("A550", "Auckland", "ShangHai", "$260", "$300"));
			flights.Add(new Flight("A550", "Auckland", "BeiJing", "$310", "450"));

			flights.Add(new Flight("A560", "Auckland", "Taibei China", "$300", "$400"));
			flights.Add(new Flight("A560", "Auckland", "ShangHai", "$260", "$300"));
			flights.Add(new Flight("A560", "Auckland", "BeiJing", "$310", "450"));

			flights.Add(new Flight("A600", "Auckland", "Taibei China", "$300", "$400"));
			flights.Add(new Flight("A600", "Auckland", "ShangHai", "$260", "$300"));
			flights.Add(new Flight("A600", "Auckland", "BeiJing", "$310", "450"));

			flights.Add(new Flight("N330", "Taibei China", "Auckland", "$300", "$400"));
			flights.Add(new Flight("N330", "ShangHai", "Auckland", "$260", "$300"));
			flights.Add(new Flight("N330", "BeiJing", "Auckland", "$310", "450"));

			flights.Add(new Flight("N220", "Taibei China", "Auckland", "$300", "$400"));
			flights.Add(new Flight("N220", "ShangHai", "Auckland", "$260", "$300"));
			flights.Add(new Flight("N220", "BeiJing", "Auckland", "$310", "450"));

			flights.Add(new Flight("A122", "Taibei China", "Auckland", "$300", "$400"));
			flights.Add(new Flight("A122", "ShangHai", "Auckland", "$260", "$300"));
			flights.Add(new Flight("A122", "BeiJing", "Auckland", "$310", "450"));

			flights.Add(new Flight("N550", "Auckland", "London", "$200", "$400"));
			flights.Add(new Flight("N550", "Auckland", "New York", "$10", "$300"));
			flights.Add(new Flight("N550", "Auckland", "Paris", "$330", "550"));

			flights.Add(new Flight("N560", "London", "Auckland", "$200", "$400"));
			flights.Add(new Flight("N560", "New York", "Auckland", "$10", "$300"));
			flights.Add(new Flight("N560", "Paris", "Auckland", "$330", "550"));

			flights.Add(new Flight("A780", "Auckland", "London", "$200", "$400"));
			flights.Add(new Flight("A780", "Auckland", "New York", "$10", "$300"));
			flights.Add(new Flight("A780", "Auckland", "Paris", "$330", "550"));

			flights.Add(new Flight("N960", "London", "Auckland", "$200", "$400"));
			flights.Add(new Flight("N960", "New York", "Auckland", "$10", "$300"));
			flights.Add(new Flight("N960", "Paris", "Auckland", "$330", "550"));

			flights.Add(new Flight("C110", "Taibei China", "BeiJing", "$100", "$200"));
			flights.Add(new Flight("C110", "Taibei China", "ShangHai", "$122", "221"));

			flights.Add(new Flight("C130", "Taibei China", "BeiJing", "$100", "$200"));
			flights.Add(new Flight("C130", "Taibei China", "ShangHai", "$122", "221"));

			flights.Add(new Flight("C230", "Taibei China", "BeiJing", "$100", "$200"));
			flights.Add(new Flight("C230", "Taibei China", "ShangHai", "$122", "221"));

			flights.Add(new Flight("C330", "BeiJing", "Taibei China", "$100", "$200"));
			flights.Add(new Flight("C330", "BeiJing", "ShangHai", "$122", "221"));
			flights.Add(new Flight("C350", "BeiJing", "Taibei China", "$100", "$200"));
			flights.Add(new Flight("C350", "BeiJing", "ShangHai", "$122", "221"));
			flights.Add(new Flight("C600", "BeiJing", "Taibei China", "$100", "$200"));
			flights.Add(new Flight("C600", "BeiJing", "ShangHai", "$122", "221"));

			flights.Add(new Flight("D220", "ShangHai", "Taibei China", "$100", "$200"));
			flights.Add(new Flight("D220", "ShangHai", "BeiJing", "$122", "221"));

			flights.Add(new Flight("D320", "ShangHai", "Taibei China", "$100", "$200"));
			flights.Add(new Flight("D320", "ShangHai", "BeiJing", "$122", "221"));

			flights.Add(new Flight("D420", "ShangHai", "Taibei China", "$100", "$200"));
			flights.Add(new Flight("D420", "ShangHai", "BeiJing", "$122", "221"));

			flights.Add(new Flight("US110", "New York", "London", "$10", "$400"));
			flights.Add(new Flight("US110", "New York", "Paris", "$10", "$300"));

			flights.Add(new Flight("US120", "New York", "London", "$10", "$400"));
			flights.Add(new Flight("US120", "New York", "Paris", "$10", "$300"));

			flights.Add(new Flight("US130", "New York", "London", "$10", "$400"));
			flights.Add(new Flight("US130", "New York", "Paris", "$10", "$300"));

			flights.Add(new Flight("B220", "London", "New York", "$160", "$400"));
			flights.Add(new Flight("B220", "London", "Paris", "$160", "$300"));

			flights.Add(new Flight("B230", "London", "New York", "$160", "$400"));
			flights.Add(new Flight("B230", "London", "Paris", "$160", "$300"));

			flights.Add(new Flight("B230", "London", "New York", "$160", "$400"));
			flights.Add(new Flight("B230", "London", "Paris", "$160", "$300"));

			flights.Add(new Flight("F220", "Paris", "New York", "$160", "$400"));
			flights.Add(new Flight("F220", "Paris", "London", "$160", "$300"));

			flights.Add(new Flight("F320", "Paris", "New York", "$160", "$400"));
			flights.Add(new Flight("F320", "Paris", "London", "$160", "$300"));

			flights.Add(new Flight("F330", "Paris", "New York", "$160", "$400"));
			flights.Add(new Flight("F330", "Paris", "London", "$160", "$300"));
		}

		public static List<Flight> getFlights()
		{
			return flights;
		}
	}
}
