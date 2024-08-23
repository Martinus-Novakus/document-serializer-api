namespace SerializerSampleApi.Api.Features.Documents.Create;

public class CreateDocumentRequestData
{
    public CreateDocumentRequestData()
    {
    }

    public CreateDocumentRequestData(string first, string second)
    {
        First = first;
        Second = second;
    }

    public string First { get; set; } = string.Empty;
    public string Second { get; set; } = string.Empty;
}