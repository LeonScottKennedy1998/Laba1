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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Laba1.BdDataSetTableAdapters;

namespace Laba1
{ 
    public partial class MainWindow : Window
    {
        DogsTableAdapter dogs = new DogsTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            Grid1.ItemsSource = dogs.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] dogsins = TB1.Text.Split(' ');

            string name = dogsins[0];
            string breed = dogsins[1];
            int age = int.Parse(dogsins[2]);
            string gender = dogsins[3];
            string size = dogsins[4];
            string arrivalDate = dogsins[5];
            string isAdopted = dogsins[6];

            dogs.DogsInsert(name, breed, age, gender, size, arrivalDate, isAdopted);
            Grid1.ItemsSource = dogs.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string[] dogsupd = TB1.Text.Split(' ');

            string name = dogsupd[0];
            string breed = dogsupd[1];
            int age = int.Parse(dogsupd[2]);
            string gender = dogsupd[3];
            string size = dogsupd[4];
            string arrivalDate = dogsupd[5];
            string isAdopted = dogsupd[6];

            object id = (Grid1.SelectedItem as DataRowView).Row[0];

            dogs.DogsUpdate(name, breed, age, gender, size, arrivalDate, isAdopted, Convert.ToInt32(id));
            Grid1.ItemsSource = dogs.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object id = (Grid1.SelectedItem as DataRowView).Row[0];
            dogs.DogsDelete(Convert.ToInt32(id));
            Grid1.ItemsSource = dogs.GetData();
        }
    }
}
