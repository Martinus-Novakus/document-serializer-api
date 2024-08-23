using AutoMapper;
using SerializerSampleApi.Api.Exceptions;
using SerializerSampleApi.Api.Services;
using FluentValidation;

namespace SerializerSampleApi.Api.Features.Documents.Get;

public class GetDocumentQueryHandler : HandlerBase<GetDocumentQuery, GetDocumentResponse>
{
    private readonly IStorageService _storageService;

    public GetDocumentQueryHandler(
        IValidator<GetDocumentQuery> validator,
        ILogger<GetDocumentQueryHandler> logger,
        IMapper mapper,
        IStorageService storageService
    ) : base(validator, logger, mapper)
    {
        _storageService = storageService;
    }

    protected override async Task<GetDocumentResponse> HandleInternal(GetDocumentQuery request, CancellationToken cancellationToken)
    {
        var document = await _storageService.GetAsync(request.Id, cancellationToken) 
            ?? throw new DocumentNotFoundException(request.Id);

        return _mapper.Map<GetDocumentResponse>(document);
    }
}