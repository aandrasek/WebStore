using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.MVC.ViewModels
{
    public class ItemViewModel
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int Count { get; set; }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}