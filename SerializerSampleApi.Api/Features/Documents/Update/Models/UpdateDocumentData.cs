namespace SerializerSampleApi.Api.Features.Documents.Update;

public class UpdateDocumentData
{
    public UpdateDocumentData()
    {
    }

    public UpdateDocumentData(string first)
    {
        First = first;
    }

    public string First { get; set; } = string.Empty;
}