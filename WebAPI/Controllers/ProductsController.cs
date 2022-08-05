using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//attribute
    public class ProductsController : ControllerBase
    {
        //loosely coupled -- bagimlilik var ama soyuta bagimlilik var
        //alttaki field fieldlarin defaultlari private dir
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;   
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //dependency chain

            Thread.Sleep(1000);
            var result = _productService.GetAll();
            if(result.Success)
            {
                return Ok(result); //get requestte 200 ile calisilir 
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int productId)
        {
            //dependency chain

            var result = _productService.GetById(productId);
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }


        [HttpPost("add")]  
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result);

        }
    }
}
