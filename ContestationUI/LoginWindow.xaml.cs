using Infra.Dtos;
using Infra.Models;
using Infra.Singeltons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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

namespace ContestationUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly Infra.Services.Interfaces.HttpClientService _httpClientService;

        public LoginWindow(Infra.Services.Interfaces.HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }
        public LoginWindow() : this(new Infra.Services.Classes.HttpClientService("https://localhost:7080/api/"))
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }
        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var loggedIn =  await _httpClientService.LoginAsync(txtUserName.Text,txtPassword.Password, () =>
            {
                this.Hide();
                var window = new MainWindow();
                window.Show();
            });
            if (string.IsNullOrEmpty(loggedIn) is false)
            {
                MessageBox.Show(loggedIn);
            }
        }
    }
}
