﻿using Jumia.Application.IServices;
using Jumia.Application.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JumiaStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductServices productServices, ICategoryService categoryService)
        {
            _productServices = productServices;
            _categoryService = categoryService;


        }
        [HttpGet]
        public async Task<IActionResult> Getall()
        {

            try
            {
                var products = await _productServices.GetAllPagination(10, 1);

                return Ok(products.Entities);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }

        }



        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetbyId(int id)
        {


            var productid = await _productServices.GetOne(id);
            if (productid == null)
            {
                return Ok("notfound");
            }
            else
            {
                return Ok(productid);
            }

        }
        [HttpGet]
        [Route("{Name:Alpha}")]
        public async Task<IActionResult> GetbyName(string name)

        {
            var productname = await _productServices.Getbyname(name);
            if (productname == null)
            {
                return Ok("NotFound");
            }
            else
            {
                return Ok(productname);
            }
        }
    }
}
////Bahaa http://localhost:5094/api/Product