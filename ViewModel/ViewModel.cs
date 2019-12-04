using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ViewModel
{
    public class Viewmodel:ViewModelBase,INotifyPropertyChanged
    {
        public Viewmodel(IRepository<Kupac> repository):base(repository)
        {
            
        }
        #region Metode koje komuniciraju sa ui
        public void AddKupac(string imeiprezime, int recency, int frequency, int monetary, int naplata, int znacaj)
        {
            Repository.Add(new Kupac() { ImeIPrezime = imeiprezime, Recency = recency, Frequency = frequency, Monetary = monetary, Naplata = naplata, Znacaj = znacaj });
            Repository.Commit();
            OnPropertyChanged("Kupci");
        }
        public void UpdateKupac(Kupac zamena)
        {
            Repository.Update(zamena);
            Repository.Commit();
            OnPropertyChanged("Kupci");
        }
        public void RemoveKupac(int id)
        {
            var kupacRemove = Kupci.Where(k => k.ID == id).Single();
            Repository.Remove(kupacRemove);
            Repository.Commit();
            OnPropertyChanged("Kupci");
        }
        #endregion
    }
}
