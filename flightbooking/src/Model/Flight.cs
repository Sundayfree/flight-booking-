using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightbooking.Model
{
    class Flight
    {
		private string name;
		private string fromCity;
		private string toCity;
		private string economicprice;
		private string businessprice;

		public string Name
		{
			get
			{
				return name;
			}

			set
			{
				name = value;
			}
		}

		public string FromCity
		{
			get
			{
				return fromCity;
			}

			set
			{
				fromCity = value;
			}
		}

		public string ToCity
		{
			get
			{
				return toCity;
			}

			set
			{
				toCity = value;
			}
		}

		public string Economicprice
		{
			get
			{
				return economicprice;
			}

			set
			{
				economicprice = value;
			}
		}

		public string Businessprice
		{
			get
			{
				return businessprice;
			}

			set
			{
				businessprice = value;
			}
		}

		public Flight(string name, string fromCity, string toCity, string economicprice, string businessprice)
		{
			this.Name = name;
			this.FromCity = fromCity;
			this.ToCity = toCity;
			this.Economicprice = economicprice;
			this.Businessprice = businessprice;
		}

		public Flight() { }
	}
}
