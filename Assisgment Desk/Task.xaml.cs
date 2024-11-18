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

namespace Assisgment_Desk
{
    /// <summary>
    /// Interaction logic for Task.xaml
    /// </summary>
    public partial class Task : Page
    {
        DesktoopEntities db = new DesktoopEntities();
        public Task()
        {
            InitializeComponent();
            

            Datagrid.ItemsSource = db.Tasks.Select(x => new { x.Taskid, x.Title, x.Descriptionn, x.Statuss }).Where(x => x.Statuss == "Pending" || x.Statuss == "In Progress").ToList();
            datagrid.ItemsSource = db.Tasks.Select(x => new { x.Taskid, x.Title, x.Descriptionn, x.Statuss }).Where(x => x.Statuss == "Completed").ToList();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int iid = int.Parse(id.Text);
            var rec = db.Tasks.FirstOrDefault(x => x.Taskid == iid);
            if (rec != null)
            {
                if (Combo.Text == "Completed")
                {
                    rec.Statuss = Combo.Text;
                    db.Tasks.AddOrUpdate(rec);
                    db.SaveChanges();
                }
                Datagrid.ItemsSource = db.Tasks.Select(x => new { x.Taskid, x.Title, x.Descriptionn, x.Statuss }).Where(x => x.Statuss == "Completed").ToList();
                datagrid.ItemsSource = db.Tasks.Select(x => new { x.Taskid, x.Title, x.Descriptionn, x.Statuss }).Where(x => x.Statuss == "Pending" || x.Statuss == "In Progress").ToList();
            }
            else
            {
                MessageBox.Show("invaild id");
            }
        }
    }                                                   
}
