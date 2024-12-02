using MauiApp2.Models;
using MauiApp2.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.ViewModels
{
    public class PackageViewModel : INotifyPropertyChanged
    {
        private Package _trackedPackage;

        public string TrackingCode { get; set; }

        public Package TrackedPackage
        {
            get => _trackedPackage;
            set
            {
                _trackedPackage = value;
                OnPropertyChanged(nameof(TrackedPackage));
            }
        }

        public Command TrackPackageCommand { get; }

        public PackageViewModel()
        {
            TrackPackageCommand = new Command(TrackPackage);
        }

        private async void TrackPackage()
        {
            // Lógica de rastreamento (pode ser busca em API ou banco de dados)
            TrackedPackage = new Package
            {
                PackageId = TrackingCode,
                Status = "In Transit",
                ShippingDate = DateTime.Today.AddDays(-1),
                EstimatedDeliveryDate = DateTime.Today.AddDays(5),
                CurrentLocation = "Central Sorting Facility",
                EventHistory = new List<string> { "Received at facility", "Sorted", "Out for delivery" }
            };

            // Navegação para a página de resultados
            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                await navigationPage.PushAsync(new ResultPage(TrackedPackage));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }


}
