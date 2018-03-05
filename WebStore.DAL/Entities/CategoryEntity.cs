using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.DAL.Entities
{
    public class CategoryEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public ICollection<ProductEntity> Products { get; set; }
        public CategoryEntity()
        {
            Products = new List<ProductEntity>();
        }
    }
}
