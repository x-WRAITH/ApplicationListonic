using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using ApplicationListonic.Models;
using Newtonsoft.Json;

namespace ApplicationListonic {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewView : ContentPage {
        private void RefreshData() {
            listMainPage.ItemsSource = null;
            listMainPage.ItemsSource = pobocznaLista.ProductsList;
        }

        private ListObj pobocznaLista;
        public NewView(ListObj pobocznaLista) {
            this.pobocznaLista = pobocznaLista;
            InitializeComponent();
            listMainPage.ItemsSource = pobocznaLista.ProductsList;
        }
        private void Del_NewMainList(object sender, EventArgs e) {
            var senderBindingContext = ((Button)sender).BindingContext;
            var dataItem = (Product)senderBindingContext;
            pobocznaLista.ProductsList.Remove(dataItem);
        }

        async void Mod_NewMainList(object sender, EventArgs e) {
            string resultName = await DisplayPromptAsync("Modification of the product", "Enter a name product", maxLength: 20, keyboard: Keyboard.Text);
            var senderBindingContext = ((Button)sender).BindingContext;
            var dataItem = (Product)senderBindingContext;
            int id = pobocznaLista.ProductsList.IndexOf(dataItem);
            if (resultName != string.Empty) {
                string resultAmount = await DisplayPromptAsync($"Modification of the {resultName}", $"Enter a amount {resultName}", maxLength: 20, keyboard: Keyboard.Numeric);
                if (resultAmount != string.Empty) {
                    pobocznaLista.ProductsList[id].Name = resultName;
                    pobocznaLista.ProductsList[id].Amount = Convert.ToInt32(resultAmount);
                } else { await DisplayAlert("ERROR", "The field cannot be empty", "Ok"); }
            } else { await DisplayAlert("ERROR", "The field cannot be empty", "Ok");}
            RefreshData();
        }

        async void Add_NewMainList(object sender, EventArgs e) {
            string resultName = await DisplayPromptAsync("Add new product", "Enter a name product", maxLength: 20, keyboard: Keyboard.Text);
            if (resultName != string.Empty) {
                var resultAmount = await DisplayPromptAsync($"Add of the amount {resultName}", $"Enter a amount {resultName}", maxLength: 20, keyboard: Keyboard.Numeric);
                if (resultAmount != string.Empty) {
                    pobocznaLista.ProductsList.Add(new Product { Name = resultName, Amount = Convert.ToInt32(resultAmount) });
                } else { await DisplayAlert("ERROR", "The field cannot be empty", "Ok"); }
            } else { await DisplayAlert("ERROR", "The field cannot be empty", "Ok"); }
        }
    }
}