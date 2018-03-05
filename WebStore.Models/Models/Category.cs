using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Models.Common;

namespace WebStore.Models.Models
{
    public class Category:ICategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public ICollection<IProduct> Products { get; set; }
        public Category()
        {
            Products = new List<IProduct>();
        }
    }
}
