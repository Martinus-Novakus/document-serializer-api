using SerializerSampleApi.Api.Services;
using FluentValidation;

namespace SerializerSampleApi.Api.Features.Documents.Create;

public class CreateDocumentCommandValidator : AbstractValidator<CreateDocumentCommand>
{
    private readonly IStorageService _storageService;

    public CreateDocumentCommandValidator(
        IStorageService storageService
    )
    {
        RuleFor(x => x.Request.Id)
        .NotEmpty()
        .MustAsync(BeUniqueIdAsync).WithMessage("Document with this Id already exists.");

        RuleFor(x => x.Request.Tags)
        .NotEmpty();
        
        RuleFor(x => x.Request.Data.First)
        .NotEmpty();
        
        RuleFor(x => x.Request.Data.Second)
        .NotEmpty();
        
        _storageService = storageService;
    }

    private async Task<bool> BeUniqueIdAsync(string id, CancellationToken cancellationToken)
    {
        return await _storageService.IsUniqueAsync(id, cancellationToken);
    }
}