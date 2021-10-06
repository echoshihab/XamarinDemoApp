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


        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var coffee = ((ListView) sender).SelectedItem as Coffee;
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
           ((ListView)sender).SelectedItem = null;
        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}