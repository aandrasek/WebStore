using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Models.Common
{
    public interface IProduct
    {
        int ID { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        decimal DiscountPrice { get; set; }
        bool Discounted { get; set; }
        bool InStock { get; set; }
        string ImageURL { get; set; }
        ICollection<ICategory> Categories { get; set; }
        int CategoryID { get; set; }

    }
}
