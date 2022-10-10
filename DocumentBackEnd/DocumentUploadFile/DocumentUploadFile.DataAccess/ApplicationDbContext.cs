
using DocumentUploadFile.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentUploadFile.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<Priority> Priority { get; set; }
        public DbSet<documents> documents { get; set; }
        public DbSet<Document_files> Document_files { get; set; }
    }
}
