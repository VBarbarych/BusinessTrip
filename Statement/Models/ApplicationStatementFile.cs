using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessTrip.Models
{
    [Table("AspStatementFile")]
    public class ApplicationStatementFile
    {
        [Key]
        [Column(Order = 1)]
        [Required]
        public int? StatementId { get; set; }
        [ForeignKey("StatementId")]
        public virtual ApplicationStatement Statement { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        public int? FileId { get; set; }
        [ForeignKey("FileId")]
        public virtual ApplicationFile File { get; set; }
    }
}
