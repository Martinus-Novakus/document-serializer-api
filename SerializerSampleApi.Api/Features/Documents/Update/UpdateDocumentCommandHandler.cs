using AutoMapper;
using SerializerSampleApi.Api.Exceptions;
using SerializerSampleApi.Api.Services;
using FluentValidation;

namespace SerializerSampleApi.Api.Features.Documents.Update;

public class UpdateDocumentCommandHandler : HandlerBase<UpdateDocumentCommand>
{
    private readonly IStorageService _storageService;

    public UpdateDocumentCommandHandler(
        IValidator<UpdateDocumentCommand> validator,
        ILogger<UpdateDocumentCommandHandler> logger,
        IMapper mapper,
        IStorageService storageService
    ) : base(validator, logger, mapper)
    {
        _storageService = storageService;
    }

    protected override async Task HandleInternal(UpdateDocumentCommand command, CancellationToken cancellationToken)
    {
        var document = await _storageService.GetAsync(command.Request.Id, cancellationToken) ?? throw new DocumentNotFoundException(command.Request.Id);
        
        await _storageService.UpdateAsync(
            _mapper.Map(command.Request, document),
            cancellationToken
        );
    }
}