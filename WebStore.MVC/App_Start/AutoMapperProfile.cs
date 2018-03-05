using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStore.DAL.Entities;
using WebStore.Models.Common;
using WebStore.Models.Models;
using WebStore.MVC.ViewModels;

namespace WebStore.MVC.App_Start
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryEntity, Category>().ReverseMap();
            CreateMap<CategoryEntity, ICategory>().ReverseMap();
            CreateMap<ICategory, Category>().ReverseMap();

            CreateMap<ProductEntity, Product>().ReverseMap();
            CreateMap<ProductEntity, IProduct>().ReverseMap();
            CreateMap<IProduct, Product>().ReverseMap();

            CreateMap<ItemEntity, Item>().ReverseMap();
            CreateMap<ItemEntity, IItem>().ReverseMap();
            CreateMap<IItem, Item>().ReverseMap();

            CreateMap<ICategory, CategoryViewModel>().ReverseMap();
            CreateMap<IProduct, ProductViewModel>().ReverseMap();
            CreateMap<IItem, ItemViewModel>().ReverseMap();



        }
    }
}