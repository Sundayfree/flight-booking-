using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace flightbooking.model
{
    public class User
    {
		public User() { }
		public User(string fname, string lname, string password, string repassword, string username)
		{
			Fname = fname;
			Lname = lname;
			Password = password;
			Repassword = repassword;
			Username = username;
		}
		public User(string username, string password, string fname, string lname)
		{
			Username = username;
			Fname = fname;
			Lname = lname;
			Password = password;
			
			
		}
		public User( string password,  string username)
		{
		
			Password = password;
		
			Username = username;
		}
		public string Fname { get; set; }
		public string Lname { get; set; }
		public string Password { get; set; }
		public string Repassword { get; set; }
		public string Username { get; set; }

        public override string ToString()
        {
            return $"{this.Fname}  {this.Lname} {this.Username}";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static implicit operator UserControl(User v)
        {
            throw new NotImplementedException();
        }
    }
}
