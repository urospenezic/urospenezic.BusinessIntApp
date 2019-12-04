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
    /// Interaction logic for InsertPage.xaml
    /// </summary>
    public partial class InsertPage : Window
    {
        protected Viewmodel Model { get; set; }
        public InsertPage(Viewmodel model)
        {
            Model = model;
            InitializeComponent();
        }
        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            Model.AddKupac(imeiprezime.Text, recency.Text.ToInt(), frequency.Text.ToInt(), monetary.Text.ToInt(), naplata.Text.ToInt(), znacaj.Text.ToInt());
            Hide();
        }
    }
}
