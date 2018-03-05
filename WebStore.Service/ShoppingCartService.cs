using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebStore.Models.Common;
using WebStore.Models.Models;
using WebStore.Repository.Common;
using WebStore.Service.Common;

namespace WebStore.Service
{
    public class ShoppingCartService : IShoppingCartService
    {
        protected IItemRepository Repository { get; private set; }

        public ShoppingCartService(IItemRepository Repository)
        {
            this.Repository = Repository;
        }

        public void AddToCart(int ProductID, string UserID,decimal Price,string Name,int quantity)
        {
            
            if (Repository.Get().Where(c => c.ProductID == ProductID && c.UserID == UserID).Count()==1)
            {
                var checkItem = Repository.Get().Where(c => c.ProductID == ProductID && c.UserID == UserID).Single();
                checkItem.Count+=quantity;
                checkItem.Price+=(Price*quantity);
                Repository.Update(checkItem);
            }
            else
            {
                Item item = new Item();
                item.ProductID = ProductID;
                item.UserID = UserID;
                item.Count = quantity;
                item.Price = Price*quantity;
                item.Name = Name;
                Repository.Insert(item);
            }

        }

        public void DeleteItem(int ID)
        {
            var item = Repository.GetById(ID);
            Repository.Delete(item);
        }

        public IList<IItem> AllProducts(string ID)
        {
            return Repository.Get().Where(c => c.UserID == ID).ToList();
        }
    }
}
