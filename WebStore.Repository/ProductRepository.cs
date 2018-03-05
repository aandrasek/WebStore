using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.Entities;
using WebStore.Models.Common;
using WebStore.Repository.Common;

namespace WebStore.Repository
{
    public class ProductRepository:IProductRepository
    {
        protected IGenericRepository Repository { get; set; }

        public ProductRepository(IGenericRepository Repository)
        {
            this.Repository = Repository;
        }

        public void Delete(IProduct entity)
        {

            Repository.Delete(AutoMapper.Mapper.Map<ProductEntity>(entity));
        }

        public IQueryable<IProduct> Get()
        {
            return AutoMapper.Mapper.Map<List<IProduct>>(Repository.Get<ProductEntity>()).AsQueryable();
        }

        public IProduct GetById(object id)
        {
            return AutoMapper.Mapper.Map<IProduct>(Repository.GetById<ProductEntity>(id));
        }

        public void Insert(IProduct entity)
        {
            Repository.Insert(AutoMapper.Mapper.Map<ProductEntity>(entity));
        }

        public void Update(IProduct entity)
        {
            Repository.Update(AutoMapper.Mapper.Map<ProductEntity>(entity));
        }
    }
}
