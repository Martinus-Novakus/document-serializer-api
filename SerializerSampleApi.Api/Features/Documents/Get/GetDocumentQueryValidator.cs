using FluentValidation;

namespace SerializerSampleApi.Api.Features.Documents.Get;

public class GetDocumentQueryValidator : AbstractValidator<GetDocumentQuery>
{
    public GetDocumentQueryValidator()
    {
    }
}