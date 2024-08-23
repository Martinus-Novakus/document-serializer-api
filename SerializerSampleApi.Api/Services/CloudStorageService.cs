using SerializerSampleApi.Api.Models;

namespace SerializerSampleApi.Api.Services;

public class CloudStorageService : IStorageService
{
    public Task<bool> IsUniqueAsync(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(DocumentModel document, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<DocumentModel?> GetAsync(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(DocumentModel document, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}