using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models.Models;
using WebStore.MVC.ViewModels;
using WebStore.Service.Common;
using Microsoft.AspNet.Identity;
using PagedList;
using WebStore.Models.Common;

namespace WebStore.MVC.Controllers
{
    public class HomeController : Controller
    {
        ICategoryService CategoryService;
        IProductService ProductService;
        IShoppingCartService ShoppingCartService;

        public HomeController(ICategoryService CategoryService, IProductService ProductService, IShoppingCartService ShoppingCartService)
        {
            this.CategoryService = CategoryService;
            this.ProductService = ProductService;
            this.ShoppingCartService = ShoppingCartService;
        }
        public ActionResult Index()
        {
            //getting discounted products from all categories
            return View("Products", AutoMapper.Mapper.Map<List<ProductViewModel>>(ProductService.DiscountProductsAllCat()).ToPagedList(1, 9));
        }
        public ActionResult Categories()
        {
            //getting all categories
            return PartialView(AutoMapper.Mapper.Map<List<CategoryViewModel>>(CategoryService.AllCategories()));
        }
        public ActionResult Products(int ID, int? page, string search,int? priceFrom,int? priceTo,string discount, string order)
        {
            ViewBag.id = ID;
            var items =ProductService.DiscountProductsAllCat();
            int PageNumber = page ?? 1; 
            //if ID>0 (category is selected) get all products with that ID 
            if (ID > 0)
            {
                ViewBag.name = CategoryService.CategoryWithID(ID).Name;
                items=ProductService.AllProductsWithID(ID);
            }
            //searching products
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.search = search;
                items=ProductService.SearchProducts(search);
            }

            //getting products in which the price is in a specific price range
            if (priceFrom != null || priceTo != null)
            {
                ViewBag.priceFrom = priceFrom;
                ViewBag.priceTo = priceTo;
                items = ProductService.CheckPrice(items, priceFrom, priceTo, discount);
            }
            //getting products that are discounted
            if (!string.IsNullOrEmpty(discount))
            {
                ViewBag.discount = "checked";
                items = ProductService.CheckPrice(items, priceFrom, priceTo, discount);
            }
            //ordering products by price
            if (!string.IsNullOrEmpty(order))
            {
                if (order == "Lowest price")
                {
                    ViewBag.order = "Lowest price";
                }
                if (order == "Heights price")
                {
                    ViewBag.order = "Heights price";
                }
                items = ProductService.OrderPrice(items, order);
            }
            return View(AutoMapper.Mapper.Map<List<ProductViewModel>>(items).ToPagedList(PageNumber, 9));

        }
        [HttpPost]
        public ActionResult AddToCart(int ID, int ProductID, string UserID, decimal Price,string Name,int quantity)
        {
            //adding product to cart
            ShoppingCartService.AddToCart(ProductID, UserID, Price,Name,quantity);
            return RedirectToAction("Products", new { ID = ID });
        }
        [HttpPost]
        public ActionResult Cart(string UserID)
        {
            //all products from cart
            var items = AutoMapper.Mapper.Map<List<ItemViewModel>>(ShoppingCartService.AllProducts(UserID));
            ViewBag.sum = items.Sum(c=>c.Price);
            return View(items);
        }
        [HttpPost]
        public ActionResult DeleteCartProduct(int ID, string UserID)
        {
            //removeing products from cart
            ShoppingCartService.DeleteItem(ID);
            return Content("<form action='Cart' id='Test' method='post'><input type='hidden' name='UserID' value='" + UserID + "' /></form><script>document.getElementById('Test').submit();</script>");
        }

    }
}