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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MangaGaijinData;
using MangaGaijinBusiness;
namespace mangaGaijinWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public MangaGaijinCollections _mangaGaijinCollections;
		public MangaGaijinUsers _mangaGaijinUsers;
		public MangaCollection _mangaCollection;
		public User _user;
		public MangaCollectionLink _mangaCollectionLink;
		public MainWindow()
		{
			InitializeComponent();
			PopulateAllMangaCollection();
			PopulateCompletedCollection();
			PopulateCurrentlyReadingCollection();
			PopulatePlanToReadCollection();
			PopulateFavouritesbox();
			PopulateRank();

		}

		public void PopulateAllMangaCollection()
		{
			_mangaGaijinCollections = new MangaGaijinCollections();
			var retrievedManga = _mangaGaijinCollections.RetrieveAllUserManga_Two('d');
			allMangaList.ItemsSource = retrievedManga;
		}

		public void PopulateCompletedCollection()
		{
			var retrievedManga = _mangaGaijinCollections.RetrieveAllUserManga_Two('a');
			CompletedMangaList.ItemsSource = retrievedManga;
		}

		public void PopulateCurrentlyReadingCollection()
		{
			var retrievedManga = _mangaGaijinCollections.RetrieveAllUserManga_Two('c');
			CurrentlyReadingMangaList.ItemsSource = retrievedManga;
		}

		public void PopulatePlanToReadCollection()
		{
			var retrievedManga = _mangaGaijinCollections.RetrieveAllUserManga_Two('b');
			PlanToReadMangaList.ItemsSource = retrievedManga;
		}

		public void UpdateList_Click(object sender, RoutedEventArgs e)
		{
			//this.Close();
			MangaGaijinWPF.MangaWindow mangaWindow = new MangaGaijinWPF.MangaWindow();
			mangaWindow.Show();
			

		}
		public void Refresh_Click(object sender, RoutedEventArgs e)
		{
			PopulateAllMangaCollection();
			PopulateCompletedCollection();
			PopulateCurrentlyReadingCollection();
			PopulatePlanToReadCollection();
			PopulateFavouritesbox();
		}

		public void PopulateFavouritesbox()
		{
			var retrievedfavourite = _mangaGaijinCollections.RetrieveFavouriteUserManga();
			ListBoxFavourites.ItemsSource = retrievedfavourite;
		}

		public void PopulateRank()
		{
			var retrievedmanga = _mangaGaijinCollections.RetrieveAllUserManga();
			if (retrievedmanga.Count >= 100)
			{
				TextBoxRank.Text = "True Manga God";
			}
			if (retrievedmanga.Count >= 50)
			{
				TextBoxRank.Text = "Manga Master";
			}

			if (retrievedmanga.Count >= 10)
			{
				TextBoxRank.Text = "Way of Manga";
			}
			else
			{
				TextBoxRank.Text = "Novice";
			}
		}
	}

}
