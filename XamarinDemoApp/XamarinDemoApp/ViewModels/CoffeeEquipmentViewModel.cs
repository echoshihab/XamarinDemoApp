using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;
using XamarinDemoApp.Models;
using Command = Xamarin.Forms.Command;

namespace XamarinDemoApp.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; }
        public AsyncCommand RefreshCommand { get; }

        private Coffee selectedCoffee;
        private Coffee previousCoffee;

        public Coffee SelectedCoffee
        {
            get => this.selectedCoffee;
            set
            {
                if (value != null)
                {
                    Application.Current.MainPage.DisplayAlert("Selected", value.Name, "OK");
                    previousCoffee = value;
                    value = null;

                }

                selectedCoffee = value;
                OnPropertyChanged();
            }

        }
        public CoffeeEquipmentViewModel()
        {
            Title = "Coffee Equipment";
            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();
            string image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";
            Coffee.Add(new Coffee { Roaster = "Morning Hello", Name = "Jamaican Blue", Image = image });
            Coffee.Add(new Coffee { Roaster = "Morning Hello", Name = "Midnight Steel", Image = image });
            Coffee.Add(new Coffee { Roaster = "Morning Hello", Name = "Shade", Image = image });
            Coffee.Add(new Coffee { Roaster = "Tetley", Name = "Sanctity", Image = image });
            Coffee.Add(new Coffee { Roaster = "Starbucks", Name = "Bulletproof", Image = image });
            Coffee.Add(new Coffee { Roaster = "Starbucks", Name = "Monk", Image = image });
            
            CoffeeGroups.Add(new Grouping<string, Coffee>("Morning Hello", Coffee.Where(c => c.Roaster == "Morning Hello")));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Tetley", Coffee.Where(c => c.Roaster == "Tetley")));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Starbucks", Coffee.Where(c => c.Roaster == "Starbucks")));
            var _count = CoffeeGroups.Count;
        }


        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;
        }
    }
}