using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessTrip.Models
{
    [Table("AspHistoryOfStatus")]
    public class ApplicationHistoryOfStatus
    {
        [Key]
        [Required]
        public int CurrentStatusId { get; set; }

        [Required]
        public int? HistoryOfStatusId { get; set; }
        [ForeignKey("HistoryOfStatusId")]
        public virtual ApplicationStatement Statement { get; set; }

        [Required]
        public int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        [Display(Name = "Статус")]
        public virtual ApplicationStatus Status { get; set; }

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Введіть коректну дату у форматі: dd/mm/yyyy hh:mm")]
        [Range(typeof(DateTime), "1/1/2010", "1/1/2100")]
        [Display(Name = "Дата")]
        public DateTime? DateOfChanges { get; set; }

        [MaxLength(450)]
        [Display(Name = "Коментар")]
        public string Сomment { get; set; }
    }
}
