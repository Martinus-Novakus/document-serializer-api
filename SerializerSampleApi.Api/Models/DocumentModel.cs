namespace SerializerSampleApi.Api.Models;

public class DocumentModel
{
    public DocumentModel(string id, string[] tags, DocumentDataModel data)
    {
        Id = id;
        Tags = tags;
        Data = data;
    }

    public string Id { get; set; } = string.Empty;
    public string[] Tags { get; set; } = [];
    public DocumentDataModel Data { get; set; } = default!;
}