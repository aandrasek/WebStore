using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebStore.Models.Common;

namespace WebStore.Service.Common
{
    public interface ICategoryService
    {
        void AddCategory(ICategory category);
        void DeleteCategory(ICategory category);
        void UpdateCategory(ICategory category);
        void InsertImage(int ID, HttpPostedFileBase main);
        IList<ICategory> AllCategories();
        ICategory CategoryWithID(int ID);
        ICategory LastCategory();
        
    }
}
