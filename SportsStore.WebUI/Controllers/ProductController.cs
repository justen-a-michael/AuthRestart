﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using System.Security.Principal;

namespace SportsStore.WebUI.Controllers {

    public class ProductController : Controller {
        public List<Product> peepee = new List<Product>();

        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
        
        public ViewResult Summary(string returnUrl, int id)
        {
            return View(new ProductsListViewModel
            {
                ReturnUrl = returnUrl,
                Id = id
            });
        }

        public RedirectToRouteResult fuck(int id, string returnUrl)
        {
            Product poopoo = repository.Products.FirstOrDefault(p => p.ProductID == id);
            if (poopoo != null)
            {
                return RedirectToAction("Summary", new { returnUrl });
            }
            return RedirectToAction("Summary", new { returnUrl });
        }

        [Authorize]
        public ViewResult List(string category, int page = 1) {
            ProductsListViewModel model = new ProductsListViewModel {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Products.Count() :
                    repository.Products.Where(e => e.Category ==
                    category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}