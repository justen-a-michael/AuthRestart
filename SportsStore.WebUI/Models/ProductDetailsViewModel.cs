using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Models
{
    public class ProductDetailsViewModel
    {
        public Product product { get; set; }
        public String ReturnUrl { get; set; }
    }
}