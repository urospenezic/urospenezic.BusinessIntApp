using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace BusinessIntApp
{
    public class ValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isenable = true;
            if (string.IsNullOrEmpty(value.ToString()))
            {
                isenable = false;
            }
            return isenable;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public static class TextBoxConverter
    {
        public static int ToInt(this string str)
        {
            int.TryParse(str, out int p);
            return p;
        }
    }
    public class MatrixToDataViewConverter
    {

        public object Convert(double[,] matrix)
        {
            DataTable dataTable = new DataTable();
            for (int j = 0; j < matrix.GetLength(1); j++)
                dataTable.Columns.Add(new DataColumn("Column " + j.ToString()));

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var newRow = dataTable.NewRow();
                for (int j = 0; j < matrix.GetLength(1); j++)
                    newRow["Column " + j.ToString()] = matrix[i, j];
                dataTable.Rows.Add(newRow);
            }
            return dataTable.DefaultView;
        }
        public object Convert(string[,] matrix)
        {
            DataTable dataTable = new DataTable();
            for (int j = 0; j < matrix.GetLength(1); j++)
                dataTable.Columns.Add(new DataColumn("Column " + j.ToString()));

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                var newRow = dataTable.NewRow();
                for (int j = 0; j < matrix.GetLength(1); j++)
                    newRow["Column " + j.ToString()] = matrix[i, j];
                dataTable.Rows.Add(newRow);
            }
            return dataTable.DefaultView;
        }
    }
}
