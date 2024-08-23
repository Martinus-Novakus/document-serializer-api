using MediatR;

namespace SerializerSampleApi.Api.Features.Documents.Create;

public record CreateDocumentCommand(CreateDocumentRequest Request) : IRequest<CreateDocumentResponse>;