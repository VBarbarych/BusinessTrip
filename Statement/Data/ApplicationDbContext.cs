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

            builder.Entity<IdentityRole>().HasData(new List<IdentityRole>
            {
                new IdentityRole {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER"
                },
            });

            builder.Entity<ApplicationStatus>().HasData(new List<ApplicationStatus>
            {
                new ApplicationStatus {
                    StatusId = 1,
                    StatusName = "Прийнято на розляд",
                },
                new ApplicationStatus {
                    StatusId = 2,
                    StatusName = "До опрацювання",
                },
                new ApplicationStatus {
                    StatusId = 3,
                    StatusName = "Схвалено",
                },
                new ApplicationStatus {
                    StatusId = 4,
                    StatusName = "Зареєстровано",
                },
            });

            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "1", // primary key
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = hasher.HashPassword(null, "!1Admin"),
                    Email = "admin@admin.admin",
                    NormalizedEmail = "admin@admin.admin",
                    EmailConfirmed = true,
                    SecurityStamp = string.Empty
                },

                new IdentityUser
                {
                    Id = "2", // primary key
                    UserName = "User",
                    NormalizedUserName = "STAFF",
                    PasswordHash = hasher.HashPassword(null, "!1User"),
                    Email = "user@user.user",
                    NormalizedEmail = "user@user.user",
                    EmailConfirmed = true,
                    SecurityStamp = string.Empty
                },

                new IdentityUser
                {
                    Id = "3", // primary key
                    UserName = "User2",
                    NormalizedUserName = "USER2",
                    PasswordHash = hasher.HashPassword(null, "!2User"),
                    Email = "user2@user2.user2",
                    NormalizedEmail = "USER2@USER2.USER2",
                    EmailConfirmed = true,
                    SecurityStamp = string.Empty
                },

                new IdentityUser
                {
                    Id = "4", // primary key
                    UserName = "User3",
                    NormalizedUserName = "USER3",
                    PasswordHash = hasher.HashPassword(null, "!3User"),
                    Email = "use32@user3.user3",
                    NormalizedEmail = "USER3@USER3.USER3",
                    EmailConfirmed = true,
                    SecurityStamp = string.Empty
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1", // for admin username
                    UserId = "1"  // for admin role
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2", // for staff username
                    UserId = "2"  // for staff role
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2", // for staff username
                    UserId = "3"  // for staff role
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2", // for staff username
                    UserId = "4"  // for staff role
                }

            );

            builder.Entity<ApplicationStatement>().HasData(new List<ApplicationStatement>
            {
                new ApplicationStatement {
                    StatementId = 1,
                    UserNameGenitiveCase = "Галини",
                    UserSurNameGenitiveCase = "Хланти",
                    UserLastNameGenitiveCase = "Михайлівної",
                    SubdivisionAtTheMainPlaceOfWork = "Архів Університету",
                    PositionAtTheMainPlaceOfWork = "Діловод",
                    SubdivisionPartTime = "",
                    PositionPartTime  = "Архіваріус",
                    TypeOfBusinessTrip = "Відрядження закордон",
                    PurposeOfBusinessTrip = "З метою проходження стажування",
                    TypeOfSalaryRetention = "Зі збереженням середньої зарплати за основним місце праці",
                    StatementPlaceOfDestination = "Вроцлав",
                    StatementCountryOfDestination = "Польща",
                    InstitutionWhereYouGo = "Вроцлавський університет",
                    DateOfBusinessTrip = new DateTime(2021, 1, 15),
                    DateOfСompletionBusinessTrip = new DateTime(2021, 1, 18),
                    RouteOfBusinessTrip  = "Львів-Вроцлав-Львів",
                    TransportOfBusinessTrip = "Залізничний",
                    PaymentOfTravelExpenses = "За власний кошт/ за рахунок приймаючої сторони",
                    BasisOfBusinessTrip = "Запрошення"
                },

                new ApplicationStatement {
                    StatementId = 2,
                    UserNameGenitiveCase = "Лідії",
                    UserSurNameGenitiveCase = "Яремчук",
                    UserLastNameGenitiveCase = "Романівної",
                    SubdivisionAtTheMainPlaceOfWork = "Відділ кадрів",
                    PositionAtTheMainPlaceOfWork = "Старший інспектор",
                    SubdivisionPartTime = "",
                    PositionPartTime  = "Інспектор з кадрів",
                    TypeOfBusinessTrip = "Відрядження по Україні",
                    PurposeOfBusinessTrip = "",
                    TypeOfSalaryRetention = "Зі збереженням середньої зарплати за основним місцем праці та за сумісництвом",
                    StatementPlaceOfDestination = "Київ",
                    StatementCountryOfDestination = "Польща",
                    InstitutionWhereYouGo = "Міністерство освіти і науки України ",
                    DateOfBusinessTrip = new DateTime(2021, 1, 12),
                    DateOfСompletionBusinessTrip = new DateTime(2021, 1, 13),
                    RouteOfBusinessTrip  = "Львів-Київ-Львів",
                    TransportOfBusinessTrip = "Залізничний",
                    PaymentOfTravelExpenses = "За рахунок коштів університету",
                    BasisOfBusinessTrip = "Запрошення"
                },

            });

            builder.Entity<ApplicationUserStatement>().HasData(new List<ApplicationUserStatement>
            {
                new ApplicationUserStatement {
                    Id = "3",
                    StatementId = 1
                },
                new ApplicationUserStatement {
                    Id = "4",
                    StatementId = 2
                }
            });

            builder.Entity<ApplicationCurrentStatus>().HasData(new List<ApplicationCurrentStatus>
            {
                new ApplicationCurrentStatus {
                    CurrentStatusId = 1,
                    StatementId = 1,
                    StatusId = 4,
                    DateOfLastChanges = new DateTime(2020, 12, 12, 12, 23, 33),
                    CurrentСomment = "Всі дані вказано."
                },
                new ApplicationCurrentStatus {
                    CurrentStatusId = 2,
                    StatementId = 2,
                    StatusId = 2,
                    DateOfLastChanges = new DateTime(2020, 12, 18, 10, 07, 14),
                    CurrentСomment = "Не вказано мети участі."
                }
            });

            builder.Entity<ApplicationHistoryOfStatus>().HasData(new List<ApplicationHistoryOfStatus>
            {
                new ApplicationHistoryOfStatus {
                    CurrentStatusId = 1,
                    HistoryOfStatusId = 1,                 // насправді це  statementId
                    StatusId = 1,
                    DateOfChanges = new DateTime(2020, 12, 11, 14, 55, 36),
                    Сomment = "Прийнято на розляд"
                },
                new ApplicationHistoryOfStatus {
                    CurrentStatusId = 2,
                    HistoryOfStatusId = 1,
                    StatusId = 3,
                    DateOfChanges = new DateTime(2020, 12, 12, 10, 33, 24),
                    Сomment = "Схвалено оскільки всі дані вірно вказані"
                },
                new ApplicationHistoryOfStatus {
                    CurrentStatusId = 3,
                    HistoryOfStatusId = 2,
                    StatusId = 2,
                    DateOfChanges = new DateTime(2020, 12, 12, 11, 24, 48),
                    Сomment = "Не вказано мети участі"
                },
                new ApplicationHistoryOfStatus {
                    CurrentStatusId = 4,
                    HistoryOfStatusId = 1,
                    StatusId = 4,
                    DateOfChanges = new DateTime(2020, 12, 12, 12, 23, 33),
                    Сomment = "Зареєстровано в системі"
                },
            });


            builder.Entity<ApplicationUserStatement>()
             .HasKey(c => new { c.Id, c.StatementId });

            builder.Entity<ApplicationStatementFile>()
                .HasKey(c => new { c.StatementId, c.FileId });
        }
    }
}
