using Infra.Dtos;
using Infra.Singeltons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
using Newtonsoft.Json;
using Infra.Models;
using System.IO;
using Infra.Enum;
using Infra.Mappers;
using Infra.Services.Interfaces;
using Infra.Services.Classes;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ContestationUI.UserControls
{
    /// <summary>
    /// Interaction logic for OpposerControls.xaml
    /// </summary>
    public partial class OpposerControl : UserControl
    {
        private List<OpposerTask> _opposers;
        private readonly Infra.Services.Interfaces.HttpClientService _httpClientService;

        public OpposerControl(Infra.Services.Interfaces.HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public OpposerControl() : this( new Infra.Services.Classes.HttpClientService("https://localhost:7080/api/"))
        {
            InitializeComponent();
            _opposers = new List<OpposerTask>();

            cmbDecisionType.ItemsSource = null;
            cmbDecisionType.ItemsSource = Enum.GetValues(typeof(DecisionType)).Cast<DecisionType>();
        }
       
        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var opposersTasks = new List<OpposerTask>();
            try
            {
                await GetOpposers(opposersTasks);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async Task GetOpposers(List<OpposerTask> opposersTasks)
        {
            await _httpClientService.GetOpposersAsync(opposersTasks, () =>
            {
                _opposers = opposersTasks;
                UpdateUI(opposersTasks);
            });
        }
        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var opposersTasks = new List<OpposerTask>();
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                opposersTasks = _opposers.ToList();
            }
            else
            {
                opposersTasks = _opposers.Where(x =>
              x.FineNumber.Contains(txtUserName.Text, StringComparison.InvariantCultureIgnoreCase) ||
              x.FullName.Contains(txtUserName.Text, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
            UpdateUI(opposersTasks);
        }

        private async void BtnDownload_Click(object sender, RoutedEventArgs e)
        {
            if (OpposersListView.SelectedItem is OpposerTask opposer)
            {
                await _httpClientService.DownloadPdfAsync(opposer, (file) =>
                {
                    PdfBrowser.Navigate(file);
                });
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void OpposersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OpposersListView.SelectedItem is OpposerTask opposer)
            {
                txtFineNumber.Text = opposer.FineNumber;
                txtReasonForContestation.Text = opposer.ReasonForContestation;
                var hasPdf = await _httpClientService.GetPdfByFineNumberAsync(opposer);
                if (hasPdf)
                {
                    BtnDownload.IsEnabled = true;
                    BtnDownload.Opacity = 1;
                }
                else
                {
                    BtnDownload.IsEnabled = false;
                    BtnDownload.Opacity = 0.5;
                }
            }
        }
        private async void BtnDecision_Click(object sender, RoutedEventArgs e)
        {
            var opposersTasks = new List<OpposerTask>();
            var insertResponse = "";
            if (string.IsNullOrEmpty(txtNotes.Text))
            {
                MessageBox.Show("Notes cannot be empty!");
                return;
            }
         
            if (cmbDecisionType.SelectedItem is DecisionType decisionType &&
                OpposersListView.SelectedItem is OpposerTask opposer)
            {

                var response = await _httpClientService.GetResponseByFineNumberAsync(opposer.FineNumber);
                if (response is not null)
                {
                    insertResponse = await _httpClientService.UpdateResponseAsync(opposersTasks, decisionType, opposer, txtNotes.Text, () =>
                    {
                        UpdateUI(opposersTasks);
                    });
                }
                else
                {
                     insertResponse = await _httpClientService.InsertResponseAsync(opposersTasks, decisionType, opposer, txtNotes.Text, () =>
                    {
                        UpdateUI(opposersTasks);
                    });
                }
      
                MessageBox.Show(insertResponse);
            }
            else
            {
                MessageBox.Show("Select a decision before submiting!");
            }
        }

        private void UpdateUI(List<OpposerTask> opposersTasks)
        {
            txtNotes.Text = "...";
            txtReasonForContestation.Text = "...";
            txtFineNumber.Text = "...";
            OpposersListView.ItemsSource = null;
            OpposersListView.ItemsSource = opposersTasks;
            txtAmount.Text = $"{_opposers.Count}/{_opposers.Count}";
        }

    }
}
