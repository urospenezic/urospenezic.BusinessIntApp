using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class ZScore
    {
        /// <summary>
        /// Pravi Z-score tabelu za dat Repository Entity-ja
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static double[,] GenerateZScoreMatrix(this IRepository<Kupac> repository, int r=1, int f=1, int m=1, int n=1, int z=1)
        {
            var set = repository.GetAll();
            double[,] result = new double[set.Count(), 5];
            try
            {
                result.PopulateMatrix(set, r,f,m,n,z);
            }
            catch (IndexOutOfRangeException)
            {

                throw new IndexOutOfRangeException($"Index out of range");
            }
            return result;
        }
        /// <summary>
        /// Popunjava matricu z-score vrednosti podataka baze
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="repository"></param>
        /// <param name="whatToPopulate"></param>
        public static void PopulateMatrix(this double[,] matrix, IEnumerable<Kupac> repository, int r, int f, int m, int n, int z)
        {
            double[][] arrays = repository.GetArrays();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    switch (j)
                    {
                        case (0):
                            var recent = (-Math.Round(arrays[j][i].CalculateZScore(arrays[j]),2))*r;
                            matrix[i, j] = recent;
                            break;
                        case (1):
                            var frequent = Math.Round(arrays[j][i].CalculateZScore(arrays[j]), 2)*f;
                            matrix[i, j] = frequent;
                            break;
                        case (2):
                            var monet = Math.Round(arrays[j][i].CalculateZScore(arrays[j]), 2)*m;
                            matrix[i, j] = monet;
                            break;
                        case (3):
                            var nap = Math.Round(arrays[j][i].CalculateZScore(arrays[j]), 2)*n;
                            matrix[i, j] = nap;
                            break;
                        case (4):
                            var znac = Math.Round(arrays[4][i].CalculateZScore(arrays[j]), 2)*z;
                            matrix[i, j] = znac;
                            break;
                        default:
                            throw new IndexOutOfRangeException("WHOOPS");
                    }
                }
            }
        }
        /// <summary>
        /// Calculates StDev against the given IEnumerable
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static double CalculateStdDev(this IEnumerable<double> values)
        {
            double ret = 0;
            if (values.Count() > 0)
            {
                double avg = values.Average();
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                ret = Math.Sqrt((sum) / (values.Count() - 1));
            }
            return ret;
        }
        /// <summary>
        /// Calculates Z-score
        /// </summary>
        /// <param name="value"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static double CalculateZScore(this double value, IEnumerable<double> list)
        {
            return (value - list.Average()) / list.CalculateStdDev();
        }
        /// <summary>
        /// hard-kodira svojstva IEnumerable u svoje nizove
        /// </summary>
        /// <param name="kupci"></param>
        /// <returns></returns>
        public static double[][] GetArrays(this IEnumerable<Kupac> kupci)
        {
            var Recency = kupci.Select(x => x.Recency).ToArray();
            var recency = Array.ConvertAll(Recency, broj => (double)broj);
            var Frequency = kupci.Select(x => x.Frequency).ToArray();
            var frequency = Array.ConvertAll(Frequency, broj => (double)broj);
            var Monetary = kupci.Select(x => x.Monetary).ToArray();
            var monetary = Array.ConvertAll(Monetary, broj => (double)broj);
            var Naplata = kupci.Select(x => x.Naplata).ToArray();
            var naplata = Array.ConvertAll(Naplata, broj => (double)broj);
            var Znacaj = kupci.Select(x => x.Znacaj).ToArray();
            var znacaj = Array.ConvertAll(Znacaj, broj => (double)broj);
            var result = new double[][]
            {
                recency,
                frequency,
                monetary,
                naplata,
                znacaj
            };
            return result;
        }
    }
}
