namespace SerializerSampleApi.Api.Features.Documents.Get;

public class GetDocumentResponse
{
    public string Id { get; set; } = string.Empty;
    public string[] Tags { get; set; } = [];
    public GetDocumentData Data { get; set; } = default!;
}