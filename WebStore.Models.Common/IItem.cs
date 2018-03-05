using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Models.Common
{
    public interface IItem
    {
        int ID { get; set; }
        string UserID { get; set; }
        int Count { get; set; }
        int ProductID { get; set; }
        decimal Price { get; set; }
        string Name { get; set; }

    }
}
