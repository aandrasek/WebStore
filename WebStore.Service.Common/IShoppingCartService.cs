using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Models.Common;

namespace WebStore.Service.Common
{
    public interface IShoppingCartService
    {
        void AddToCart(int ProductID, string UserID,decimal Price,string Name,int quantity);
        void DeleteItem(int ID);
        IList<IItem> AllProducts(string UserID);

    }
}
