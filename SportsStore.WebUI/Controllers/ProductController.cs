using System;
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

        //[Authorize]
        //public ActionResult Index()
        //{
        //    return View(GetData("Index"));
        //}
        ////[Authorize(Roles = "Users")]
        //public ActionResult OtherAction()
        //{
        //    return View("Index", GetData("OtherAction"));
        //}
        //private Dictionary<string, object> GetData(string actionName)
        //{
        //    Dictionary<string, object> dict
        //    = new Dictionary<string, object>();
        //dict.Add("Action", actionName);
        //    dict.Add("User", HttpContext.User.Identity.Name);
        //    dict.Add("Authenticated", HttpContext.User.Identity.IsAuthenticated);
        //    dict.Add("Auth Type", HttpContext.User.Identity.AuthenticationType);
        //    dict.Add("In Users Role", HttpContext.User.IsInRole("Users"));
        //    return dict;
        //}

        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
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