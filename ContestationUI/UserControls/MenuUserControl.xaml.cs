using Infra.Dtos;
using Infra.Models;
using Infra.Singeltons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using System.IO;
namespace ContestationUI.UserControls
{
    /// <summary>
    /// Interaction logic for MenuUserControl.xaml
    /// </summary>
    public partial class MenuUserControl : UserControl
    {
        public MenuUserControl()
        {
            InitializeComponent();
        }
        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var path = System.IO.Path.Combine(Environment.CurrentDirectory, "govPicture.png");
            iconContestation.Source = new BitmapImage(new Uri(path));
            txtUserName.Text = $"Welcome {UserSingleton.Instance.User.UserName}";
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
