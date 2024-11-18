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

namespace Assisgment_Desk
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        DesktoopEntities db = new DesktoopEntities();
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = username.Text;
            string password = pass.Password;
            var rec= db.Userrs.FirstOrDefault(x => x.Email == email && x.Passwordd==password);
            if (rec != null)
            {
                if (rec.Rolee == "manger")
                {
                    MessageBox.Show("Login success");

                    UserMangment u = new UserMangment();
                    NavigationService.Navigate(u);
                    return;

                }

                if (rec.Rolee == "empolyee")
                {
                    MessageBox.Show("Login success");
                    Task t = new Task();
                    NavigationService.Navigate(t);
                    return;

                }
            }

            else
            {
                MessageBox.Show("Invalid Email and password");
            }
            

        }
    }
}
