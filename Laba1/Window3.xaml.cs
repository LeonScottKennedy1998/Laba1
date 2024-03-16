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
   
    public partial class Window3 : Window
    {
        private DogPriutEntities dogpriut = new DogPriutEntities();
        public Window3()
        {
            InitializeComponent();
            Grid3.ItemsSource = dogpriut.Dogs.ToList();
        }

        // Добавление
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dogs d = new Dogs();

            string[] dog = TB3.Text.Split(' ');

            d.NameDog = dog[0];
            d.Breed = dog[1];
            d.Age = int.Parse(dog[2]);
            d.Gender = dog[3];
            d.Size = dog[4];
            d.ArrivalDate = DateTime.Parse(dog[5]);
            d.IsAdopted = dog[6];

            dogpriut.Dogs.Add(d);

            dogpriut.SaveChanges();
            Grid3.ItemsSource = dogpriut.Dogs.ToList();

        }

        // Изменение
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Grid3.SelectedItem != null)
            {
                var selected = Grid3.SelectedItem as Dogs;
                string[] dog = TB3.Text.Split(' ');
                selected.NameDog = dog[0];
                selected.Breed = dog[1];
                selected.Age = int.Parse(dog[2]);
                selected.Gender = dog[3];
                selected.Size = dog[4];
                selected.ArrivalDate = DateTime.Parse(dog[5]);
                selected.IsAdopted = dog[6];

                dogpriut.SaveChanges();
                Grid3.ItemsSource = dogpriut.Dogs.ToList();
            }
        }

        // Удаление
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Grid3.SelectedItem != null)
            {
                dogpriut.Dogs.Remove(Grid3.SelectedItem as Dogs);
                dogpriut.SaveChanges();
                Grid3.ItemsSource = dogpriut.Dogs.ToList();
            }
        }

        // Выгрузка данных в TextBox
        private void Grid3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Grid3.SelectedItem != null) 
            {
                var selected = Grid3.SelectedItem as Dogs;
                TB3.Text = $"{selected.NameDog} {selected.Breed} {selected.Age} {selected.Gender} {selected.Size} " +
                    $"{Convert.ToDateTime(selected.ArrivalDate).ToString("dd.MM.yyyy")} {selected.IsAdopted}";
            }
        }

    }
}
