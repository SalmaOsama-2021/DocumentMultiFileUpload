using AutoMapper;
using DocumentUploadFile.DataAccess;
using DocumentUploadFile.DataAccess.Repository.ResponseBuilders;
using DocumentUploadFile.DataAccess.Repository_Interface.Documents;
using DocumentUploadFile.Models.Api.PublicClass;
using DocumentUploadFile.Models.Api.Response;
using DocumentUploadFile.Models.Domain;
using DocumentUploadFile.Repository_Interface.Documents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;

namespace DocumentUploadFile.Controllers
{
    public class DocumentUploadFile : Controller
    {
        private readonly IDocumentRepository _documentRepository;
        protected readonly IMapper _mapper;
        private readonly ApplicationDbContext context;
        private readonly IFileUploadHelper _fileUploadHelper;
        private readonly IConfiguration _configuration;
        public DocumentUploadFile(IMapper mapper, IDocumentRepository documentRepository, IFileUploadHelper fileUploadHelper, IConfiguration configuration)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
            _fileUploadHelper = fileUploadHelper;
            _configuration = configuration; 
        }
        [HttpPost]
        [Route("DocumentFileUpload/getAllDocument")]
        public async Task<ResponseBuilder> getAllDocument(int DocumentId)
        {
            ResponseBuilder Response = ResponseBuilder.Create(HttpStatusCode.OK, new { status = true }, null);
            try
            {

                var DocumentListData = await _documentRepository.getDocumentDatatable(DocumentId);

                var resultdata = _mapper.Map<List<documentsDto>>(DocumentListData);
                resultdata.ForEach(item =>
                {
                    item.document_files.ForEach(x =>
                    {
                        if (x.File_path != "")
                        {
                            x.File_path = _configuration["baseUrl"] + x.File_path;
                        }

                    });
                });
                    
                Response = ResponseBuilder.Create(HttpStatusCode.OK, resultdata, "Success");

                return Response;
            }
            catch (Exception ex)
            {
                Response = ResponseBuilder.Create(HttpStatusCode.InternalServerError, null, "Faild");
                return Response;


            }

        }
        [HttpPost]
        [Route("DocumentFileUpload/getAllPriority")]
        public async Task<ResponseBuilder> getAllPriority(GeneralDto request)
        {
            ResponseBuilder Response = ResponseBuilder.Create(HttpStatusCode.OK, new { status = true }, null);
            try
            {

                var PriorityListData = await _documentRepository.getAllPriority();


                Response = ResponseBuilder.Create(HttpStatusCode.OK, PriorityListData, "Success");

                return Response;
            }
            catch (Exception ex)
            {
                Response = ResponseBuilder.Create(HttpStatusCode.InternalServerError, null, "Faild");
                return Response;


            }

        }
        [HttpPost]
        [Route("DocumentFileUpload/AddDocuments")]
        public async Task<ResponseBuilder> AddDocuments()
        {
            var request = new documentsDto();
            ResponseBuilder Response = ResponseBuilder.Create(HttpStatusCode.OK, new { status = true }, null);
            try
            {
                request = JsonConvert.DeserializeObject<documentsDto>(Request.Form["requestBody"]);
                if (request.iD != 0)
                {
                    var isUpdated = await UpdateDocument(request);
                    if (isUpdated > 0)
                    {
                        Response = ResponseBuilder.Create(HttpStatusCode.OK, null, "Success");
                    }
                    else Response = ResponseBuilder.Create(HttpStatusCode.InternalServerError, null, "Failed");
                }
                else
                {
                    var isAdded = await AddDocument(request);
                    if (isAdded > 0)
                    {
                        Response = ResponseBuilder.Create(HttpStatusCode.OK, null, "Success");
                    }
                    else Response = ResponseBuilder.Create(HttpStatusCode.InternalServerError, null, "Failed");
                }
                return Response;

            }
            catch (Exception ex)
            {
                Response = ResponseBuilder.Create(HttpStatusCode.InternalServerError, null, "Faild");
                return Response;


            }

        }
        [HttpPost]
        [Route("DocumentFileUpload/getByDocumentId")]
        public async Task<ResponseBuilder> getByDocumentId()
        {
            var request = new GeneralDto();
            ResponseBuilder Response = ResponseBuilder.Create(HttpStatusCode.OK, new { status = true }, null);
            try
            {
                request = JsonConvert.DeserializeObject<GeneralDto>(Request.Form["requestBody"]);
                var DocumentData = await _documentRepository.getDocumentById(request.id);

                var resultdata = _mapper.Map<documentsDto>(DocumentData);
                resultdata.document_files.ForEach(x =>
                {
                    if (x.File_path != "")
                    {
                        x.File_path = _configuration["baseUrl"] + x.File_path;
                    }

                });
                Response = ResponseBuilder.Create(HttpStatusCode.OK, resultdata, "Success");

                return Response;
            }
            catch (Exception ex)
            {
                Response = ResponseBuilder.Create(HttpStatusCode.InternalServerError, null, "Faild");
                return Response;


            }

        }
        [HttpPost]
        [Route("DocumentFileUpload/deleteDocument")]
        public async Task<ResponseBuilder> deleteDocument(int DocumentId)
        {
            var request = new GeneralDto();
            ResponseBuilder Response = ResponseBuilder.Create(HttpStatusCode.OK, new { status = true }, null);
            try
            {
                request = JsonConvert.DeserializeObject<GeneralDto>(Request.Form["requestBody"]);

                var isDeleted = await _documentRepository.deleteDocument(request.id);

                if (isDeleted > 0)
                {
                    Response = ResponseBuilder.Create(HttpStatusCode.OK, null, "Success");
                }
                else
                {
                    Response = ResponseBuilder.Create(HttpStatusCode.InternalServerError, null, "Faild");
                }
                return Response;
            }
            catch (Exception ex)
            {
                Response = ResponseBuilder.Create(HttpStatusCode.InternalServerError, null, "Faild");
                return Response;


            }

        }
        #region PrivatMethod
        public IFormFile Base64ToImage(Document_filesDto attach)
        {
            byte[] bytes = Convert.FromBase64String(attach.fileSource.Substring(attach.fileSource.LastIndexOf(',') + 1));
            MemoryStream stream = new MemoryStream(bytes);
            IFormFile file = new FormFile(stream, 0, bytes.Length, attach.documentFileName, attach.documentFileName);
            return file;
        }
        async Task<string> UploadFiles(IFormFile formFile, string path, int userId)
        {
            var imagePath = await _fileUploadHelper.Upload(formFile, path + userId.ToString());
            return imagePath;
        }
        public async Task<int> AddDocument(documentsDto request)
        {
            try
            {
                var listfromDocument = new List<Document_files>();

                if (request.document_files != null && request.document_files.Count() > 0)
                {
                    request.document_files.ForEach(async x =>
                    {
                        listfromDocument.Add(new Document_files
                        {

                            isDeleted = false,
                            isEnabled = true,
                            Document_ID = x.Document_ID,
                            File_path = x.fileSource != null ? await UploadFiles(Base64ToImage(x), "Attachment/Documnts/", 0) : "",
                            documentFileName = x != null ? x.documentFileName : "",



                        });
                    });

                }
                var allDocuments = new documents
                {
                    isEnabled = true,
                    isDeleted = false,
                    Due_date = request.due_date,
                    Created = request.created,
                    Date = request.date,
                    Name = request.name,
                    PriorityId = request.priorityId,
                    Document_files = listfromDocument
                };
                await _documentRepository.AddDocument(allDocuments);
                //await context.documents.AddAsync(allDocuments);
                //await context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> UpdateDocument(documentsDto request)
        {
            try
            {
                var AllDocument = new documents();
                 AllDocument = await _documentRepository.getDocumentById(request.iD);
                AllDocument.Name = request.name;
                AllDocument.Due_date = request.due_date;
                AllDocument.Date = request.date;
                AllDocument.Created = request.created;
                AllDocument.Due_date = request.due_date;
                AllDocument.PriorityId = request.priorityId;


                foreach (var item in request.document_files)
                {
                    var Document_files = AllDocument.Document_files;
                    if (item.ID != 0)
                    {
                        // update 
                        Document_files.ForEach(async Document_file =>
                        {
                            Document_file.File_path = item.fileSource != null ? await UploadFiles(Base64ToImage(item), "Attachment/Documnts/", 0) : "";
                            Document_file.Document_ID = item.Document_ID;
                            Document_file.ID = item.ID;
                            Document_file.documentFileName = item.documentFileName;
                        });
                       

                    }
                    else
                    {
                        // add
                        var Document_filesobj = new Document_files { File_path = item.fileSource != null ? await UploadFiles(Base64ToImage(item), "Attachment/Documnts/", 0) : "", Document_ID = item.Document_ID, isEnabled = true, ID = item.ID };
                        await context.Document_files.AddRangeAsync(Document_filesobj);
                    }
                }
                await _documentRepository.UpdateDocument(AllDocument);


                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion
    }
}
