using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class ViewModelBase:INotifyPropertyChanged
    {
        public ObservableCollection<Kupac> Kupci
        {
            get { return new ObservableCollection<Kupac>(Repository.GetAll()); }
            set
            {
                if (Kupci != value)
                {
                    Kupci = value;
                    OnPropertyChanged("Kupci");
                }
            }
        }
        public IRepository<Kupac> Repository { get; set; }
        public ViewModelBase(IRepository<Kupac> repository)
        {
            Repository = repository;
        }
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
