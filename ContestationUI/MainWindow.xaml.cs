using ContestationUI.UserControls;
using Infra.Singeltons;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContestationUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new MenuUserControl();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (UserSingleton.Instance.IsLoggedIn is false)
            {
              
                this.Hide();
                var login = new LoginWindow();
                login.Show();
            }
        }

        private void OpposersBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new OpposerControl();
        }

        private void MenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MenuUserControl();
        }

        private void StatisticsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new StatisticsControl();
        }
    }
}