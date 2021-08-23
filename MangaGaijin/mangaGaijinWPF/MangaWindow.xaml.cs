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

		
		//Displays The user's manga Collection
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
				PopulateAllMangaCollection();
			}
		}
		private void ContextAddToCompleted_Click(object sender, RoutedEventArgs e)
		{
			if (ListBoxAllManga.SelectedItem != null)
			{
				_mangaGaijinCollections.SetSelectedManga(ListBoxAllManga.SelectedItem);
				var rating = Convert.ToDouble(textBoxRating_Completed.Text);
				_mangaGaijinCollections.AddToMangaCollection("Completed",rating,null);
				PopulateAllMangaCollection();
			}

		}
		private void ContextAddToPlanToRead_Click(object sender, RoutedEventArgs e)
		{
			if (ListBoxAllManga.SelectedItem != null)
			{
				_mangaGaijinCollections.SetSelectedManga(ListBoxAllManga.SelectedItem);
				_mangaGaijinCollections.AddToMangaCollection("Plan To Read", null, null);
				PopulateAllMangaCollection();
			}
		}

		private void Button_DeleteUserManga_Click(object sender, RoutedEventArgs e)
		{
			if (ListBoxAllUserManga.SelectedItem != null)
			{
				_mangaGaijinCollections.SetSelectedMangaCollectionLink(ListBoxAllUserManga.SelectedItem);
				_mangaGaijinCollections.DeleteFromUserMangaSelected();
				PopulateAllMangaCollection();
			}

		}


		public void ContextEditToPlanToRead_Click(object sender, RoutedEventArgs e)
		{
			if (ListBoxAllUserManga.SelectedItem != null)
			{
				_mangaGaijinCollections.SetSelectedMangaCollectionLink(ListBoxAllUserManga.SelectedItem);
				_mangaGaijinCollections.UpdateUserManga("Plan To Read", null, null);
				PopulateAllMangaCollection();
			}
		}

		public void ContextEditToCompleted_Click(object sender, RoutedEventArgs e)
		{
			if (ListBoxAllUserManga.SelectedItem != null)
			{
				_mangaGaijinCollections.SetSelectedMangaCollectionLink(ListBoxAllUserManga.SelectedItem);
				var rating = Convert.ToDouble(textBoxEditRating_Completed.Text);
				_mangaGaijinCollections.UpdateUserManga("Completed", rating, null);
				PopulateAllMangaCollection();
			}
		}

		public void ContextEditToReading_Click(object sender, RoutedEventArgs e)
		{
			if (ListBoxAllUserManga.SelectedItem != null)
			{
				_mangaGaijinCollections.SetSelectedMangaCollectionLink(ListBoxAllUserManga.SelectedItem);
				var CurrentRating = Convert.ToDouble(textBoxEditRating_Reading.Text);
				var chapterNo = Convert.ToInt32(textBoxEditChapterNo_Reading.Text);
				_mangaGaijinCollections.UpdateUserManga("Currently Reading", CurrentRating,chapterNo);
				PopulateAllMangaCollection();

			}
		}

		public void ButtonReturn_Click(object sender, RoutedEventArgs e)
		{
			mangaGaijinWPF.MainWindow mw = new mangaGaijinWPF.MainWindow();
			Close();
			
		}
		
	}
}
