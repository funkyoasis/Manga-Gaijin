using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaGaijinData
{
	public partial class MangaCollection
	{

		public MangaCollection()
		{
		}

		public int MangaCollectionId { get; set; }
		public int MangaId { get; set; }
		public string MangaTitle { get; set; }
		public string Author { get; set; }
		public string Chapters { get; set; }
		public string Status { get; set; }
		public double Rating { get; set; }
		public int chapterNo { get; set; }

	}
}
