namespace SerializerSampleApi.Api.Features.Documents.Create;

public record CreateDocumentRequest(string Id, string[] Tags, CreateDocumentRequestData Data);