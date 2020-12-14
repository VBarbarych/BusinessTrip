using BusinessTrip.Models;
using Microsoft.EntityFrameworkCore;
using Statement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statement.Services
{
    public class StatementService : IStatementService
    {
        private readonly ApplicationDbContext _context;
        private DbSet<ApplicationStatement> DbSet;

        public StatementService(ApplicationDbContext context)
        {
            _context = context;
            DbSet = context.Set<ApplicationStatement>();
        }

        public async Task CreateStatement(ApplicationStatement statement)
        {
            DbSet.Add(statement);
            await _context.SaveChangesAsync();
        }


    }
}
