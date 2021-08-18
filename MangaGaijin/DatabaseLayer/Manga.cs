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
			Collection = new HashSet<MangaCollectionLink>();
		}

		public int MangaId { get; set; }
		public string MangaTitle { get; set; }
		public string Author { get; set; }
		public int Chapters { get; set; }
		public string PublishStatus { get; set; }

		public virtual ICollection<MangaCollectionLink> Collection { get; set; }

		public override string ToString()
		{
			return MangaTitle;
		}
	}
}
