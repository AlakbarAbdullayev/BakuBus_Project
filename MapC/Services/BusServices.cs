using Microsoft.Maps.MapControl.WPF;
using Models.BusServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Services.BusServices
{
    class BusServices
    {

        public HttpClient Client { get; set; }

        public List<BakuBus> GetBusses()
        {
            var client = new HttpClient();
            string link = "https://www.bakubus.az/az/ajax/apiNew1";

            List<BakuBus> bakubus = new List<BakuBus>();
            dynamic busses = JsonConvert.DeserializeObject(client.GetAsync(link).Result.Content.ReadAsStringAsync().Result);
            try
            {

                foreach (var item in busses.BUS)
                {
                    dynamic bus = item["@attributes"];
                    string plate = bus["PLATE"];
                    string drivername = bus["DRIVER_NAME"];
                    string speed = bus["SPEED"];
                    string busmodel = bus["BUS_MODEL"];
                    string busnumber = bus["DISPLAY_ROUTE_CODE"];
                    string lat = bus["LATITUDE"];
                    lat.Replace(',', '.');
                    string lon = bus["LONGITUDE"];
                    lon.Replace(',', '.');
                    Location location = new Location(Double.Parse(lat.ToString()), Double.Parse(lon.ToString()));


                    if (busmodel == "CREALIS")
                    {
                        busmodel = "Images\\CREALIS.JPG";
                    }
                    if (busmodel == "NEOPLAN")
                    {
                        busmodel = "Images\\NEOPLAN.JPG";
                    }
                    if (busmodel == "URBANWAY")
                    {
                        busmodel = "Images\\URBANWAY.JPG";
                    }


                    bakubus.Add(new BakuBus(plate, drivername, speed, busmodel, location, busnumber));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("API Error!!!!!","Warning",MessageBoxButton.OK,MessageBoxImage.Error);
            }

            return bakubus;
        }
    }
}