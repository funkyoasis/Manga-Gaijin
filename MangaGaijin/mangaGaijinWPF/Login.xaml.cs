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
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class Login : Window

	{
		public MangaGaijinCollections _mangaGaijinCollections;
		public MangaGaijinUsers _mangaGaijinUsers;
		public MangaCollection _mangaCollection;
		public User _user;
		public MangaCollectionLink _mangaCollectionLink;
		public Login()
		{
			InitializeComponent();
		}

		private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
		{
			if (TextBoxUsername.Text != "" && PasswordBoxPassword.Password != "")
			{
				var y = new MangaGaijinUsers();
				var x = y.Login(TextBoxUsername.Text, PasswordBoxPassword.Password);
				if (x == true)
				{
					mangaGaijinWPF.MainWindow mainWindow = new mangaGaijinWPF.MainWindow();
					mainWindow.Show();
					this.Close();
				}
			}
			
		}
	}
}
