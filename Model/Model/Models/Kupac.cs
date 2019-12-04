using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Kupac
    {
        public int ID { get; set; }
        public string ImeIPrezime { get; set; }
        public Nullable<int> Recency { get; set; }
        public Nullable<int> Frequency { get; set; }
        public Nullable<int> Monetary { get; set; }
        public Nullable<int> Naplata { get; set; }
        public Nullable<int> Znacaj { get; set; }
    }
}
