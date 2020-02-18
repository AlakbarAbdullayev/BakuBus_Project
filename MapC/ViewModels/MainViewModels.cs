using MapC.Command;
using Microsoft.Maps.MapControl.WPF;
using Models.BusServices;
using Services.BusServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MapC.ViewModels
{
    class MainViewModels : INotifyPropertyChanged
    {
        private ObservableCollection<BakuBus> _bakubuslists;
        public ObservableCollection<BakuBus> bakubuslists
        {
            get { return _bakubuslists; }
            set
            {
                _bakubuslists = value;
                OnPropertyChanged();
            }
        }

        private int _selectedindex;
        public int selectedindex
        {
            get { return _selectedindex; }
            set
            {
                if (_selectedindex == value) return;
                _selectedindex = value;
            }
        }



        private List<string> _busnumberlists;
        public List<string> busnumberlists
        {
            get { return _busnumberlists; }
            set
            {
                _busnumberlists = value;
                OnPropertyChanged();
            }
        }


       

        DispatcherTimer dispatcher = new DispatcherTimer();
        public BusServices BusServices;

        public MainViewModels()
        {
            BusServices = new BusServices();
            dispatcher.Tick += Dispatcher_Tick;
            dispatcher.Interval = new TimeSpan(0, 0, 5);
            dispatcher.Start();
        }

        private void Dispatcher_Tick(object sender, EventArgs e)
        {
            bakubuslists = new ObservableCollection<BakuBus>(BusServices.GetBusses());
            busnumberlists = new List<string>();

            for (int i = 0; i < bakubuslists.Count; i++)
            {
                busnumberlists.Add(bakubuslists[i].BusNumber);
            }
            busnumberlists = busnumberlists.Distinct().ToList();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
