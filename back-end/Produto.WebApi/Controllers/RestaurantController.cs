using Microsoft.AspNetCore.Mvc;
using Produto.Application.Dtos;
using Produto.Application.Interfaces.Services;
using Produto.WebApi.Api;
using System.Threading.Tasks;

namespace Produto.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerApi
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> Get() =>
             Response(await _productService.GetAll());

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto) =>
            Response(await _productService.Insert(productDto));

        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<IActionResult> Remove([FromRoute] long id) =>
            Response(await _productService.Remove(id));

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] ProductDto productDto)
        {
            productDto.Id = id;

            return Response(await _productService.Update(productDto));
        }
    }
}
