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
    /// Interaction logic for DirectorWindow.xaml
    /// </summary>
    public partial class DirectorWindow : Window
    {
        MainWindow MW = new MainWindow();
        АЗСEntities db = new АЗСEntities();
        public DirectorWindow()
        {
            InitializeComponent();
            OptionGrid.ItemsSource = db.OrdersFromSuppliers.ToList();
            StaffGrid.ItemsSource = db.Users.ToList();
            SuppliersGrid.ItemsSource = db.Suppliers.ToList();

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

        private void BtnNewStaff_Click(object sender, RoutedEventArgs e)
        {
            InsertUserWindow IUW = new InsertUserWindow();
            IUW.Show();
        }

        private void BtnKickStaff_Click(object sender, RoutedEventArgs e)
        {
            User us = StaffGrid.SelectedItem as User;
            db.Users.Remove(us);
            db.SaveChanges();
            StaffGrid.ItemsSource = db.Users.ToList();
            MessageBox.Show("Пользователь удален.");
        }

        private void UpdateStaff_Click(object sender, RoutedEventArgs e)
        {
            StaffGrid.ItemsSource = db.Users.ToList();
        }

        private void NewOrder_Click(object sender, RoutedEventArgs e)
        {
            InsertNewSupplierWindow INSW = new InsertNewSupplierWindow();
            INSW.Show();
        }

        private void DeliteOrder_Click(object sender, RoutedEventArgs e)
        {
            Supplier su = SuppliersGrid.SelectedItem as Supplier;
            db.Suppliers.Remove(su);
            db.SaveChanges();
            SuppliersGrid.ItemsSource = db.Suppliers.ToList();
            MessageBox.Show("Поставщик удален.");
            
        }

        private void UpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            SuppliersGrid.ItemsSource = db.Suppliers.ToList();
        }

        public bool deleteRole(int idd)
        {

            АЗСEntities connector = new АЗСEntities();
            if (idd != 0 || idd != -1)
            {
                var dlee = connector.Roles.Where(w => w.IdRole == idd).ToList();
                if (dlee.Count != 0 && dlee.Any())
                {
                    var dlee1 = connector.Roles.Where(w => w.IdRole == idd).FirstOrDefault();
                    connector.Roles.Remove(dlee1);
                    connector.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }        
      
        public bool DeliteUser( int idd)
        {
            АЗСEntities connector = new АЗСEntities();
            if (idd != 0 || idd != -1)
            {
                var dlee = connector.Users.Where(w => w.IdUser == idd).ToList();
                if (dlee.Count != 0 && dlee.Any())
                {
                    var dlee1 = connector.Users.Where(w => w.IdUser == idd).FirstOrDefault();
                    connector.Users.Remove(dlee1);
                    connector.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        public bool DeliteSupplier(int idd)
        {
            АЗСEntities connector = new АЗСEntities();
            if (idd != 0 || idd != -1)
            {
                var dlee = connector.Suppliers.Where(w => w.IdSupplier == idd).ToList();
                if (dlee.Count != 0 && dlee.Any())
                {
                    var dlee1 = connector.Suppliers.Where(w => w.IdSupplier == idd).FirstOrDefault();
                    connector.Suppliers.Remove(dlee1);
                    connector.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
