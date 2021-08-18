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
		[Ignore("ignore")]
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
		[Ignore("ignore")]
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
		public void WhenAddingANewManga_AddManga_CorrectlyAddANewMangaTo_MangaTable()
		{
			using (var db = new MangaGaijinContext())
			{
				_mangaGaijinCollections.AddManga("Haikyuu", "Haruichi Furudate", 407, "Finished");
				_mangaGaijinCollections.AddManga("OnePiece", "Eiichiro Oda", 1021, "Publishing");
				_mangaGaijinCollections.AddManga("I Am a Hero", "Hanazawa Kengo", 264, "Finished");
				_mangaGaijinCollections.AddManga("Homunculus", "Yamamoto Hideo", 166, "Finished");
				var mangacheck = db.Manga.Where(m => m.MangaTitle == "Haikyuu").FirstOrDefault();
				if (mangacheck.Chapters == 407)
				{
					Assert.Pass();
				}

			}
		}


	}
}