using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingTech.Areas.Admin.Models
{
    public class CategoryModel
    {
        [Required]
        public string CategoryName { get; set; }


    }
}