using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.Entities;

namespace WebStore.DAL
{
    public class WebStoreContext:DbContext,IWebStoreContext
    {

        public new DbEntityEntry Entry<T>(T entity) where T : class
        {
            return base.Entry(entity);
        }
        public void SetModified<T>(T entity) where T : class
        {
            Entry(entity).State = EntityState.Modified;
        }
        IDbSet<T> IWebStoreContext.Set<T>()
        {
            return base.Set<T>();
        }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ItemEntity> Items { get; set; }
    }
}
