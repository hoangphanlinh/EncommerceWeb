﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrganicShop.Data.Interfaces;
using OrganicShop.Models;
using System.Xml.Linq;
using X.PagedList;

namespace OrganicShop.Data.Services
{
    public class ProductServices : IProductServices
    {
        private readonly AppDBContext _context;
        public ProductServices(AppDBContext context) { 
            _context = context;
        }

        public void CreateProduct(Products product)
        {
           _context.Products.Add(product);
            _context.SaveChanges();
        }

        public IOrderedQueryable<Products> GetAllProduct()
        {
            var result = _context.Products.Include(x=>x.Categories).AsNoTracking().OrderByDescending(x => x.ProductID);
            return result;
        }

        public List<SelectListItem> GetBestSeller()
        {
            List<SelectListItem> BestSellers = new()
            {
                new SelectListItem { Value = "True", Text = "Yes" },
                new SelectListItem { Value = "False", Text = "No" }
            };
            return BestSellers;
        }

        public List<Categories> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Products GetProductById(int id)
        {
            var product = _context.Products.Include(x=>x.Categories).FirstOrDefault(n => n.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        private Products NotFound()
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetStatus()
        {
            List<SelectListItem> Status = new()
            {
                new SelectListItem { Value = "True", Text = "Active" },
                new SelectListItem { Value = "False", Text = "Disable" }
            };
            return Status;
        }

       

        public Products UpdateProduct(int id, Products product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }

        //public IOrderedQueryable<Products> GetProductName(string? name)
        //{
          
        //    var productlist = from product in _context.Products select product;
        //    if(name != null)
        //    {
        //        productlist = productlist.Where(x => x.ProductName.Equals(name));

        //    }
        //    return (IOrderedQueryable<Products>)productlist;


        //}

        //public IOrderedQueryable<Products> GetProductCategory(int? categoryId)
        //{
        //    var productlist = from product in _context.Products  select product;
        //    if (categoryId != 0)
        //    {
        //        productlist = productlist.Where(x => x.CatID ==categoryId);

        //    }
        //    return (IOrderedQueryable<Products>)productlist;
        //}

        public IOrderedQueryable<Products> SearchProduct(string searchString, int categoryId)
        {
            var productlist = from product in _context.Products select product;
            if(!string.IsNullOrEmpty(searchString))
            {
                productlist = productlist.Where(x =>x.ProductName.Contains(searchString));

            }
            if(categoryId != 0)
            {
                productlist = productlist.Where(x=>x.CatID ==  categoryId);
            }
            return (IOrderedQueryable<Products>)productlist;
        }
    }
}
