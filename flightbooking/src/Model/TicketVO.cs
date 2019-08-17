using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightbooking.Model
{
    class TicketVO
    {

		private string name;
		private string fromCity;
		private string tocity;
		private string ticketName;
		private string sitType;
		private string price;
		private string leaveDate;
		private string returnTicket;
		private string returnDate;
		private int typeTrip;

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

		public string Tocity
		{
			get
			{
				return tocity;
			}

			set
			{
				tocity = value;
			}
		}

		public string TicketName
		{
			get
			{
				return ticketName;
			}

			set
			{
				ticketName = value;
			}
		}

		public string SitType
		{
			get
			{
				return sitType;
			}

			set
			{
				sitType = value;
			}
		}

		public string Price
		{
			get
			{
				return price;
			}

			set
			{
				price = value;
			}
		}

		public string LeaveDate
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

		public string ReturnTicket
		{
			get
			{
				return returnTicket;
			}

			set
			{
				returnTicket = value;
			}
		}

		public string ReturnDate
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

		public TicketVO() { }


	}
}
