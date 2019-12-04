using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class StatsPageViewModel : ViewModelBase
    {
        public StatsPageViewModel(IRepository<Kupac> repository) : base(repository)
        {
        }
        public double[,] Matrix { get; set; }
        public double[,] ZScore
        {
            get
            {
                return Repository.GenerateZScoreMatrix();
            }
        }
        public double[,] Pearson { get; set; }
        private List<IndexAndDistance> rankKupi = new List<IndexAndDistance>();
        public List<IndexAndDistance> RankKupci
        {
            get
            { return rankKupi; }

            set { rankKupi = value; OnPropertyChanged(nameof(RankKupci)); }
        }
        #region Metode koje komuniciraju sa ui
        public double[,] GetZScore(int recency, int frequency, int monetary, int naplata, int znacaj)
        {
            double[,] value = Repository.GenerateZScoreMatrix(recency, frequency, monetary, naplata, znacaj);
            return value;
        }
        public string[,] GetRank(double[,] matrix, int row)
        {
            RankKupci = KnnService.Classify(matrix, row);
            string[,] result = new string[RankKupci.Count, 2];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    switch (j)
                    {
                        case 0:
                            result[i, j] = Kupci[RankKupci[i].Index].ImeIPrezime;
                            break;
                        case 1:
                            result[i, j] = RankKupci[i].Distance.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
            return result;
        }
        #endregion
    }
}
