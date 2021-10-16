using System.Threading.Tasks;
using MvvmHelpers;
using MvvmHelpers.Commands;
using XamarinDemoApp.Models;
using XamarinDemoApp.Services;

namespace XamarinDemoApp.ViewModels
{
    public class CoffeeEquipmentDbViewModel : ViewModelBase
    {

        public ObservableRangeCollection<DbCoffee> Coffee { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<DbCoffee> RemoveCommand { get; }
        public CoffeeEquipmentDbViewModel()
        {
            Title = "Coffee From DB";
            Coffee = new ObservableRangeCollection<DbCoffee>();

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<DbCoffee>(Remove);
        }

        async Task Add()
        {
            var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Name of coffee");
            var roaster = await App.Current.MainPage.DisplayPromptAsync("Roaster", "Roaster of coffee");

            await CoffeeService.AddCoffee(name, roaster);
            await Refresh();
        }

        async Task Remove(DbCoffee coffee)
        {
            await CoffeeService.RemoveCoffee(coffee.Id);
            await Refresh();
        }

        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);

            Coffee.Clear();

            var coffees = await CoffeeService.GetCoffee();

            Coffee.AddRange(coffees);
            IsBusy = false;
        }


    }
}