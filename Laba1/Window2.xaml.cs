using System;
using System.Collections.Generic;
using System.Data;
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
using Laba1.BdDataSetTableAdapters;

namespace Laba1
{
    
    public partial class Window2 : Window
    {
        AdoptersTableAdapter adopters = new AdoptersTableAdapter();
        public Window2()
        {
            InitializeComponent();
            Grid2.ItemsSource = adopters.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] adoptins = TB2.Text.Split(';');

            string NameAdopter = adoptins[0];
            string SurnameAdopter = adoptins[1];
            string MiddlenameAdopter = adoptins[2];
            string Email = adoptins[3];
            string Phone = adoptins[4];
            string AddressAdopter = adoptins[5];
            string AdoptionDate = adoptins[6];
            int ID_Dog = int.Parse(adoptins[7]);

            adopters.AdoptersInsert(NameAdopter, SurnameAdopter, MiddlenameAdopter, Email, Phone, AddressAdopter, AdoptionDate, ID_Dog);
            Grid2.ItemsSource = adopters.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string[] adoptins = TB2.Text.Split(';');

            string NameAdopter = adoptins[0];
            string SurnameAdopter = adoptins[1];
            string MiddlenameAdopter = adoptins[2];
            string Email = adoptins[3];
            string Phone = adoptins[4];
            string AddressAdopter = adoptins[5];
            string AdoptionDate = adoptins[6];
            int ID_Dog = int.Parse(adoptins[7]);

            object id = (Grid2.SelectedItem as DataRowView).Row[0];
            adopters.AdoptersUpdate(NameAdopter, SurnameAdopter, MiddlenameAdopter, Email, Phone, AddressAdopter, AdoptionDate, ID_Dog,Convert.ToInt32(id));
            Grid2.ItemsSource = adopters.GetData();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object id = (Grid2.SelectedItem as DataRowView).Row[0];
            adopters.AdoptersDelete(Convert.ToInt32(id));
            Grid2.ItemsSource = adopters.GetData();
        }
    }
}
