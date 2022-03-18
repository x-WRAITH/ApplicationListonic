using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace ApplicationListonic.Models
{
    public class ListObj
    {
        public string ListName { get; set; }
        public ObservableCollection<Product> ProductsList { get; set; }
    }
}
