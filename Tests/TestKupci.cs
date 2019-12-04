using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public static class TestKupci
    {
        public static IEnumerable<Kupac> testKupci = new List<Kupac>()
        {
            new Kupac()
            {
                ID=5,ImeIPrezime="Test1", Recency=13,Frequency=5,Monetary=7893,Naplata=33,Znacaj=3
            },
            new Kupac()
            {
                ID=6,ImeIPrezime="Test2", Recency=33, Frequency=13,Monetary=56032,Naplata=20,Znacaj=1
            }
        };
    }
}
