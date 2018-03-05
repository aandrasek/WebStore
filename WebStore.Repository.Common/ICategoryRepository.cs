using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Models.Common;

namespace WebStore.Repository.Common
{
    public interface ICategoryRepository
    {
        ICategory GetById(object id);
        void Insert(ICategory entity);
        void Update(ICategory entity);
        void Delete(ICategory entity);
        IQueryable<ICategory> Get();
    }
}
