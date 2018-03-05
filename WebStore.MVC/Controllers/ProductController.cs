using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models.Common;
using WebStore.Models.Models;
using WebStore.MVC.ViewModels;
using WebStore.Service.Common;

namespace WebStore.MVC.Controllers
{
    public class ProductController : Controller
    {
        IProductService ProductService;
        ICategoryService CategoryService;
        public ProductController(IProductService ProductService, ICategoryService CategoryService)
        {
            this.ProductService = ProductService;
            this.CategoryService = CategoryService;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NewProduct()
        {
            ProductViewModel pvm = new ProductViewModel();
            pvm.Items = CategoryService.AllCategories().Select(c => new SelectListItem { Value = c.ID.ToString(), Text = c.Name });
            return View(pvm);
        }
        [HttpPost]
        public ActionResult AddProduct(ProductViewModel pvm, HttpPostedFileBase main)
        {
            pvm.CategoryID = pvm.SelectedID.ElementAt(0);
            ProductService.AddProduct(AutoMapper.Mapper.Map<IProduct>(pvm));
            var product = ProductService.LastProduct();
            ProductService.InsertImage(product.ID, main);
            return RedirectToAction("AllProducts");
        }
        public ActionResult AllProducts()
        {
            var items = AutoMapper.Mapper.Map<List<ProductViewModel>>(ProductService.AllProducts());
            return View(items);
        }
        public ActionResult DeleteProduct(int ID)
        {
            var product = ProductService.ProductWithID(ID);
            ProductService.DeleteProduct(product);
            return RedirectToAction("AllProducts");
        }
        public ActionResult UpdateProduct(int ID)
        {
            return View(AutoMapper.Mapper.Map<ProductViewModel>(ProductService.ProductWithID(ID)));
        }
        [HttpPost]
        public ActionResult UpdateProduct2(ProductViewModel pvm)
        {
            ProductService.UpdateProduct(AutoMapper.Mapper.Map<IProduct>(pvm));
            return RedirectToAction("AllProducts");
        }
    }
}