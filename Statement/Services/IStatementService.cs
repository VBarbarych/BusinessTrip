using BusinessTrip.Models;
using Statement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statement.Services
{
    public interface IStatementService
    {
        Task CreateStatement(ApplicationStatement statement);

        StatementViewModel GetAllStatements();

        byte[] WorkWithDocFile(ApplicationStatement statement);
    }
}
