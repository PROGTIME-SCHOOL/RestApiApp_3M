using RestApiApp_Sun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace RestApiApp_Sun
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 18:03

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            SunResultModel model = await LoadSunInfo();

            lblSunrise.Content = "Info Sunrise: " + model.Results.Sunrise.ToLocalTime();
            lblSunset.Content = "Info Sunset: " + model.Results.Sunset.ToLocalTime();

            lblStatus.Content = "Status: " + model.Status;
        }

        private async Task<SunResultModel> LoadSunInfo()
        {
            return await SunProcessor.LoadSunInfo(55.809062f, 37.622382f);
        }
    }
}
