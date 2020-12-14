using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessTrip.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            UserStatements = new HashSet<ApplicationUserStatement>();
        }

        public virtual ICollection<ApplicationUserStatement> UserStatements { get; set; }

    }
}
