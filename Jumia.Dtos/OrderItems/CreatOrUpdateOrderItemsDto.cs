﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumia.Dtos.OrderItems
{
    public class CreatOrUpdateOrderItemsDto
    {
        public int Id { get; set; }
        public int ProductQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int? Discount { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
