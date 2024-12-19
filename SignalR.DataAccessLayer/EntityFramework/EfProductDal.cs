﻿using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace SignalR.DataAccessLayer.EntityFramework
{

    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x=> x.Category).ToList();
            return values;
        }

	

		
		public int ProductCount()
		{
            var context = new SignalRContext();
            return context.Products.Count();
		}

		public int ProductCountByCategoryNameDrink()
		{
			using var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryId == (context.Categorys.Where(y => y.CategoryName == "İçecek").Select(z=> z.CategoryId).FirstOrDefault())).Count();
		}

		public int ProductCountByCategoryNameHamburger()
		{
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryId == (context.Categorys.Where(y => y.CategoryName == "Hamburger").Select(z=> z.CategoryId).FirstOrDefault())).Count();
			
		}

		public string ProductNameByMaxPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
		}

		public string ProductNameByMinPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
		}

		public decimal ProductPriceAvg()
		{
			using var context = new SignalRContext();
			return context.Products.Average(x=> x.Price);
		}

		public decimal ProductPriceByHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x=> x.CategoryId ==(context.Categorys.Where(y=> y.CategoryName == "Hamburger").Select(z=> z.CategoryId).FirstOrDefault())).Average(w => w.Price);
		}

	}
}