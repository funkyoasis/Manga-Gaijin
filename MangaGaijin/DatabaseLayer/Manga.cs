using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaGaijinData
{
	public partial class Manga
	{
		public Manga()
		{ 
		}

		public int MangaId { get; set; }
		public string MangaTitle { get; set; }
		public string Author { get; set; }
		public string Chapters { get; set; }
		public string PublishStatus { get; set; }

	}
}
