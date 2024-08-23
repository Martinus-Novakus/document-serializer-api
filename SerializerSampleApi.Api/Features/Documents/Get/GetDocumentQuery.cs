using MediatR;

namespace SerializerSampleApi.Api.Features.Documents.Get;

public record GetDocumentQuery(string Id) : IRequest<GetDocumentResponse>;