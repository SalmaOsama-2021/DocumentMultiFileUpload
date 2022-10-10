
using DocumentUploadFile.DataAccess;
using DocumentUploadFile.DataAccess.Repository_Interface.Documents;
using DocumentUploadFile.Models.Api.Response;
using DocumentUploadFile.Models.Domain;
using HRMS.Models.API.Request.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Models.API.Request;
using Newtonsoft.Json;
using System.Net;


namespace DocumentUploadFile.DataAccess.Repository.DocumentsRepository
{
    public class DocumentRepository: IDocumentRepository
    {
        private readonly ApplicationDbContext context;
   
        public DocumentRepository(ApplicationDbContext db) 
        {
            this.context = db;
        }

        public async Task<int> AddDocument(documents request)
        {
            try
            {
                await context.documents.AddAsync(request);
                await context.SaveChangesAsync();
                return request.ID;

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> deleteDocument(int DocumentId)
        {
            try
            {
                var Documents = await context.documents.FindAsync(DocumentId);
                Documents.isDeleted = true;
                await context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<List<documents>> getDocumentDatatable(int documentId)
        {
            var documents = await context.documents.Include(x => x.Document_files.Where(i => !i.isDeleted.Value))
                .Where(x => x.isDeleted != true ).OrderByDescending(x => x.ID)
                .ToListAsync();
   
            return documents;
        }

        public async Task<documents> getDocumentById(int documentId)
        {
            var documents = await context.documents.Include(x => x.Document_files.Where(i => !i.isDeleted.Value)).Where(x => x.ID ==documentId
            && !x.isDeleted.Value).FirstOrDefaultAsync();

            return documents;
        }

        public async Task<int> UpdateDocument(documents request)
        {
            try
            {
                 context.documents.Update(request);
                request.Document_files
                    .ForEach(x =>
                {
                    if (x.ID != 0)
                    {
                        context.Document_files.Update(x);
                    }
                    else context.Document_files.Add(x);
                });
               await context.SaveChangesAsync();
                

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<List<Priority>> getAllPriority()
        {
            var Priorities = await context.Priority
                .Where(x => x.isDeleted != true)
                .ToListAsync();

            return Priorities;
        }

       
    }
}
