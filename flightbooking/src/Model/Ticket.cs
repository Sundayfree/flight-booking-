using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightbooking.Model
{
    class Ticket
    {

		private string fromCity;
		private string toCity;
		private int typeTrip;  // 1 as return trip ,0 as one way trip
		private DateTime leaveDate;
		private DateTime returnDate;
		private int typeSit; // 1 as economy, 0 as bussiness

		public Ticket() { }
		public Ticket( string from, string to, int typeTrip, DateTime leave, int typeSit)
		{
			
			this.fromCity = from;
			this.toCity = to;
			this.typeTrip = typeTrip;
			this.leaveDate = leave;
			this.typeSit = typeSit;

		}
		public Ticket(string id, string from, string to, int typeTrip, DateTime leave, DateTime returnDate, int typeSit)
		{
			
			this.fromCity = from;
			this.toCity = to;
			this.typeTrip = typeTrip;
			this.leaveDate = leave;
			this.returnDate = returnDate;
			this.typeSit = typeSit;

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

		public int TypeTrip
		{
			get
			{
				return typeTrip;
			}

			set
			{
				typeTrip = value;
			}
		}

		public DateTime LeaveDate
		{
			get
			{
				return leaveDate;
			}

			set
			{
				leaveDate = value;
			}
		}

		public DateTime ReturnDate
		{
			get
			{
				return returnDate;
			}

			set
			{
				returnDate = value;
			}
		}

		public int TypeSit
		{
			get
			{
				return typeSit;
			}

			set
			{
				typeSit = value;
			}
		}

		
	}
}
