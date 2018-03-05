using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebStore.Models.Common;
using WebStore.Repository.Common;
using WebStore.Service.Common;

namespace WebStore.Service
{
    public class ProductService : IProductService
    {
        protected IProductRepository Repository { get; private set; }
        public ProductService(IProductRepository Repository)
        {
            this.Repository = Repository;
        }

        public void AddProduct(IProduct Product)
        {
            Repository.Insert(Product);
        }

        public IList<IProduct> AllAvailableProducts()
        {
            return Repository.Get().Where(c => c.InStock == true).ToList();
        }

        public IList<IProduct> AllProducts()
        {
            return Repository.Get().ToList();
        }
        public IProduct ProductWithID(int ID)
        {
            return Repository.GetById(ID);
        }

        public IProduct LastProduct()
        {
            return Repository.Get().OrderByDescending(c => c.ID).FirstOrDefault();
        }
        public void InsertImage(int ID, HttpPostedFileBase main)
        {
            //getting product by ID
            var product = Repository.GetById(ID);
            //if there is no image selected,set default image
            if (main == null)
            {
                product.ImageURL = "default.png";
            }
            //if image is selected, upload the image to "Images" folder 
            else
            {
                var name_without_extt = Path.GetFileNameWithoutExtension(main.FileName);
                var ext = Path.GetExtension(main.FileName);
                product.ImageURL = name_without_extt + DateTime.Now.ToString("MMddyyHmmss") + ext;
                var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Images/"), product.ImageURL);
                main.SaveAs(path);
            }
            Repository.Update(product);
        }
        public void DeleteProduct(IProduct Product)
        {
            //getting the product image path
            string fullPath = System.Web.HttpContext.Current.Request.MapPath("~/Images/" + Product.ImageURL);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            Repository.Delete(Product);
        }
        public void UpdateProduct(IProduct product)
        {
            Repository.Update(product);
        }

        public IList<IProduct> AllProductsWithID(int ID)
        {
            return Repository.Get().Where(c => c.CategoryID == ID && c.InStock == true).ToList();
        }

        public IList<IProduct> SearchProducts(string search)
        {
            return Repository.Get().Where(c => c.Name.ToUpper().StartsWith(search.ToUpper())).ToList();
        }

        public IList<IProduct> DiscountProductsAllCat()
        {
           return Repository.Get().Where(c => c.Discounted == true).OrderByDescending(c => c.ID).ToList();
        }

        public IList<IProduct> CheckPrice(IList<IProduct> list, int? priceFrom, int? priceTo, string discount)
        {
            //dividing list
            var notDiscountedList = list.Where(c => c.Discounted == false).ToList();
            var discountedList = list.Where(c => c.Discounted == true).ToList();
            //products where price is more or equal to priceFrom
            if (priceFrom != null)
            {
                notDiscountedList = notDiscountedList.Where(c => c.Price >= priceFrom).ToList();
                discountedList = discountedList.Where(c => c.DiscountPrice >= priceFrom).ToList();
            }
            //products where price is less or equal to priceFrom
            if (priceTo != null)
            {
                notDiscountedList = notDiscountedList.Where(c => c.Price <= priceTo).ToList();
                discountedList = discountedList.Where(c => c.DiscountPrice <= priceTo).ToList();
            }
            //merging lists
            var mergedList=discountedList;
            mergedList.AddRange(notDiscountedList);
            if (!string.IsNullOrEmpty(discount))
            {
                //if price range is set get discounted products from mergedList
                if (priceFrom != null || priceTo != null)
                {
                    mergedList = mergedList.Where(c => c.Discounted == true).ToList();
                }
                //if price is not set get discounted products form list
                else
                {
                    return list.Where(c => c.Discounted == true).ToList();
                }
            }
            return mergedList;
        }

        public IList<IProduct> OrderPrice(IList<IProduct> list, string order)
        {
            if (order == "Lowest price")
            {
                list = list.OrderBy(c => c.Price).ToList();
            }
            if (order == "Heights price")
            {
                list = list.OrderByDescending(c => c.Price).ToList();
            }
            return list;
        }
    }
}
