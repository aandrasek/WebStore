using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.MVC.ViewModels
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}