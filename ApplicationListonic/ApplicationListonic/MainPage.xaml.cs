using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ApplicationListonic.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace ApplicationListonic {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage { 
        private void RefreshData() {
            listMainPage.ItemsSource = null;
            listMainPage.ItemsSource = glownaLista;
        }

        public static ObservableCollection<ListObj> glownaLista { get; set; } = new ObservableCollection<ListObj>();
        public MainPage() {
            InitializeComponent();
            listMainPage.ItemsSource = glownaLista;
            //  var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "listonic.json");
            //   File.Delete(path);
            LoadData();

        }

        public static void SaveData() {
            var zmienna = JsonConvert.SerializeObject(glownaLista.ToList());
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "listonic.json");
            Debug.WriteLine(zmienna);
            File.WriteAllText(path, zmienna);
        }

        private void LoadData() {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "listonic.json");
            if (!File.Exists(path)){ return; }
            glownaLista = new ObservableCollection<ListObj>(JsonConvert.DeserializeObject<List<ListObj>>(File.ReadAllText(path)));
            RefreshData();
        }

        private void listMainPage_ItemTapped(object sender, ItemTappedEventArgs e) {
           var lista = e.Item as ListObj;
           Navigation.PushAsync(new NewView(lista));
        }

        private void Del_NewMainList(object sender, EventArgs e) {
            var senderBindingContext = ((Button)sender).BindingContext;
            var dataItem = (ListObj)senderBindingContext;
            glownaLista.Remove(dataItem);
        }

        async void Mod_NewMainList(object sender, EventArgs e) {
            string result = await DisplayPromptAsync("Modification of the list", "Enter a name list", maxLength: 20, keyboard: Keyboard.Text);
            var senderBindingContext = ((Button)sender).BindingContext;
            var dataItem = (ListObj)senderBindingContext;
            int id = glownaLista.IndexOf(dataItem);
            if (result != string.Empty) {
                glownaLista[id].Name = result;
                RefreshData();
            } else { await DisplayAlert("ERROR", "The field cannot be empty", "Ok"); }
            
        }

        async void Add_NewMainList(object sender, EventArgs e) {
            string result = await DisplayPromptAsync("Add new list", "Enter a name list", maxLength: 20, keyboard: Keyboard.Text);
            Console.WriteLine(result);
            if(result != string.Empty) {
                glownaLista.Add(new ListObj { Name = result, ProductsList = new ObservableCollection<Product>() });
            } else { await DisplayAlert("ERROR", "The field cannot be empty", "Ok"); }
        }

    }
}