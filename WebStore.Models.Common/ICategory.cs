using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Models.Common
{
    public interface ICategory
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string ImageURL { get; set; }
        ICollection<IProduct> Products { get; set; }
    }
}
