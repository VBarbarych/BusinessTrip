using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statement.Models
{
    public class EditUserViewModel
    {
        public string UserId;
        public string UserEmail;
        public string UserPhoneNumber;

        public List<string> UserClaims;
        public IList<string> UserRoles;

        public EditUserViewModel()
        {
            UserClaims = new List<string>();
            UserRoles = new List<string>();
        }

    }
}
