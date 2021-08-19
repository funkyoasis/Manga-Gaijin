using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaGaijinData
{
	public partial class MangaCollectionLink
	{
		public int MangaCollectionLinkId { get; set; }
		public int MangaId { get; set; }
		public int MangaCollectionId { get; set; }
		public int UserId { get; set; }
		public virtual ICollection<MangaCollection> Collection { get; set; }
		public virtual Manga Manga {get;set;}
		public virtual User User { get; set; }

		public override string ToString()
		{
			return Manga.MangaTitle;
		}
	}
	
}
