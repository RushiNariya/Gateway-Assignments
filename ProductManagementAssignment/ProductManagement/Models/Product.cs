using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    //Product Model
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "Please Enter Product's Name.")]
        public string Name { get; set; }

        [Display(Name = "Product Price")]
        [Required(ErrorMessage = "Please Enter Product's Price.")]
        public double Price { get; set; }

        [Display(Name = "Product Quantity")]
        [Required(ErrorMessage = "Please Enter Product's Quantity.")]
        public int Quantity { get; set; }

        [Display(Name = "Product Short Description")]
        [Required(ErrorMessage = "Please Enter Product's Short Discription.")]
        [StringLength(150, MinimumLength = 2)]
        public string Short_Desc { get; set; }

        [Display(Name = "Product Long Description")]
        public string Long_Desc { get; set; }

        [Display(Name = "Product's Small Image")]
        [Required(ErrorMessage = "Please Enter Product's Image Jpg or Png.")]
        public string SmallImagePath { get; set; }

        [FileExtension]
        [NotMapped]
        public HttpPostedFileBase SmallImage { get; set; }

        [Display(Name = "Product's Large Image")]
        public string LargeImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase LargeImage { get; set; }

        [Display(Name = " Product Category")]
        [Required]
        public short CategoryId { get; set; }

        public Category Category { get; set; }
    }

    //DbContext
    public class ProductContext : ApplicationDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}