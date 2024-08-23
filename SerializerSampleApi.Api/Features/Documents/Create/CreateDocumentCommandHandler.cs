using AutoMapper;
using SerializerSampleApi.Api.Models;
using SerializerSampleApi.Api.Services;
using FluentValidation;

namespace SerializerSampleApi.Api.Features.Documents.Create;

public class CreateDocumentCommandHandler : HandlerBase<CreateDocumentCommand, CreateDocumentResponse>
{
    private readonly IStorageService _storageService;

    public CreateDocumentCommandHandler(
        IValidator<CreateDocumentCommand> validator,
        ILogger<CreateDocumentCommandHandler> logger,
        IMapper mapper,
        IStorageService storageService
    ) : base(validator, logger, mapper)
    {
        _storageService = storageService;
    }

    protected override async Task<CreateDocumentResponse> HandleInternal(CreateDocumentCommand command, CancellationToken cancellationToken)
    {
        var document = _mapper.Map<DocumentModel>(command.Request);
        
        await _storageService.CreateAsync(
            document,
            cancellationToken
        );

        return _mapper.Map<CreateDocumentResponse>(document);
    }
}