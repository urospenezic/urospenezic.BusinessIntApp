using Model;
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
using ViewModel;

namespace BusinessIntApp
{
    /// <summary>
    /// Interaction logic for StatsPage.xaml
    /// </summary>
    public partial class StatsPage : Window
    {
        private MatrixToDataViewConverter converter = new MatrixToDataViewConverter();
        public ViewModelBase Model { get; set; }
        StatsPageViewModel model = new StatsPageViewModel(new KupacRepository(new KupciDbContext()));
        public StatsPage(ViewModelBase mod)
        {
            Model = mod;
            model.Matrix = model.ZScore;
            InitializeComponent();
            PopulateDataGrid(model.ZScore);
            PopulateComboBox();
            PopulateRank(model.GetRank(model.ZScore, rankCbx.SelectedIndex));
        }
        public void PopulateComboBox()
        {
            foreach (var kupac in Model.Kupci)
                rankCbx.Items.Add(kupac.ImeIPrezime);
            rankCbx.SelectedIndex = 0;
        }
        public void PopulateDataGrid(double[,] matrix)
        {
            this.ZScoreGrid.ItemsSource = (DataView)converter.Convert(matrix);
        }
        public void PopulateRank(string[,] matrix)
        {
            this.RankKupciGrid.ItemsSource = (DataView)converter.Convert(matrix);

        }
        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            model.Matrix = model.GetZScore(rTxt.Text.ToInt(), fTxt.Text.ToInt(), mTxt.Text.ToInt(), nTxt.Text.ToInt(), zTxt.Text.ToInt());
            PopulateDataGrid(model.Matrix);
            PopulateRank(model.GetRank(model.Matrix, rankCbx.SelectedIndex));
        }

        private void RankCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateRank(model.GetRank(model.Matrix, rankCbx.SelectedIndex));
        }
    }
}
