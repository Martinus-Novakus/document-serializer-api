using SerializerSampleApi.Api.Features.Documents.Create;
using SerializerSampleApi.Api.Services;
using FluentValidation.TestHelper;
using Moq;

namespace SerializerSampleApi.Tests.Features.Documents.Create;

public class CreateDocumentCommandValidatorTests
{
    private readonly Mock<IStorageService> _storageServiceMock;
    public CreateDocumentCommandValidatorTests()
    {
        _storageServiceMock = new Mock<IStorageService>();
    }

    private CreateDocumentCommandValidator GetTestInstance()
    {
        return new CreateDocumentCommandValidator(
            _storageServiceMock.Object
        );
    }

    [Fact]
    public async Task OnValidRequest_ShouldReturnOk()
    {
        var command = new CreateDocumentCommand(
            new (Guid.NewGuid().ToString(), ["tag1", "tag2"], new ("first", "second"))
        );

        var instance = GetTestInstance();

        _storageServiceMock
            .Setup(x => x.IsUniqueAsync(command.Request.Id, default))
            .Returns(Task.FromResult(true));

        var result = await instance.TestValidateAsync(command);

        result.ShouldNotHaveAnyValidationErrors();

        _storageServiceMock.Verify(x => x.IsUniqueAsync(command.Request.Id, default), Times.Once);
    }

    [Fact]
    public async Task OnEmptyId_ShouldReturn400()
    {
        var command = new CreateDocumentCommand(
            new (string.Empty, ["tag1", "tag2"], new ("first", "second"))
        );

        var instance = GetTestInstance();

        _storageServiceMock
            .Setup(x => x.IsUniqueAsync(command.Request.Id, default))
            .Returns(Task.FromResult(true));

        var result = await instance.TestValidateAsync(command);

        result.ShouldHaveValidationErrorFor(x => x.Request.Id);

        _storageServiceMock.Verify(x => x.IsUniqueAsync(command.Request.Id, default), Times.Once);
    }

    [Fact]
    public async Task OnDuplicateId_ShouldReturn400()
    {
        var command = new CreateDocumentCommand(
            new (Guid.NewGuid().ToString(), ["tag1", "tag2"], new ("first", "second"))
        );

        var instance = GetTestInstance();

        _storageServiceMock
            .Setup(x => x.IsUniqueAsync(command.Request.Id, default))
            .Returns(Task.FromResult(false));

        var result = await instance.TestValidateAsync(command);

        result.ShouldHaveValidationErrorFor(x => x.Request.Id);

        _storageServiceMock.Verify(x => x.IsUniqueAsync(command.Request.Id, default), Times.Once);
    }

    [Fact]
    public async Task OnNoProvidedTag_ShouldReturn400()
    {
        var command = new CreateDocumentCommand(
            new (Guid.NewGuid().ToString(), [], new ("first", "second"))
        );

        var instance = GetTestInstance();

        _storageServiceMock
            .Setup(x => x.IsUniqueAsync(command.Request.Id, default))
            .Returns(Task.FromResult(true));

        var result = await instance.TestValidateAsync(command);

        result.ShouldHaveValidationErrorFor(x => x.Request.Tags);

        _storageServiceMock.Verify(x => x.IsUniqueAsync(command.Request.Id, default), Times.Once);
    }
}