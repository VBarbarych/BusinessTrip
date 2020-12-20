using BusinessTrip.Models;
using Statement.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Statement.Models;

namespace Statement.Services
{
    public interface IStatementService
    {

        Task EditItemAsync(ApplicationStatement statement);
        Task CreateStatement(ApplicationStatement statement, IdentityUser user);

        StatementViewModel GetAllStatements();

        byte[] WorkWithDocFile(ApplicationStatement statement);

        MemoryStream WriteExcelStatementsBetweenDates(BetweenDates dates);
    }
}
