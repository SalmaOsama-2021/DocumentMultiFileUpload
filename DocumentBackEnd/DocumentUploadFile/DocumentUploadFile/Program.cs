
using DocumentUploadFile.DataAccess;
using DocumentUploadFile.DataAccess.Repository.DocumentsRepository;
using DocumentUploadFile.DataAccess.Repository_Interface.Documents;
using HRMS.InjectProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
#region DB Connection

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefualtConnection")));
new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);


#endregion



#region Service Bindings
// you can inject in class file "ServiceBinding" inside Folder "InjectProviders"
object value = builder.Services.InjectServices();
#endregion
#region Mapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);
#endregion
builder.Services.AddCors(p => p.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Attachment")),
    RequestPath = new PathString("/Attachment")
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
