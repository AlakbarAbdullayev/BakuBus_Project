using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models.BusServices
{
    class BakuBus : INotifyPropertyChanged
    {
        public BakuBus(string plate,string driverName, string speed, string busModel, Location location, string busNumber)
        {
            Plate = plate;
            DriverName = driverName;
            Speed = speed;
            BusModel = busModel;
            this.Buslocation = location;
            BusNumber = busNumber;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //public string Plate { get; set; }
        public string Plate { get; set; }
        public string DriverName { get; set; }
        public string Speed { get; set; }
        public string BusModel { get; set; }
        public Location Buslocation { get; set; }
        public string BusNumber { get; set; }

        private void OnPropertyChanged([CallerMemberName]string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

    }
}
