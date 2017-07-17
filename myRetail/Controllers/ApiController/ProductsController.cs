using Logic.Services.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.OutputCache.V2;

namespace myRetail.Controllers.ApiController
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    [CacheOutput(ClientTimeSpan = 5, ServerTimeSpan = 5)]
    public class ProductsController : System.Web.Http.ApiController
	{
		private readonly IProductApiService _productApiService;

		public ProductsController(IProductApiService productService)
		{
			_productApiService = productService;
		}

		[Route("api/Product")]
		[HttpGet]
		public async Task<IHttpActionResult> Product(long id)
		{
			try
			{
				var product = await _productApiService.GetProduct(id);
                if(product == null)
                {
                    return NotFound();
                }
				return Ok(product);
			}
			catch (Exception)
			{
				return InternalServerError();
			}
		}

		[Route("api/Products")]
		[HttpGet]
		public async Task<IHttpActionResult> Products()
		{
			try
			{
				var products = await _productApiService.GetProducts();
                if (products == null)
                {
                    return NotFound();
                }
                return Ok(products);
			}
			catch (Exception)
			{
				return InternalServerError();
			}
		}
	}
}
