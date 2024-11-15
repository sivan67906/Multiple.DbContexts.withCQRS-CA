using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multiple.DbContexts.Application.Product.Commands.CreateProduct;
using Multiple.DbContexts.Application.Product.Commands.DeleteProduct;
using Multiple.DbContexts.Application.Product.Commands.UpdateProduct;
using Multiple.DbContexts.Application.Product.Queries.GetProductById;
using Multiple.DbContexts.Application.Product.Queries.GetProducts;

namespace Multiple.DbContexts.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ApiBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productList = await Mediator.Send(new GetProductsQuery());
        return Ok(productList);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand entity)
    {
        var newProduct = await Mediator.Send(entity);

        return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await Mediator.Send(new GetProductByIdQuery() { Id = id });

        return Ok(product);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateProductCommand entity)
    {
        if (id != entity.Id)
            return BadRequest();

        var upProduct = await Mediator.Send(entity);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var delProduct = await Mediator.Send(new DeleteProductCommand() { Id = id });

        return NoContent();
    }
}
