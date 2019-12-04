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
using ViewModel;

namespace BusinessIntApp
{
    /// <summary>
    /// Interaction logic for UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Window
    {
        private int ID;
        protected Viewmodel Model { get; set; }
        public UpdatePage(int id, Viewmodel model)
        {
            ID = id;
            Model = model;
            InitializeComponent();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            var kupac= Model.Kupci.Where(x => x.ID == ID).Single();
            Model.UpdateKupac(kupac);
        }
    }
}
