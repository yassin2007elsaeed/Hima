using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using System.Data.Entity;
using System.Security.Cryptography;

namespace Assisgment_Desk
{
    /// <summary>
    /// Interaction logic for UserMangment.xaml
    /// </summary>
    public partial class UserMangment : Page
    {
        DesktoopEntities db = new DesktoopEntities();
        public UserMangment()
        {
            InitializeComponent();
            Datagrid.ItemsSource = db.Tasks.Include(x => x.Userr).Select(x => new { x.Userr.Namee, x.Taskid, x.Title, x.Descriptionn, x.Statuss }).ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Task tasks = new Task();

            tasks.Title = name.Text;
            tasks.Descriptionn = Des.Text;
            tasks.Statuss = comb.Text;
            Userr users = new Userr();

            users = db.Userrs.FirstOrDefault(x => x.Email == Email.Text);

            if (users == null)
            {
                MessageBox.Show("Invaild email");
            }
            else
            {
                tasks.Userid = users.Userid;
            }
            db.Tasks.Add(tasks);
            db.SaveChanges();

            MessageBox.Show("Task added");
            refresh();

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(Id.Text);
            Task t = db.Tasks.Remove(db.Tasks.First(x => x.Taskid == id));
            db.SaveChanges();
            MessageBox.Show("Record deleted");
            refresh();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Task tasks = new Task();

            tasks.Title = name.Text;
            tasks.Descriptionn = Des.Text;
            tasks.Statuss = comb.Text;
            Userr users = new Userr();

            users = db.Userrs.FirstOrDefault(x => x.Email == Email.Text);

            if (users == null)
            {
                MessageBox.Show("Invaild email");
            }
            else
            {
                tasks.Userid = users.Userid;
            }
            db.Tasks.AddOrUpdate(tasks);
            db.SaveChanges();

            MessageBox.Show("Updated");
            refresh();

        }
        public void refresh()
        {
            Datagrid.ItemsSource = db.Tasks.Select(x => new { x.Userr.Email, x.Userid, x.Taskid, x.Title, x.Descriptionn, x.Statuss }).ToList();

        }


    }
}
