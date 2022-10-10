
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentUploadFile.Models.Domain
{
    [Table(nameof(Document_files), Schema = "Document")]
    public class Document_files : Defaults
    {
        [Key]
        public int ID { get; set; }
        public int? Document_ID { get; set; }
        [ForeignKey(nameof(Document_ID))]
        public documents documents { get; set; }
        public string File_path { get; set; }
        public string? documentFileName { get; set; }
    }
}
