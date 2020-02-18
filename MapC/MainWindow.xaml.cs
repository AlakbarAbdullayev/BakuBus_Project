using MapC.ViewModels;
using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MapC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ApplicationIdCredentialsProvider Provider1 { get; set; } = new ApplicationIdCredentialsProvider("BiYMhlz1a7CjQwbKOFlB~x7G5ee6V7jIsK7498oe5Yg~AnE4a5v6PEw4ocRb16MqYX6w-K_USBqWj-aikSVsyV_eUFQau4wwhOtdKtYTKhDQ ");
        public ApplicationIdCredentialsProvider Provider2 { get; set; } = new ApplicationIdCredentialsProvider("P5hwg7O6NtJpF2nFPWe1~KL8WbAFGG-OOGtAMhchiXA~AmhOfQzEYEoRuRJH1mf6nnevGvglif2eI0td-CHJoTOZe26W3OlqKkH9zjRBvAHl ");

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModels();
            m.Mode = new RoadMode();
            m.ZoomLevel = 10;
            m.CredentialsProvider = Provider2;
        }

    }
}