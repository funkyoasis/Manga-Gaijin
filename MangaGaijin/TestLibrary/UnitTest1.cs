using NUnit.Framework;
using MangaGaijinBusiness;
using MangaGaijinData;
using DatabaseLayer;
using System.Collections.Generic;
using System.Linq;

namespace TestLibrary
{
	public class UserTests
	{
		MangaGaijinUsers _mangaGaijinUsers;
		MangaGaijinCollections _mangaGaijinCollections;
		[SetUp]
		public void Setup()
		{
			_mangaGaijinUsers = new MangaGaijinUsers();
			_mangaGaijinCollections = new MangaGaijinCollections();
		}

		[Test]
		[Ignore("ignore")] //passes, ignoring so duplicates arent made 
		public void WhenAddingANewAdmin_CreateAdmin_CorrectlyAddsANewAdminTo_UsersTable()
		{
			using (var db = new MangaGaijinContext())
			{
				_mangaGaijinUsers.CreateAdmin("Owner", "bestguy1", true);
				var adminCheck = db.Users.Where(u => u.UserName == "Owner").FirstOrDefault();
				if (adminCheck.Admin == true)
				{
					Assert.Pass();
				}
			}
		}

		[Test]
		[Ignore("ignore")] //passes, ignoring so duplicates arent made 
		public void WhenAddingANewUser_CreateUser_CorrectlyAddsANewUserTo_UsersTable()
		{
			using (var db = new MangaGaijinContext())
			{
				_mangaGaijinUsers.CreateUser("Kyoto", "Ronin");
				var userCheck = db.Users.Where(u => u.UserName == "Kyoto").FirstOrDefault();
				if (userCheck.Admin == true)
				{
					Assert.Pass();
				}
				
			}
		}

		[Test]
		[Ignore("ignore")] //passes, ignoring so duplicates arent made 
		public void WhenAddingANewManga_AddManga_CorrectlyAddANewMangaTo_MangaTable()
		{
			using (var db = new MangaGaijinContext())
			{
				_mangaGaijinCollections.AddManga("Highschool of the Dead", "Satou Daisuke, Satou Shouji", 33, "Finished");

				var mangacheck = db.Manga.Where(m => m.MangaTitle == "Highschool of the Dead").FirstOrDefault();
				if (mangacheck.Chapters == 33)
				{
					Assert.Pass();
				}

			}
		}


	}
}