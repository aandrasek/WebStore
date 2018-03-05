using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Models.Common;

namespace WebStore.Repository.Common
{
    public interface IItemRepository
    {
        IItem GetById(object id);
        void Insert(IItem entity);
        void Update(IItem entity);
        void Delete(IItem entity);
        IQueryable<IItem> Get();
    }
}
