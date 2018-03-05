using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL;
using WebStore.Repository.Common;

namespace WebStore.Repository
{
    public class GenericRepository:IGenericRepository
    {
        private readonly IWebStoreContext _context;
        public GenericRepository(IWebStoreContext context)
        {
            this._context = context;
        }

        public T GetById<T>(object id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert<T>(T entity) where T : class
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this._context.Set<T>().Add(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public void Update<T>(T entity) where T : class
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var item = _context.Set<T>().Find(GetProperty(entity, "ID"));
                var newItem = AutoMapper.Mapper.Map(entity, item);
                _context.Entry(item).CurrentValues.SetValues(newItem);
                _context.SetModified(item);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public void Delete<T>(T entity) where T : class
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var obj = _context.Set<T>().Find(GetProperty(entity, "ID"));
                this._context.Set<T>().Remove(obj);
                this._context.SaveChanges();



            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public virtual IQueryable<T> Get<T>() where T : class
        {
            return this._context.Set<T>().AsQueryable();
        }

        object GetProperty<E>(E entity, string propertyName) where E : class
        {
            var property = entity.GetType().GetProperty(propertyName);
            if (property == null)
            {
                throw new Exception("Entity does not contain property with name '" + propertyName + "'");
            }
            return property.GetValue(entity);
        }
    }
}
