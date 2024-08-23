using AutoMapper;
using SerializerSampleApi.Api.Models;

namespace SerializerSampleApi.Api.Features.Documents.Create;

public class AutoMapperProfileConfiguration : Profile
{
    public AutoMapperProfileConfiguration()
    {
        CreateMap<CreateDocumentRequest, DocumentModel>();
        CreateMap<CreateDocumentRequestData, DocumentDataModel>();
        CreateMap<DocumentModel, CreateDocumentResponse>();
        CreateMap<DocumentDataModel, CreateDocumentResponseData>();
    }
}