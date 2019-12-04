using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class IndexAndDistance:IComparable<IndexAndDistance>
    {
        public double Distance { get; set; }
        public int Index { get; set; }

        public int CompareTo(IndexAndDistance other)
        {
            if (Distance < other.Distance) return -1;
            else if (Distance > other.Distance) return +1;
            else return 0;
        }
    }
    public static class KnnService
    {
        public static double Distance(double[] kupacOne, double[] kupacTwo)
        {
            double sum = 0.0;
            for (int i = 0; i < kupacOne.Length; i++)
                sum += Math.Pow((kupacOne[i] - kupacTwo[i]), 2);
            return Math.Sqrt(sum);
        }
        public static double[] GetKupac(double[,] matrix, int id)
        {
            double[] personSelected = new double[matrix.GetLength(1)];
            for (int i = 0; i < personSelected.Length; i++)
            {
                personSelected[i] = matrix[id, i];
            }
            return personSelected;
        }
        public static List<IndexAndDistance> Classify(double[,] matrix, int row)
        {
            int n = matrix.GetLength(0);
            double[] personSelected = GetKupac(matrix, row);
            double[] personToCompareTo = new double[matrix.GetLength(1)];
            var info = new List<IndexAndDistance>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var current = new IndexAndDistance();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    personToCompareTo[j] = matrix[i, j];
                }
                current.Index = i;
                current.Distance = Math.Round(Distance(personSelected, personToCompareTo), 2);
                info.Add(current);
            }
            info.Sort();
            return info;
        }
    }
}
