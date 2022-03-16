using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace ApplicationListonic.Models
{
    public class ListObj : ObservableCollection<Product>
    {
        public string listName { get; set; }
        public ObservableCollection<Product> ProductsList { get; set; }
    }
}
