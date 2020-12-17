using System;
using System.Collections.Generic;
using System.Text;
using BusinessTrip.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Statement.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationCurrentStatus> AspCurrentStatus { get; set; }
        public DbSet<ApplicationFile> AspFile { get; set; }
        public DbSet<ApplicationHistoryOfStatus> AspHistoryOfStatus { get; set; }
        public DbSet<ApplicationStatement> AspStatement { get; set; }
        public DbSet<ApplicationStatementFile> AspStatementFile { get; set; }
        public DbSet<ApplicationStatus> AspStatus { get; set; }
        public DbSet<ApplicationUserStatement> AspUserStatement { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);


            builder.Entity<ApplicationUserStatement>()
             .HasKey(c => new { c.Id, c.StatementId });

            builder.Entity<ApplicationStatementFile>()
                .HasKey(c => new { c.StatementId, c.FileId });
        }
    }
}
