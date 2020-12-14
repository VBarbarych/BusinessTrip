using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ForeignKeyAttribute = System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute;

namespace BusinessTrip.Models
{
    [Table("AspUserStatement")]
    public class ApplicationUserStatement
    {
        [Key]
        [Column(Order = 1)]
        [MaxLength(450)]
        [Required]
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser User { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        public int? StatementId { get; set; }
        [ForeignKey("StatementId")]
        public virtual ApplicationStatement Statement { get; set; }
    }
}
