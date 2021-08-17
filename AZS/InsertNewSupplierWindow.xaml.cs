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

namespace AZS
{
    /// <summary>
    /// Interaction logic for InsertNewSupplierWindow.xaml
    /// </summary>
    public partial class InsertNewSupplierWindow : Window
    {
        АЗСEntities db = new АЗСEntities();
        public InsertNewSupplierWindow()
        {
            InitializeComponent();
        }

        private void InsertSupplier_Click(object sender, RoutedEventArgs e)
        {
            if (NameOrgTB.Text == null)
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                Supplier su = new Supplier();
                su.Name = NameOrgTB.Text;
                su.Phone = decimal.Parse(PhoneTB.Text);
                su.Email = EmailTB.Text;
                db.Suppliers.Add(su);
                db.SaveChanges();
                this.Close();
                MessageBox.Show("Поставщик добавлен.");
            }
           
        }

        public bool AddSupplier(string NameOrg,  decimal PhoneNum, string Emaill)
        {
            
            var Test = db.Suppliers.Where(w => w.Name == NameOrg && w.Phone == PhoneNum && w.Email == Emaill).ToList();


            if (!Test.Any() && Test.Count == 0)
            {
                Supplier NewSupplier=new Supplier()
                {
                    Name = NameOrg,
                    Phone = PhoneNum,
                    Email=Emaill,
                };
                db.Suppliers.Add(NewSupplier);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
