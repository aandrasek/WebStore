using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Models.Common;

namespace WebStore.Repository.Common
{
    public interface IProductRepository
    {
        IProduct GetById(object id);
        void Insert(IProduct entity);
        void Update(IProduct entity);
        void Delete(IProduct entity);
        IQueryable<IProduct> Get();
    }
}
