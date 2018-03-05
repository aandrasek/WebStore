using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models.Common;

namespace WebStore.MVC.ViewModels
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public bool Discounted { get; set; }
        public bool InStock { get; set; }
        public string ImageURL { get; set; }
        public ICollection<ICategory> Categories { get; set; }
        public int CategoryID { get; set; }
        public IEnumerable<SelectListItem> Items { get; set; }
        public int[] SelectedID { get; set; } = new int[1];
    }
}