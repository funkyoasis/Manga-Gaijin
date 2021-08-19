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
		public MangaGaijinUsers _mangaGaijinUsers;
		public MangaCollection _mangaCollection;
		public User _user;
		public MangaCollectionLink _mangaCollectionLink;
		public MangaWindow()
		{
			InitializeComponent();
			PopulateAllManga();
			PopulateAllMangaCollection();
		}

		public void PopulateAllManga()
		{
			_mangaGaijinCollections = new MangaGaijinCollections();
			var retrievedManga = _mangaGaijinCollections.RetrieveAllManga();
			ListBoxAllManga.ItemsSource = retrievedManga;
		}

		
		public void PopulateAllMangaCollection()
		{
			//var mangas = new Manga();
			var retrievedCollection = _mangaGaijinCollections.RetrieveAllUserManga();
			ListBoxAllUserManga.ItemsSource = retrievedCollection;
			
		}
		

		private void ListBoxAllManga_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (ListBoxAllManga.SelectedItem != null)
			{
				//_mangaGaijinCollections.SetSelectedManga(ListBoxAllManga.SelectedItem);

			}
		}

		private void ContextAddToReading_Click(object sender, RoutedEventArgs e)
		{
			if (ListBoxAllManga.SelectedItem != null)
			{
				_mangaGaijinCollections.SetSelectedManga(ListBoxAllManga.SelectedItem);
				var ratingNo = Convert.ToDouble(textBoxRating_Reading.Text);
				var chapterNo = Convert.ToInt32(textBoxChapterNo_Reading.Text);
				_mangaGaijinCollections.AddToMangaCollection("Currently Reading", ratingNo, chapterNo);
			}
		}
		private void ContextAddToCompleted_Click(object sender, RoutedEventArgs e)
		{
			if (ListBoxAllManga.SelectedItem != null)
			{
				_mangaGaijinCollections.SetSelectedManga(ListBoxAllManga.SelectedItem);
				var chapterNo = Convert.ToInt32(textBoxRating_Completed.Text);
				_mangaGaijinCollections.AddToMangaCollection("Completed",chapterNo,null);
			}

		}
		private void ContextAddToPlanToRead_Click(object sender, RoutedEventArgs e)
		{
			if (ListBoxAllManga.SelectedItem != null)
			{
				_mangaGaijinCollections.SetSelectedManga(ListBoxAllManga.SelectedItem);
				_mangaGaijinCollections.AddToMangaCollection("Plan To Read", null, null);
			}
		}
	}
}
