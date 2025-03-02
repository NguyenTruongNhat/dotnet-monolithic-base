using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonolithicBase.Contract.Services.V1.Product;
using MonolithicBase.Presentation.Abstractions;

namespace MonolithicBase.Presentation.Controllers.V1;

[ApiVersion(2)]
public class ProductsController : ApiController
{

    public ProductsController(ISender sender) : base(sender)
    {
    }

    [HttpPost(Name = "CreateProducts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Products([FromBody] Command.CreateProductCommand CreateProduct)
    {
        var result = await Sender.Send(CreateProduct);

        if (result.IsFailure)
            return HandlerFailure(result);

        return Ok(result);
    }
}
