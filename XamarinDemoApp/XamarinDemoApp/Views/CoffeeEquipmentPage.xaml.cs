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




        
    }
}