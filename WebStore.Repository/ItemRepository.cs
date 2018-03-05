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
    public class ItemRepository:IItemRepository
    {
        protected IGenericRepository Repository { get; set; }

        public ItemRepository(IGenericRepository Repository)
        {
            this.Repository = Repository;
        }

        public void Delete(IItem entity)
        {

            Repository.Delete(AutoMapper.Mapper.Map<ItemEntity>(entity));
        }

        public IQueryable<IItem> Get()
        {
            return AutoMapper.Mapper.Map<List<IItem>>(Repository.Get<ItemEntity>()).AsQueryable();
        }

        public IItem GetById(object id)
        {
            return AutoMapper.Mapper.Map<IItem>(Repository.GetById<ItemEntity>(id));
        }

        public void Insert(IItem entity)
        {
            Repository.Insert(AutoMapper.Mapper.Map<ItemEntity>(entity));
        }

        public void Update(IItem entity)
        {
            Repository.Update(AutoMapper.Mapper.Map<ItemEntity>(entity));
        }
    }
}
