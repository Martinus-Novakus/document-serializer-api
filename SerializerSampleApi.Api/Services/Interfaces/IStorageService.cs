using SerializerSampleApi.Api.Models;

namespace SerializerSampleApi.Api.Services;

public interface IStorageService
{
    Task<bool> IsUniqueAsync(string id, CancellationToken cancellationToken);
    Task<DocumentModel?> GetAsync(string id, CancellationToken cancellationToken);
    Task CreateAsync(DocumentModel document, CancellationToken cancellationToken);
    Task UpdateAsync(DocumentModel document, CancellationToken cancellationToken);
}