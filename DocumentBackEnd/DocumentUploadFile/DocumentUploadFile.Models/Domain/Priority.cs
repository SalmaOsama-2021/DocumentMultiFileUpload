using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentUploadFile.Models.Domain
{
    [Table(nameof(Priority), Schema = "Document")]

    public class Priority: Defaults
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
