using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessTrip.Models
{
    [Table("AspFile")]
    public class ApplicationFile
    {
        public ApplicationFile()
        {
            StatementFiles = new HashSet<ApplicationStatementFile>();
        }

        [Key]
        [Required]
        public int FileId { get; set; }
        [Required]
        [MaxLength(256)]
        public string FileName { get; set; }
        [Required]
        [RegularExpression(@"(.doc|.docx|.pdf|.xls|.xlsx|.png|.jpg|.jpeg)$", ErrorMessage = "Лише документи та фото дозволено")]
        //[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        public string FileContentType { get; set; }
        [Required]
        public byte[] FileData { get; set; }

        public virtual ICollection<ApplicationStatementFile> StatementFiles { get; set; }
    }
}
