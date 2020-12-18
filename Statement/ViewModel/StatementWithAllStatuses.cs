using BusinessTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statement.ViewModel
{
    public class StatementWithAllStatuses
    {
        public ApplicationStatement Statement { get; set; }
        public ApplicationCurrentStatus CurrentStatus { get; set; }
        public List<ApplicationHistoryOfStatus> HistoryOfStatuses { get; set; }
    }
}
