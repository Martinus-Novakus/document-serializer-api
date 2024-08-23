namespace SerializerSampleApi.Api.Features.Documents.Create;

public record CreateDocumentResponse(string Id, string[] Tags, CreateDocumentResponseData Data);