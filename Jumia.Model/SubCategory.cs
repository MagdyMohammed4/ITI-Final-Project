﻿using Jumia.Model.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumia.Model
{
    public class SubCategory: LocalizableEntity
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string? Description { get; set; }
        public byte[]? Image { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

     //   public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<SubCategorySpecification> Specifications { get; set; }

        public SubCategory()
        {
          
          //  Products = new List<Product>();
            Specifications = new List<SubCategorySpecification>();

        }
    }
}
