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
    }
}
