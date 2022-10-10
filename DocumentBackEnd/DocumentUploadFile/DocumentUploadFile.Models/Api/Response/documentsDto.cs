using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentUploadFile.Models.Api.Response
{
    public class documentsDto
    {
        public int iD { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public DateTime created { get; set; }
        public DateTime due_date { get; set; }
        public int priorityId { get; set; }

        public List<Document_filesDto> document_files { get; set; }
    }
    public class Document_filesDto
    {
        public int ID { get; set; }
        public int? Document_ID { get; set; }
        public string fileSource { get; set; }
        public string? File_path { get; set; }
        public string? documentFileName { get; set; }

    }
}

