
using Application.OwnerProperty.GetFilteredProperty;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Tags("WEB Properties")]
[ApiController]
public class GetFilteredPropertyEndpoint : ControllerBase
{
    private readonly IMediator _mediator;

    public GetFilteredPropertyEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }
    /// <summary>
    /// Permite consultar la información de las propiedades de los usuarios por filtros como el nombre, la direccion y el rango de precio
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType(typeof(GetFilteredPropertyQueryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("api/v{version:apiVersion}/getpropertybyfilters")]
    [HttpPost]
    public async Task<IActionResult> GetById([FromBody] GetFilteredPropertyQuery  filters)
    {
        var result = await _mediator.Send(filters);
        if (result is null || result == default)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Permite consultar el top{n} información de las propiedades de los usuarios ordenado por el mas reciente.
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType(typeof(GetTopPropertyQueryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("api/v{version:apiVersion}/getpropertytop/{top}")]
    [HttpGet]
    public async Task<IActionResult> GetById(int top)
    {
        var query = new GetTopPropertyQuery(top);
        var result = await _mediator.Send(query);
        if (result is null || result == default)
            return NotFound();

        return Ok(result);
    }

}