﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumia.Dtos.Category
{
    public class GetAllCategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string? NameAr { get; set; }

        public string? Description { get; set; }

        public byte[]? Image { get; set; }

       

    }
}
