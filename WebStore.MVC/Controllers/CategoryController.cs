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
    public class CategoryController : Controller
    {
        // GET: Category
        ICategoryService CategoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            this.CategoryService = CategoryService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NewCategory()
        {
            CategoryViewModel cvm = new CategoryViewModel();
            return View(cvm);
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryViewModel cvm, HttpPostedFileBase main)
        {
            CategoryService.AddCategory(AutoMapper.Mapper.Map<ICategory>(cvm));
            var category = CategoryService.LastCategory();
            CategoryService.InsertImage(category.ID, main);
            return RedirectToAction("AllCategories");
        }
        public ActionResult DeleteCategory(int ID)
        {
            var category = CategoryService.CategoryWithID(ID);
            CategoryService.DeleteCategory(category);
            return RedirectToAction("AllCategories");
        }
        public ActionResult UpdateCategory(int ID)
        {
            return View(AutoMapper.Mapper.Map<CategoryViewModel>(CategoryService.CategoryWithID(ID)));
        }
        [HttpPost]
        public ActionResult UpdateCategory2(CategoryViewModel cvm)
        {
            CategoryService.UpdateCategory(AutoMapper.Mapper.Map<ICategory>(cvm));
            return RedirectToAction("AllCategories");
        }
        public ActionResult AllCategories()
        {
            var items = AutoMapper.Mapper.Map<List<CategoryViewModel>>(CategoryService.AllCategories());
            return View(items);
        }

    }
}