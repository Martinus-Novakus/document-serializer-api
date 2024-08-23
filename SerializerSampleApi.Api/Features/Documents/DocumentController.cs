using SerializerSampleApi.Api.Features.Documents.Create;
using SerializerSampleApi.Api.Features.Documents.Get;
using SerializerSampleApi.Api.Features.Documents.Update;
using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace SerializerSampleApi.Api.Features.Documents;

public class DocumentController : ControllerBase
{
    private readonly IMediator _mediator;

    public DocumentController(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }

    [HttpGet("/documents/{id}")]
    public async Task<IActionResult> GetAsync(string id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetDocumentQuery(id), cancellationToken);
        return Ok(result);
    }

    [HttpPost("/documents")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateDocumentRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new CreateDocumentCommand(request), cancellationToken);
        return Created(Request.Host.Value, response);
    }

    [HttpPut("/documents/{id}")]
    public async Task<IActionResult> UpdateAsync(string id, [FromBody] UpdateDocumentRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        await _mediator.Send(new UpdateDocumentCommand(request), cancellationToken);
        return Ok();
    }
}