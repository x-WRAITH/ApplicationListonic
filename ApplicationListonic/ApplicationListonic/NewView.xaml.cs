using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using ApplicationListonic.Models;

namespace ApplicationListonic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewView : ContentPage
    {
        public NewView(ListObj pobocznaLista)
        {
            InitializeComponent();

            listMainPage.ItemsSource = pobocznaLista.ProductsList;
        }
        private void Del_NewMainList(object sender, EventArgs e)
        {
            var senderBindingContext = ((Button)sender).BindingContext;
            var dataItem = (Product)senderBindingContext;


        }

        async void Mod_NewMainList(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Modification of the list", "Enter a name list", maxLength: 20, keyboard: Keyboard.Text);
            var senderBindingContext = ((Button)sender).BindingContext;
            var dataItem = (Product)senderBindingContext;
            

            dataItem.ProductName =  result ;
        }

        async void Add_NewMainList(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Add new list", "Enter a name list", maxLength: 20, keyboard: Keyboard.Text);
            //.Add(new Product { ProductName = result });
            
        }
    }
}