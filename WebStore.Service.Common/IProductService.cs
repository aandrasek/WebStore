using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebStore.Models.Common;

namespace WebStore.Service.Common
{
    public interface IProductService
    {
        void AddProduct(IProduct Product);
        void DeleteProduct(IProduct product);
        void UpdateProduct(IProduct product);
        void InsertImage(int ID, HttpPostedFileBase main);
        IList<IProduct> AllAvailableProducts();
        IList<IProduct> AllProducts();
        IList<IProduct> AllProductsWithID(int ID);
        IList<IProduct> CheckPrice(IList<IProduct> list, int? priceFrom, int? priceTo, string discount);
        IList<IProduct> OrderPrice(IList<IProduct> list, string order);
        IList<IProduct> SearchProducts(string search);
        IList<IProduct> DiscountProductsAllCat();
        IProduct ProductWithID(int ID);
        IProduct LastProduct();
    }
}
