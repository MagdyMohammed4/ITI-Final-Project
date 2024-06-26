﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jumia.Model.Commons;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Jumia.Model
{
    public class Shippment : LocalizableEntity
    {
        public string FirstNameEn { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string AdressInformation { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public decimal Cost { get; set; }
        //public string FirstNameAr { get; set; }
        //public string LastNameAr { get; set; }
        //public string AddressAr { get; set; }
        //public string AdressInformationAr { get; set; }
        public string RegionAr { get; set; }
        public string CityAr { get; set; }
      //  [ForeignKey("Order")] ////////
      //  public int OrderId { get; set; }
        [ForeignKey("Customer")] ////////
        public int UserIdentityId { get; set; }
        public UserIdentity Customer { get; set; }
        //public Order Order { get; set; }

    }
    }
