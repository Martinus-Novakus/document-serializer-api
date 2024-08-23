using SerializerSampleApi.Api.Models;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;

namespace SerializerSampleApi.Api.Services;

public class CacheStorageService : IStorageService
{
    private readonly IMemoryCache _memoryCache;

    public CacheStorageService(
        IMemoryCache memoryCache
    )
    {
        _memoryCache = memoryCache;
    }

    public Task<bool> IsUniqueAsync(string id, CancellationToken cancellationToken)
    {
        return Task.FromResult(_memoryCache.Get(id) == null);
    }

    public Task CreateAsync(DocumentModel document, CancellationToken cancellationToken)
    {
        var result = JsonSerializer.Serialize(document);
        _memoryCache.Set(document.Id, result);
        return Task.CompletedTask;
    }

    public Task<DocumentModel?> GetAsync(string id, CancellationToken cancellationToken)
    {
        return Task.FromResult(
            _memoryCache.TryGetValue(id, out string? result) && result != null ? JsonSerializer.Deserialize<DocumentModel?>(result) : null
        );
    }

    public Task UpdateAsync(DocumentModel document, CancellationToken cancellationToken)
    {
        var result = JsonSerializer.Serialize(document);
        _memoryCache.Set(document.Id, result);
        return Task.CompletedTask;
    }
}