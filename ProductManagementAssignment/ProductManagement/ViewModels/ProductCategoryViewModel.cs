using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductManagement.Models;

namespace ProductManagement.ViewModels
{
    //ProductCategoryViewModel Class
    public class ProductCategoryViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Product Product { get; set; }
    }
}