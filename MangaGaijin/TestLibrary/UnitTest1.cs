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
		[SetUp]
		public void Setup()
		{
			_mangaGaijinUsers = new MangaGaijinUsers();
		}

		[Test]
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


	}
}