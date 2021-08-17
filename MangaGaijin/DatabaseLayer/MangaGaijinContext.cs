using System;
using MangaGaijinData;
using Microsoft.EntityFrameworkCore;
namespace DatabaseLayer
{
	public partial class MangaGaijinContext : DbContext
	{
		public static MangaGaijinContext Instance { get; set; } = new MangaGaijinContext();
		public DbSet<User> Users { get; set; }
		
		public DbSet<Manga> Manga { get; set; }

		public DbSet<MangaCollection> MangaCollections { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			{
				{
					optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MangaGaijin;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
				}
			}
		}

	}

}
