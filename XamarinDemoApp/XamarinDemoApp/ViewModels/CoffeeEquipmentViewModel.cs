using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;
using XamarinDemoApp.Models;
using Command = Xamarin.Forms.Command;

namespace XamarinDemoApp.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; }
        public AsyncCommand RefreshCommand { get; }
        public CoffeeEquipmentViewModel()
        {
            Title = "Coffee Equipment";
            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();
            string image = "https://cdn1.vectorstock.com/i/thumbs/68/10/coffee-cup-icon-vector-12056810.jpg";
            Coffee.Add(new Coffee { Roaster = "D1", Name = "Jamaican Blue", Image = image });
            Coffee.Add(new Coffee { Roaster = "D2", Name = "Midnight Steel", Image = image });
            Coffee.Add(new Coffee { Roaster = "D3", Name = "Shade", Image = image });
            

        }


        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;
        }
    }
}