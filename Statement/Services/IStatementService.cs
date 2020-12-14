using BusinessTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statement.Services
{
    public interface IStatementService
    {
        Task CreateStatement(ApplicationStatement statement);

        void WorkWithDocFile(ApplicationStatement statement);
    }
}
