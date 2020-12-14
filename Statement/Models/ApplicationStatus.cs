using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessTrip.Models
{
    [Table("AspStatus")]
    public class ApplicationStatus
    {
        public ApplicationStatus()
        {
            CurrentStatuses = new HashSet<ApplicationCurrentStatus>();
            HistoryOfStatuses = new HashSet<ApplicationHistoryOfStatus>();
        }

        [Key]
        [Required]
        public int StatusId { get; set; }

        [Required]
        [MaxLength(100)]
        public string StatusName { get; set; }

        public virtual ICollection<ApplicationCurrentStatus> CurrentStatuses { get; set; }
        public virtual ICollection<ApplicationHistoryOfStatus> HistoryOfStatuses { get; set; }
    }
}
