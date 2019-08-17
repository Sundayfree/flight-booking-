using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightbooking.Model
{
    class City
    {
		public City() { }

		public City(string name)
		{
			this.Name = name;
		}

		public string Name { get; set; }

		public override bool Equals(object obj)
		{
			var city = obj as City;
			return city != null &&
				   Name == city.Name;
		}

		public override int GetHashCode()
		{
			return 363513814 + EqualityComparer<string>.Default.GetHashCode(Name);
		}

		public override string ToString()
		{
			return Name.ToString();
		}
	}
}
