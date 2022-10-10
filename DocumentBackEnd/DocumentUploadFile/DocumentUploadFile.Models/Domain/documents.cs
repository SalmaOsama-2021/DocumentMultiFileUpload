using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentUploadFile.Models.Domain
{
    [Table(nameof(documents), Schema = "Document")]
    public class documents: Defaults
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime Created { get; set; }
        public DateTime Due_date { get; set; }
        public int PriorityId { get; set; }

        public List<Document_files> Document_files { get; set; }
    }
}
