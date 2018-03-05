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
    public class CategoryService:ICategoryService
    {
        protected ICategoryRepository Repository { get; private set; }
        protected IProductRepository ProductRepository { get; private set; }

        public CategoryService(ICategoryRepository Repository, IProductRepository ProductRepository)
        {
            this.Repository = Repository;
            this.ProductRepository = ProductRepository;
        }

        public IList<ICategory> AllCategories()
        {
            return Repository.Get().ToList();
        }

        public void AddCategory(ICategory Category)
        {
            Repository.Insert(Category);
        }

        public void InsertImage(int ID, HttpPostedFileBase main)
        {
            //getting category with ID
            var category = Repository.GetById(ID);
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
                category.ImageURL = name_without_extt + DateTime.Now.ToString("MMddyyHmmss") + ext;
                var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Images/"), category.ImageURL);
                main.SaveAs(path);
            }

            Repository.Update(category);
        }
        public void DeleteCategory(ICategory Category)
        {
            //getting the category image path
            string fullPath = System.Web.HttpContext.Current.Request.MapPath("~/Images/" + Category.ImageURL);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            Repository.Delete(Category);
        }

        public void UpdateCategory(ICategory category)
        {
            Repository.Update(category);
        }
        public ICategory CategoryWithID(int ID)
        {
            return Repository.GetById(ID); 
        }

        public ICategory LastCategory()
        {
            return Repository.Get().OrderByDescending(c => c.ID).FirstOrDefault();
        }
    }
}
