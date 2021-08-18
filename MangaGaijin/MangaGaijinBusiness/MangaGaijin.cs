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

	//class for methods relating to manga/mangaCollections Tables
	public class MangaGaijinCollections
	{
		//Call All Manga Titles
		public List<Manga> RetrieveAllManga()
		{
			using (var db = new MangaGaijinContext())
			{
				return db.Manga.ToList();
			}
		}
		//add a new Manga to Manga table
		public void AddManga(string mangaTitle, string author,  int chapters, string publishStatus)
		{
			var newManga = new Manga() { MangaTitle = mangaTitle, Author = author, Chapters = chapters, PublishStatus = publishStatus };
			using (var db = new MangaGaijinContext())
			{
				if (db.Manga.Where(m => m.MangaTitle == mangaTitle && m.Chapters == chapters).Count() == 1)
				{
					throw new ArgumentException("Manga Already exists");
				}
				else
				{
					db.Manga.Add(newManga);
					db.SaveChanges();
				}
			}
			
		}

		public void AddToUserCollection(string status, double rating, int chapterNo, int mangaId, int userId, int collectionId)
		{


		}



	}
}
