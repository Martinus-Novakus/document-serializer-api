namespace SerializerSampleApi.Api.Features.Documents.Update;

public class UpdateDocumentRequest
{
    public UpdateDocumentRequest()
    {
    }

    public UpdateDocumentRequest(string id, string[] tags, UpdateDocumentData data)
    {
        Id = id;
        Tags = tags;
        Data = data;
    }

    public string Id { get; set; } = string.Empty;
    public string[] Tags { get; set; } = [];
    public UpdateDocumentData Data { get; set; } = default!;
}