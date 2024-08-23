using AutoMapper;
using SerializerSampleApi.Api.Models;

namespace SerializerSampleApi.Api.Features.Documents.Update;

public class AutoMapperProfileConfiguration : Profile
{
    public AutoMapperProfileConfiguration()
    {
        CreateMap<UpdateDocumentRequest, DocumentModel>();
        CreateMap<UpdateDocumentData, DocumentDataModel>();
    }
}