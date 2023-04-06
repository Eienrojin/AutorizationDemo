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

namespace AutorizationDemo
{
    /// <summary>
    /// Логика взаимодействия для UserTablePage.xaml
    /// </summary>
    public partial class UserTablePage : Page
    {
        AutorizationTestEntities db = new AutorizationTestEntities();

        public UserTablePage()
        {
            InitializeComponent();
            
            if (Autorization.User.Role != 1)
                AdminPanelGrid.Visibility = Visibility.Collapsed;

            MainDataGrid.ItemsSource = db.Users.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var user = new Users();
            var success = true;
            user.Login = LoginTextBox.Text.Trim();
            user.Password = PasswordTextBox.Text.Trim();
            user.Role = int.Parse(RoleTextBox.Text.Trim());

            try
            {
                db.Users.Add(user);
            }
            catch (Exception)
            {
                success = false;
            }

            if (success)
            {
                db.SaveChanges();
                MainDataGrid.ItemsSource = null;
                MainDataGrid.ItemsSource = db.Users.ToList();
            }
        }
    }
}
