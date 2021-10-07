using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinDemoApp.Models;
using XamarinDemoApp.ViewModels;

namespace XamarinDemoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeeEquipmentPage : ContentPage
    {
        public CoffeeEquipmentPage()
        {
            InitializeComponent();

            //BindingContext = new CoffeeEquipmentViewModel(); we can send the binding context here, but for code intellisense
            //we can also set the binding context at xaml

        }


        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var coffee = ((ListView) sender).SelectedItem as Coffee;
            if (coffee == null)
                return;

            await DisplayAlert("Coffee Selected", coffee.Name, "Ok");
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
           ((ListView)sender).SelectedItem = null;
        }

        private async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            var coffee = ((MenuItem) sender).BindingContext as Coffee;
            
            if (coffee == null)
                return;

            await DisplayAlert("Coffee Favorited", coffee.Name, "Ok");

        }
    }
}