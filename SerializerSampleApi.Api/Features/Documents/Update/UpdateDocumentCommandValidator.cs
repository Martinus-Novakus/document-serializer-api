using SerializerSampleApi.Api.Services;
using FluentValidation;

namespace SerializerSampleApi.Api.Features.Documents.Update;

public class UpdateDocumentCommandValidator : AbstractValidator<UpdateDocumentCommand>
{
    public UpdateDocumentCommandValidator()
    {
        RuleFor(x => x.Request.Id)
        .NotEmpty();

        RuleFor(x => x.Request.Tags)
        .NotEmpty();
        
        RuleFor(x => x.Request.Data.First)
        .NotEmpty();
    }
}