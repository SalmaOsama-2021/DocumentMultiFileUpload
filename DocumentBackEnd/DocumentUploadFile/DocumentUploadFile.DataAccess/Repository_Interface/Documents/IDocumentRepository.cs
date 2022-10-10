
using DocumentUploadFile.Models.Api.Response;
using DocumentUploadFile.Models.Domain;
using HRMS.Models.API.Request.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DocumentUploadFile.DataAccess.Repository_Interface.Documents
{
    public interface IDocumentRepository
    {
        Task<int> UpdateDocument(documents request);
       Task<int> AddDocument(documents request);
        Task<int> deleteDocument(int DocumentId);
        Task<documents> getDocumentById(int documentId);
        Task<List<documents>> getDocumentDatatable(int documentId);
        Task<List<Priority>> getAllPriority();
        
    }
}
