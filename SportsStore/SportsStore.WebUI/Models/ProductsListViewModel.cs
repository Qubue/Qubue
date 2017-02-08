using SportsStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IQueryable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}