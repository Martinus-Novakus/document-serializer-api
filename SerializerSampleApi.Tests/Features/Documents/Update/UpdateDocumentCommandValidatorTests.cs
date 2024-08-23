using SerializerSampleApi.Api.Features.Documents.Update;
using FluentValidation.TestHelper;

namespace SerializerSampleApi.Tests.Features.Documents.Update;

public class UpdateDocumentCommandValidatorTests
{
    private UpdateDocumentCommandValidator GetTestInstance()
    {
        return new UpdateDocumentCommandValidator();
    }

    [Fact]
    public async Task OnValidRequest_ShouldReturnOk()
    {
        var command = new UpdateDocumentCommand(
            new (Guid.NewGuid().ToString(), ["tag1", "tag2"], new ("first"))
        );

        var instance = GetTestInstance();

        var result = await instance.TestValidateAsync(command);

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public async Task OnEmptyId_ShouldReturn400()
    {
        var command = new UpdateDocumentCommand(
            new (string.Empty, ["tag1", "tag2"], new ("first"))
        );

        var instance = GetTestInstance();

        var result = await instance.TestValidateAsync(command);

        result.ShouldHaveValidationErrorFor(x => x.Request.Id);
    }

    [Fact]
    public async Task OnNoProvidedTag_ShouldReturn400()
    {
        var command = new UpdateDocumentCommand(
            new (Guid.NewGuid().ToString(), [], new ("first"))
        );

        var instance = GetTestInstance();

        var result = await instance.TestValidateAsync(command);

        result.ShouldHaveValidationErrorFor(x => x.Request.Tags);
    }
}