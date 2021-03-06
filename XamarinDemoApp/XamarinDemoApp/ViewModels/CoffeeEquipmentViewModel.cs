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
        public AsyncCommand<Coffee> FavoriteCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }
        public Command LoadMoreCommand { get; }
        public Command DelayLoadMoreCommand { get; }
        public Command ClearCommand { get; }

        private Coffee selectedCoffee;
        private Coffee previousCoffee;

        public Coffee SelectedCoffee
        {
            get => this.selectedCoffee;
            set => SetProperty(ref selectedCoffee, value);

        }

        async Task Selected(object args)
        {
            var coffee = args as Coffee;
            if (coffee == null)
                return;

            SelectedCoffee = null;

            await Application.Current.MainPage.DisplayAlert("Selected", coffee.Name, "OK");
        }
        public CoffeeEquipmentViewModel()
        {
            Title = "Coffee Equipment";
            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();
            
            LoadMore();


            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Coffee>(Favorite);
            SelectedCommand = new AsyncCommand<object>(Selected);
            LoadMoreCommand = new Command(LoadMore);
            ClearCommand = new Command(Clear);
            DelayLoadMoreCommand = new Command(DelayLoadMore);
        }


        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            Coffee.Clear();
            LoadMore();
            IsBusy = false;
        }

        async Task Favorite(Coffee coffee)
        {
            if (coffee == null)
                return;
            await Application.Current.MainPage.DisplayAlert("Marked as Favorite", coffee.Name, "OK");
            
        }

        void LoadMore()
        {
            if (Coffee.Count >= 20)
                return;

            
            string image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";
            Coffee.Add(new Coffee { Roaster = "Morning Hello", Name = "Jamaican Blue", Image = image });
            Coffee.Add(new Coffee { Roaster = "Morning Hello", Name = "Midnight Steel", Image = image });
            Coffee.Add(new Coffee { Roaster = "Morning Hello", Name = "Shade", Image = image });
            Coffee.Add(new Coffee { Roaster = "Tetley", Name = "Sanctity", Image = image });
            Coffee.Add(new Coffee { Roaster = "Starbucks", Name = "Bulletproof", Image = image });
            Coffee.Add(new Coffee { Roaster = "Starbucks", Name = "Monk", Image = image });
            
            CoffeeGroups.Clear();

            CoffeeGroups.Add(new Grouping<string, Coffee>("Morning Hello", Coffee.Where(c => c.Roaster == "Morning Hello")));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Tetley", Coffee.Where(c => c.Roaster == "Tetley")));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Starbucks", Coffee.Where(c => c.Roaster == "Starbucks")));
            
        }

        void DelayLoadMore()
        {
            if (Coffee.Count <= 10)
                return;
            LoadMore();
        }

        void Clear()
        {
            Coffee.Clear();
            CoffeeGroups.Clear();
        }
    }
}