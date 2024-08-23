using MediatR;

namespace SerializerSampleApi.Api.Features.Documents.Update;

public record UpdateDocumentCommand(UpdateDocumentRequest Request) : IRequest;