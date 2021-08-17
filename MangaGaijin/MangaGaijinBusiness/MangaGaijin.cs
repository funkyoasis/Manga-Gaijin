using System;
using DatabaseLayer;
using MangaGaijinData;
using System.Collections.Generic;
using System.Linq;

namespace MangaGaijinBusiness
{
	public class MangaGaijinUsers
	{



		//User classes

		//select a User
		public User SelectedUser { get; set; }

		public void SetSelectedUser(object SelectedItem)
		{
			SelectedUser = (User)SelectedItem;
		}

		//retrieve all Users 
		public List<User> RetrieveUsers()
		{
			using (var db = new MangaGaijinContext())
			{
				return db.Users.ToList();
			}
		}

		//create a new user
		//Admin
		public void CreateAdmin(string username, string password, bool admin) 
		{
			var newAdmin = new User() { UserName = username, Password = password, Admin = admin };
			using (var db = new MangaGaijinContext())
			{
				db.Users.Add(newAdmin);
				db.SaveChanges();
			}
		}
		//User
		public void CreateUser(string username, string password)
		{
			var newUser = new User() { UserName = username, Password = password, Admin = false };
			using (var db = new MangaGaijinContext())
			{
				if (db.Users.Where(u => u.UserName == username).Count() == 1)
				{
					throw new ArgumentException("User Already exists");
				}
				else
				{
					db.Users.Add(newUser);
					db.SaveChanges();
				}
			}
		}

	}
}
