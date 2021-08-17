using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaGaijinData
{
	public partial class User
	{

		public User()
		{
			Collection = new HashSet<MangaCollection>();
		}

		public int UserID { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public bool Admin { get; set; }

		public virtual ICollection<MangaCollection> Collection { get; set; }


	}
}
