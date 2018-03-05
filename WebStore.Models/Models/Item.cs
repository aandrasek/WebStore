using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Models.Common;

namespace WebStore.Models.Models
{
    public class Item:IItem
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int Count { get; set; }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}
