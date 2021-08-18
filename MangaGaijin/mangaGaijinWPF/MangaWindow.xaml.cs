using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MangaGaijinData;
using MangaGaijinBusiness;
namespace MangaGaijinWPF
{
	/// <summary>
	/// Interaction logic for MangaWindow.xaml
	/// </summary>
	public partial class MangaWindow : Window
	{
		public MangaGaijinCollections _mangaGaijinCollections;
		public MangaWindow()
		{
			InitializeComponent();
			PopulateAllManga();
		}

		public void PopulateAllManga()
		{
			_mangaGaijinCollections = new MangaGaijinCollections();
			var retrievedManga = _mangaGaijinCollections.RetrieveAllManga();
			listAllManga.ItemsSource = retrievedManga;
		}
	}
}
