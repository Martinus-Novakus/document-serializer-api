using AutoMapper;
using SerializerSampleApi.Api.Models;

namespace SerializerSampleApi.Api.Features.Documents.Get;

public class AutoMapperProfileConfiguration : Profile
{
    public AutoMapperProfileConfiguration()
    {
        CreateMap<DocumentModel, GetDocumentResponse>();
        CreateMap<DocumentDataModel, GetDocumentData>();
    }
}