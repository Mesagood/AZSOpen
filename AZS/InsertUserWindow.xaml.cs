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
    /// Interaction logic for InsertUserWindow.xaml
    /// </summary>
    public partial class InsertUserWindow : Window
    {
        АЗСEntities db = new АЗСEntities();

        public InsertUserWindow()
        {
            InitializeComponent();
        }

        private void InsertUser_Click(object sender, RoutedEventArgs e)
        {
            if ((FirstNameTB.Text.Equals("")))
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                User Us = new User();
                Us.FirstName = FirstNameTB.Text;
                Us.MiddleName = MiddleNameTB.Text;
                Us.LastName = LastNameTB.Text;
                Us.Login = LoginTB.Text;
                Us.Password = PasswordPB.Text;
                Us.IdRole = int.Parse(RoleIDTB.Text);
                db.Users.Add(Us);
                db.SaveChanges();
                this.Close();
                MessageBox.Show("Пользователь добавлен.");
            }

        }

        public bool AddUser(string FName, string MName, string LName, string LLogin, string PPassword, int IDD)
        {

            var Test = db.Users.Where(w => w.FirstName == FName && w.MiddleName == MName && w.LastName == LName && w.Login == LLogin && w.Password == PPassword && w.IdRole==IDD).ToList();


            if (!Test.Any() && Test.Count == 0)
            {
                User NewUser = new User()
                {
                    FirstName = FName,
                    MiddleName = MName,
                    LastName = LName,
                    Login = LLogin,
                    Password = PPassword,
                    IdRole = IDD,
                };
                db.Users.Add(NewUser);
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
