using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Command = Xamarin.Forms.Command;

namespace XamarinDemoApp.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {
        public ObservableRangeCollection<string> Coffee;
        public CoffeeEquipmentViewModel()
        {
            IncreaseCount = new Command(OnIncrease);
            Title = "Coffee Equipment";
            CallServerCommand = new AsyncCommand(CallServer);
            Coffee = new ObservableRangeCollection<string>();
        }

        public ICommand CallServerCommand { get; }
        public ICommand IncreaseCount { get; }
        int count = 0;
        string countDisplay = "Click Me";
        public string CountDisplay
        {
            get => countDisplay;
            set => SetProperty(ref countDisplay, value);

        }

        async Task CallServer()
        {
            Coffee.AddRange(new List<string>
            {
                 "Jamaican Blue",
                 "Midnight Steel",
                 "Shade"
            });
        }

        void OnIncrease()
        {
            count++;
            CountDisplay = $"You clicked {count} time(s)";
        }
    }
}