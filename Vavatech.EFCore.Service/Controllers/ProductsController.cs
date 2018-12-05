using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vavatech.EFCore.Generator;
using Vavatech.EFCore.IServices;
using Vavatech.EFCore.Models;

namespace Vavatech.EFCore.Service.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        private IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet]
        public ActionResult<IList<Product>> Get()
        {
            var products = productsService.Get();

            return Ok(products);
        }

        //[Route("~/[controller]")]
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    var products = productsService.Get();

        //    return View(products);
        //}

        [Route("~/[controller]")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var products = await productsService.GetAsync();

            return View(products);
        }



        [HttpGet]
        [Route("~/[controller]/[action]")]
        public ActionResult Add()
        {
            var product = new Product();


            return View(product);

        }

        //[HttpPost]
        //[Route("~/[controller]/[action]")]
        //public ActionResult Add([FromForm] Product product)
        //{
        //    productsService.Add(product);

        //    return View(product);
        //}

        [HttpPost]
        [Route("~/[controller]/[action]")]
        public async Task<ActionResult> Add([FromForm] Product product)
        {
            await productsService.AddAsync(product);

            return View(product);
        }
    }
}
