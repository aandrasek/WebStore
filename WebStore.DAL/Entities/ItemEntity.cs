﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.DAL.Entities
{
    public class ItemEntity
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int Count { get; set; }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}