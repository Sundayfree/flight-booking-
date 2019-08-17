using flightbooking.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightbooking.Dao
{
	class UserManager
	{
		private static List<User> UserList = new List<User>();
		static UserManager()
		{
			UserList.Add(new User( "liu", "123", "Ran", "Liu"));
		
		}
		public static List<User> getUserList()
		{
			return UserList;
		}
		public static void save( string name, string password, string fname,string lname)
		{

			User user = new User();
			user.Username = name;
			user.Password = password;
			user.Fname = fname;
			user.Lname = lname;
			UserList.Add(user);
		}
	}
}
