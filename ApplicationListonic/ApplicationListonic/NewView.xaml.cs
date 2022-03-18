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

namespace ApplicationListonic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewView : ContentPage
    {
        private void RefreshData()
        {
            listMainPage.ItemsSource = null;
            listMainPage.ItemsSource = pobocznaLista.ProductsList;
        }

        private ListObj pobocznaLista;
        public NewView(ListObj pobocznaLista)
        {
            this.pobocznaLista = pobocznaLista;
            InitializeComponent();

            listMainPage.ItemsSource = pobocznaLista.ProductsList;
        }
        private void Del_NewMainList(object sender, EventArgs e)
        {
            var senderBindingContext = ((Button)sender).BindingContext;
            var dataItem = (Product)senderBindingContext;

            pobocznaLista.ProductsList.Remove(dataItem);

        }

        async void Mod_NewMainList(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Modification of the list", "Enter a name list", maxLength: 20, keyboard: Keyboard.Text);
            var senderBindingContext = ((Button)sender).BindingContext;
            var dataItem = (Product)senderBindingContext;
            int id = pobocznaLista.ProductsList.IndexOf(dataItem);
            if (result != string.Empty)
            {
                pobocznaLista.ProductsList[id].ProductName = result;
                
                RefreshData();
            }
            else
            {
                await DisplayAlert("ERROR", "The field cannot be empty", "Ok");
            }

        }

        async void Add_NewMainList(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Add new list", "Enter a name list", maxLength: 20, keyboard: Keyboard.Text);
            Console.WriteLine(result);
            if (result != string.Empty)
            {
                pobocznaLista.ProductsList.Add(new Product { ProductName = result }) ;
                //glownaLista.Add(new ListObj { listName = result });
            }
            else
            {
                await DisplayAlert("ERROR", "The field cannot be empty", "Ok");
            }
        }
    }
}