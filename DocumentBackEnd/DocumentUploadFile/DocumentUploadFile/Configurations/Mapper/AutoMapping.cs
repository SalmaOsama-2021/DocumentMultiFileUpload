using AutoMapper;
using DocumentUploadFile.Models.Api.Response;
using DocumentUploadFile.Models.Domain;

namespace DocumentTask.Configurations.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<documents, documentsDto>();
            CreateMap<Document_files, Document_filesDto>();
        }
    }
}
