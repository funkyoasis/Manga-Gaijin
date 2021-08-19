using System;
using DatabaseLayer;
using MangaGaijinData;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace MangaGaijinBusiness
{
	public class MangaGaijinUsers
	{



		//User classes

		//select a User
		public User SelectedUser { get; set; }
		public User DefaultUser { get; set; }
		public User SetDefaultUser()
		{
			using (var db = new MangaGaijinContext())
			{
				return DefaultUser = db.Users.FirstOrDefault();
			}
		}
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
		MangaGaijinUsers _mangaGaijinUsers = new MangaGaijinUsers();
		User _user = new User();
		//Select a single Title
		public Manga SelectedManga { get; set; }

		public void SetSelectedManga(object selectedItem)
		{
			SelectedManga = (Manga)selectedItem;
		}

		//Call All Manga Titles
		public List<Manga> RetrieveAllManga()
		{
			using (var db = new MangaGaijinContext())
			{
				return db.Manga.ToList();
			}
		}

		//Call All Manga in collection
	
		public List<MangaCollectionLink> RetrieveAllUserManga()
		{
			
		
			using (var db = new MangaGaijinContext())
			{
				 var mangaQuery = db.MangaCollectionLink.Include(m=>m.Manga).Include(mc =>mc.Collection).Where(mcl=>mcl.UserId== _mangaGaijinUsers.SetDefaultUser().UserID).ToList();

				/*
				from mcl in db.MangaCollectionLink
				join mc in db.MangaCollections on mcl.MangaCollectionId equals mc.MangaCollectionId
				join m in db.Manga on mcl.MangaId equals m.MangaId
				where mcl.UserId == _mangaGaijinUsers.SetDefaultUser().UserID
				select new { MangaTitle = m.MangaTitle, Author = m.Author, ReadingStatus = mc.Status, Rating = mc.Rating };
			*/
				return mangaQuery;
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

		public void AddToMangaCollection(string status, double? rating, int? chapterNo)
		{
			var newCollectionItem = new MangaCollection() { Status = status, Rating = rating, chapterNo = chapterNo };
			var newCollectionLink = new MangaCollectionLink();
			newCollectionLink.MangaId = SelectedManga.MangaId;
			int id = newCollectionLink.MangaId;
			newCollectionLink.UserId = _mangaGaijinUsers.SetDefaultUser().UserID;
			using (var db = new MangaGaijinContext())
			{
				if (db.MangaCollectionLink.Where(mc => mc.MangaId == newCollectionLink.MangaId && mc.UserId == newCollectionLink.UserId).Count() == 1)
				{
					throw new ArgumentException("Manga Already In User's List");
				}
				else
				{
					db.MangaCollections.Add(newCollectionItem);
					db.SaveChanges();
					using (var db2 = new MangaGaijinContext())
					{
						newCollectionLink.MangaCollectionId = db2.MangaCollections.OrderBy(mc =>mc.MangaCollectionId).Last().MangaCollectionId;
						db2.MangaCollectionLink.Add(newCollectionLink);
						db2.SaveChanges();
					}
						
				}
			}

		}



	}
}
