using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Repository.Common
{
   public interface IGenericRepository
    {
        T GetById<T>(object id) where T : class;
        void Insert<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        IQueryable<T> Get<T>() where T : class;
    }
}
