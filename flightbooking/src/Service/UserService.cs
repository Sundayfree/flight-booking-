using flightbooking.Dao;
using flightbooking.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightbooking.Service
{
	class UserService
	{
		private bool islogin = false;
		private string name;
	    
		public User getCurrentUser()
		{
			List<User> users = UserManager.getUserList();
			return users.Find(u => u.Username == this.name);
		}


		public bool IsLogion()
		{
			return this.islogin;
		}
		public bool login(string name, string password)
		{
			if (String.IsNullOrEmpty(name))
			{
				throw new Exception("please enter name");
			}
			if (String.IsNullOrEmpty(password))
			{
				throw new Exception("please enter password");
			}
			List<User> users = UserManager.getUserList();
           User user = users.Find(u=>u.Username.Equals(name));
            if (user == null)
            {
                throw new Exception("User doesnot exist, please register..");
            }
            else
            {
               user= users.Find(u => u.Password.Equals(password));
                if(user == null)
                {
                    throw new Exception("wrong password...");
                }
            }
			bool result= users.Exists(u => name.Equals(u.Username) && password.Equals(u.Password));
			if (result)
			{
				this.name = name;
				islogin = false;
				return true;
			}
			return false;
		}
		public void Save(string name, string password, string repassword, string fname,string lname)
		{

			if (String.IsNullOrEmpty(name))
			{
				throw new Exception("please enter name");
			}
			if (String.IsNullOrEmpty(password))
			{
				throw new Exception("please enter password");
			}
			if (String.IsNullOrEmpty(repassword))
			{
				throw new Exception("please enter repassword");
			}
			if (String.IsNullOrEmpty(fname))
			{
				throw new Exception("please enter yor fisrt name");
			}
			if (String.IsNullOrEmpty(lname))
			{
				throw new Exception("please enter yor last name");
			}
			if (password != repassword)
			{
				throw new Exception("please enter the same password");
			}


			List<User> users = UserManager.getUserList();
			users.ForEach(u =>
			{
				if (name.Equals(u.Username) )
				{
					throw new Exception("User already exist...");
				}
			});
			UserManager.save( name, password, fname,lname);
		}

        internal void ChangePassword(string oldP, string newP, string rPass, User user)
        {
            if (!oldP.Equals(user.Password))
                throw new Exception("your password is not correct..");
            if(oldP.Equals(newP))
                throw new Exception("do not enter the same password..");
            if(!newP.Equals(rPass))
                throw new Exception("new password is not same as repasword..");
            user.Password = newP;
            user.Repassword = rPass;
        
        }

    }
}
