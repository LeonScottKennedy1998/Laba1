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

namespace Laba1
{
    public partial class Window4 : Window
    {
        private DogPriutEntities dogpriut = new DogPriutEntities();
        public Window4()
        {
            InitializeComponent();
            Grid4.ItemsSource = dogpriut.Adopters.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Adopters a = new Adopters();

            string[] adopt = TB4.Text.Split(';');

            a.NameAdopter = adopt[0];
            a.SurnameAdopter = adopt[1];
            a.MiddlenameAdopter = adopt[2];
            a.Email = adopt[3];
            a.Phone = adopt[4];
            a.AddressAdopter = adopt[5];
            a.AdoptionDate = DateTime.Parse(adopt[6]);
            a.ID_Dog = int.Parse(adopt[7]);

            dogpriut.Adopters.Add(a);

            dogpriut.SaveChanges();
            Grid4.ItemsSource = dogpriut.Adopters.ToList();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Grid4.SelectedItem != null)
            {
                var selected = Grid4.SelectedItem as Adopters;

                string[] adopt = TB4.Text.Split(';');
                selected.NameAdopter = adopt[0];
                selected.SurnameAdopter = adopt[1];
                selected.MiddlenameAdopter = adopt[2];
                selected.Email = adopt[3];
                selected.Phone = adopt[4];
                selected.AddressAdopter = adopt[5];
                selected.AdoptionDate = DateTime.Parse(adopt[6]);
                selected.ID_Dog = int.Parse(adopt[7]);

                dogpriut.SaveChanges();
                Grid4.ItemsSource = dogpriut.Adopters.ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Grid4.SelectedItem != null)
            {
                dogpriut.Adopters.Remove(Grid4.SelectedItem as Adopters);
                dogpriut.SaveChanges();
                Grid4.ItemsSource = dogpriut.Adopters.ToList();
            }
        }

        private void Grid4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Grid4.SelectedItem != null)
            {
                var selected = Grid4.SelectedItem as Adopters;
                TB4.Text = $"{selected.NameAdopter};{selected.SurnameAdopter};{selected.MiddlenameAdopter};" +
                    $"{selected.Email};{selected.Phone};{selected.AddressAdopter};" +
                    $"{Convert.ToDateTime(selected.AdoptionDate).ToString("dd.MM.yyyy")};{selected.ID_Dog}";
            }
        }
    }
}
