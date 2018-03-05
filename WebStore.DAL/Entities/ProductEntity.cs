using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.DAL.Entities
{
    public class ProductEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public bool Discounted { get; set; }
        public bool InStock { get; set; }
        public string ImageURL { get; set; }
        public ICollection<CategoryEntity> Categories { get; set; }
        public int CategoryID { get; set; }
    }

}
