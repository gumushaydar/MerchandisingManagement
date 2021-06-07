using MediatR;
using Merchandising.Application.Products.Commands.CreateProduct;
using Merchandising.Application.Products.Commands.DeleteProduct;
using Merchandising.Application.Products.Commands.UpdateProduct;
using Merchandising.Application.Products.Queries;
using Merchandising.Application.Products.Queries.ProductDetail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Merchandising.WebUI.Controllers
{
    //[Authorize]
    public class ProductsController : ApiController
    {

        [HttpGet]
        public async Task<ActionResult<ProductsVm>> Get()
        {
            return await Mediator.Send(new GetProductsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await Mediator.Send(new GetProductDetailQuery { Id = id });

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProductCommand { Id = id });

            return NoContent();
        }

    }
}
