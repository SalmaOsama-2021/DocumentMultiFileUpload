



using DocumentUploadFile.DataAccess.Repository.DocumentsRepository;
using DocumentUploadFile.DataAccess.Repository_Interface.Documents;
using DocumentUploadFile.Repository_Interface.Documents;

namespace HRMS.InjectProviders
{
    public static class ServiceBinding
    {
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IFileUploadHelper, FileUploadHelper>();
            


            return services;
        }
    }
}
