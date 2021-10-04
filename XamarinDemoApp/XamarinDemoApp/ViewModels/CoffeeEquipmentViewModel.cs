using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinDemoApp.ViewModels
{
    public class CoffeeEquipmentViewModel : BindableObject
    {
        public CoffeeEquipmentViewModel()
        {
            IncreaseCount = new Command(OnIncrease);
        }

        public ICommand IncreaseCount { get; }
        int count = 0;
        string countDisplay = "Click Me";
        public string CountDisplay
        {
            get => countDisplay;
            set
            {
                if (countDisplay == value)
                    return;
                countDisplay = value;
                
                OnPropertyChanged(); 
                // same as OnPropertyChanged(nameof(countDisplay)); 

            }

        }

        void OnIncrease()
        {
            count++;
            CountDisplay = $"You clicked {count} time(s)";
        }
    }
}