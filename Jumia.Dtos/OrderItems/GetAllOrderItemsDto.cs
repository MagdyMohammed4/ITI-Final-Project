﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumia.Dtos.OrderItems
{
    public class GetAllOrderItemsDto
    {
        public int OrderId { get; set; }
        public List<byte[]>? Images { get; set; }
        public string ProductName { get; set; }
        public string? ProductNameAr { get; set; }
        public string ProductDiscription { get; set; }
        public string? ProductSize { get; set; }
        public float? Pro_Weight { get; set; }
        public int ProductQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int? Discount { get; set; }
        public int? productId { get; set; }


    }
}
