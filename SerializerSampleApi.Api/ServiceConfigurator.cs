using SerializerSampleApi.Api.Features.Documents.Create;
using SerializerSampleApi.Api.Features.Documents.Get;
using SerializerSampleApi.Api.Features.Documents.Update;
using SerializerSampleApi.Api.Services;
using FluentValidation;

namespace SerializerSampleApi.Api;

public static class ServiceConfigurator
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        
        services.AddSwaggerGen();
        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Program).Assembly));
        services.AddMemoryCache();
        services.AddAutoMapper(typeof(ServiceConfigurator));

        // select storage implementation
        services.AddScoped<IStorageService, CacheStorageService>();
        // services.AddScoped<IStorageService, LocalStorageService>();
        // services.AddScoped<IStorageService, CloudStorageService>();

        services.AddScoped<IValidator<GetDocumentQuery>, GetDocumentQueryValidator>();
        services.AddScoped<IValidator<CreateDocumentCommand>, CreateDocumentCommandValidator>();
        services.AddScoped<IValidator<UpdateDocumentCommand>, UpdateDocumentCommandValidator>();
    }
}