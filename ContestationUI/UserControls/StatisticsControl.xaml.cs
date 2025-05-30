using Infra.Dtos;
using Infra.Enum;
using Infra.Models;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
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

namespace ContestationUI.UserControls
{
    /// <summary>
    /// Interaction logic for StatisticsControl.xaml
    /// </summary>
    public partial class StatisticsControl : UserControl
    {
        private readonly Infra.Services.Interfaces.HttpClientService _httpClientService;
        public Axis[] XAxes { get; set; }
        public Axis[] YAxes { get; set; }
        public ISeries[] MySeries { get; set; }
        public ISeries[] ResponsesPie { get; set; }
        public StatisticsControl(Infra.Services.Interfaces.HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }
        public StatisticsControl() : this(new Infra.Services.Classes.HttpClientService("https://localhost:7080/api/"))
        {
            InitializeComponent();

        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var opposers = new List<OpposerTask>();
            await _httpClientService.GetOpposersAsync(opposers);

            var acceptedCount = opposers.Count(x => x.DecisionType.Equals("ACCEPTED", StringComparison.InvariantCultureIgnoreCase));
            var rejectedCount = opposers.Count(x => x.DecisionType.Equals("REJECTED", StringComparison.InvariantCultureIgnoreCase));
            var noneCount = opposers.Count(x => x.DecisionType.Equals("NONE", StringComparison.InvariantCultureIgnoreCase));

            txtAcceptedAmount.Text = acceptedCount.ToString();
            txtRejectedAmount.Text = rejectedCount.ToString();
            txtNoneAmount.Text = noneCount.ToString();

            SetResponsePie(acceptedCount, rejectedCount, noneCount);

            SetBarChart(opposers);

            DataContext = this;
        }

        private void SetBarChart(List<OpposerTask> opposers)
        {
            var grouped = opposers
              .GroupBy(x => x.FineIssueDate)
              .OrderBy(g => g.Key)
              .ToList();

            var labels = grouped.Select(g => g.Key).ToArray();
            var values = grouped.Select(g => (int)g.Count()).ToArray();

            MySeries = new ISeries[]
            {
                 new ColumnSeries<int>
                 {
                     Values = values,
                     Name = "Fines Issued"
                 }
                     };

            XAxes = new Axis[]
            {
                 new Axis
                 {
                     Labels = labels,
                     LabelsRotation = 15, // rotates labels if they're too long
                     Name = "Date"
                 }
            };

            YAxes = new Axis[]
            {
                 new Axis
                 {
                     Name = "Count"
                 }
    };
        }

        private void SetResponsePie(int acceptedCount, int rejectedCount, int noneCount)
        {
            ResponsesPie = new ISeries[]
                       {
                            new PieSeries<int> { Values = new int[] {noneCount }, Name = "NONE" },
                            new PieSeries<int> { Values = new int[] { rejectedCount }, Name = "REJECTED" },
                            new PieSeries<int> { Values = new int[] { acceptedCount }, Name = "ACCEPTED" },
                       };
        }
    }
}
