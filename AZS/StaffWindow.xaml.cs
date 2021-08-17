using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AZS
{
    /// <summary>
    /// Interaction logic for StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        MainWindow MW = new MainWindow();
        АЗСEntities db = new АЗСEntities();
        public StaffWindow()
        {
            InitializeComponent();
            OptionGrid.ItemsSource = db.OrdersFromSuppliers.ToList();

            ShowCharting();
        }

        void ShowCharting()
        {
            charting.ChartAreas.Add(new ChartArea("Default"));
            charting.Series.Add(new Series("Series1"));
            charting.Series["Series1"].ChartType = SeriesChartType.Pie;
            charting.DataSource = db.GasStations.ToList();
            charting.Series["Series1"].XValueMember = "Name";
            charting.Series["Series1"].XValueType = ChartValueType.String;
            charting.Series["Series1"].YValueMembers = "CountPetrol";
            charting.Series["Series1"].YValueType = ChartValueType.Int32;
            int count = 0;
            foreach (var item in db.GasStations)
            {
                count += item.CountPetrol;
            }
            List<GasStation> gasStations = new List<GasStation>();
            gasStations = db.GasStations.ToList();
            gasStations.Insert(0, new GasStation { Name = "Сумма", CountPetrol = count });
            Gas.ItemsSource = gasStations;
        }

        private void ReLog_Click(object sender, RoutedEventArgs e)
        {
            MW.Show();
            this.Close();

        }
    }
}
