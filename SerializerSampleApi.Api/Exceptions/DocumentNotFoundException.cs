namespace SerializerSampleApi.Api.Exceptions;

public class DocumentNotFoundException : Exception
{
    public DocumentNotFoundException(string id) : base($"Document with id '{id}' not found!")
    {
    }
}