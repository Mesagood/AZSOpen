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

namespace AZS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        АЗСEntities azsdb = new АЗСEntities();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void BtnSingIn_Click(object sender, RoutedEventArgs e)
        {
            SingIn(Log.Text, Pass.Password);
        }
        void SingIn(string login, string password)
        {
            //Авторизация 
            User user = azsdb.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
            if (user!=null)
            {
                DirectorWindow DW = new DirectorWindow();
                StaffWindow SW = new StaffWindow();
                switch (user.IdRole)
                {
                    case 1:
                        DW.Show();
                        this.Close();
                        break;
                    case 2:
                        SW.Show();
                        this.Close();
                        break;                      
                }
            }                                       
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
