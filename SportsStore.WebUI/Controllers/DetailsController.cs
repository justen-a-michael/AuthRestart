using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class DetailsController : Controller
    {
        // GET: Details
        private IProductRepository repository;
        public DetailsController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(Product p, string returnUrl)
        {

            return View(new ProductDetailsViewModel
            {
                ReturnUrl = returnUrl,
                product = p
            });
        }

        //public RedirectToRouteResult ViewDetails(Product prod, string returnUrl)
        //{
        //    Product product = repository.Products.FirstOrDefault(p => p.ProductID == prod.ProductID);

        //    if(product != null)
        //    {
        //        product.
        //    }
        //}
    }
}