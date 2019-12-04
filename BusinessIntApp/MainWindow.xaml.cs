using Model;
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
using ViewModel;

namespace BusinessIntApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Viewmodel model = new Viewmodel(new KupacRepository(new KupciDbContext()));
        public MainWindow()
        {
            InitializeComponent();
            DataContext = model;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertPage insertPage = new InsertPage(model);
            insertPage.ShowDialog();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            var kupac = myDataGrid.SelectedItem as Kupac;
            model.UpdateKupac(kupac);
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            var id = (myDataGrid.SelectedItem as Kupac).ID;
            model.RemoveKupac(id);
        }

        private void StatsBtn_Click(object sender, RoutedEventArgs e)
        {
            StatsPage page = new StatsPage(model);
            page.ShowDialog();
        }
    }
}
