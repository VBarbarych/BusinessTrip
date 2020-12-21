﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Statement.Data;

namespace Statement.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201220141456_LittleFix")]
    partial class LittleFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BusinessTrip.Models.ApplicationCurrentStatus", b =>
                {
                    b.Property<int>("CurrentStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrentСomment")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("DateOfLastChanges")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("StatementId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("CurrentStatusId");

                    b.HasIndex("StatementId");

                    b.HasIndex("StatusId");

                    b.ToTable("AspCurrentStatus");

                    b.HasData(
                        new
                        {
                            CurrentStatusId = 1,
                            CurrentСomment = "Всі дані вказано.",
                            DateOfLastChanges = new DateTime(2020, 12, 12, 12, 23, 33, 0, DateTimeKind.Unspecified),
                            StatementId = 1,
                            StatusId = 4
                        },
                        new
                        {
                            CurrentStatusId = 2,
                            CurrentСomment = "Не вказано мети участі.",
                            DateOfLastChanges = new DateTime(2020, 12, 18, 10, 7, 14, 0, DateTimeKind.Unspecified),
                            StatementId = 2,
                            StatusId = 2
                        });
                });

            modelBuilder.Entity("BusinessTrip.Models.ApplicationFile", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("FileId");

                    b.ToTable("AspFile");
                });

            modelBuilder.Entity("BusinessTrip.Models.ApplicationHistoryOfStatus", b =>
                {
                    b.Property<int>("CurrentStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateOfChanges")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("HistoryOfStatusId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Сomment")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.HasKey("CurrentStatusId");

                    b.HasIndex("HistoryOfStatusId");

                    b.HasIndex("StatusId");

                    b.ToTable("AspHistoryOfStatus");

                    b.HasData(
                        new
                        {
                            CurrentStatusId = 1,
                            DateOfChanges = new DateTime(2020, 12, 11, 14, 55, 36, 0, DateTimeKind.Unspecified),
                            HistoryOfStatusId = 1,
                            StatusId = 1,
                            Сomment = "Прийнято на розляд"
                        },
                        new
                        {
                            CurrentStatusId = 2,
                            DateOfChanges = new DateTime(2020, 12, 12, 10, 33, 24, 0, DateTimeKind.Unspecified),
                            HistoryOfStatusId = 1,
                            StatusId = 3,
                            Сomment = "Схвалено оскільки всі дані вірно вказані"
                        },
                        new
                        {
                            CurrentStatusId = 3,
                            DateOfChanges = new DateTime(2020, 12, 12, 11, 24, 48, 0, DateTimeKind.Unspecified),
                            HistoryOfStatusId = 2,
                            StatusId = 2,
                            Сomment = "Не вказано мети участі"
                        },
                        new
                        {
                            CurrentStatusId = 4,
                            DateOfChanges = new DateTime(2020, 12, 12, 12, 23, 33, 0, DateTimeKind.Unspecified),
                            HistoryOfStatusId = 1,
                            StatusId = 4,
                            Сomment = "Зареєстровано в системі"
                        });
                });

            modelBuilder.Entity("BusinessTrip.Models.ApplicationStatement", b =>
                {
                    b.Property<int>("StatementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BasisOfBusinessTrip")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("DateOfBusinessTrip")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfСompletionBusinessTrip")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("FileData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("InstitutionWhereYouGo")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("PaymentOfTravelExpenses")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("PositionAtTheMainPlaceOfWork")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PositionPartTime")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PurposeOfBusinessTrip")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("RouteOfBusinessTrip")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("StatementCountryOfDestination")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("StatementPlaceOfDestination")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("SubdivisionAtTheMainPlaceOfWork")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("SubdivisionPartTime")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("TransportOfBusinessTrip")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("TypeOfBusinessTrip")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("TypeOfSalaryRetention")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("UserLastNameGenitiveCase")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UserNameGenitiveCase")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UserSurNameGenitiveCase")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("StatementId");

                    b.ToTable("AspStatement");

                    b.HasData(
                        new
                        {
                            StatementId = 1,
                            BasisOfBusinessTrip = "Запрошення",
                            DateOfBusinessTrip = new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfСompletionBusinessTrip = new DateTime(2021, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InstitutionWhereYouGo = "Вроцлавський університет",
                            PaymentOfTravelExpenses = "За власний кошт/ за рахунок приймаючої сторони",
                            PositionAtTheMainPlaceOfWork = "Діловод",
                            PositionPartTime = "Архіваріус",
                            PurposeOfBusinessTrip = "З метою проходження стажування",
                            RouteOfBusinessTrip = "Львів-Вроцлав-Львів",
                            StatementCountryOfDestination = "Польща",
                            StatementPlaceOfDestination = "Вроцлав",
                            SubdivisionAtTheMainPlaceOfWork = "Архів Університету",
                            SubdivisionPartTime = "",
                            TransportOfBusinessTrip = "Залізничний",
                            TypeOfBusinessTrip = "Відрядження закордон",
                            TypeOfSalaryRetention = "Зі збереженням середньої зарплати за основним місце праці",
                            UserLastNameGenitiveCase = "Михайлівної",
                            UserNameGenitiveCase = "Галини",
                            UserSurNameGenitiveCase = "Хланти"
                        },
                        new
                        {
                            StatementId = 2,
                            BasisOfBusinessTrip = "Запрошення",
                            DateOfBusinessTrip = new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfСompletionBusinessTrip = new DateTime(2021, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InstitutionWhereYouGo = "Міністерство освіти і науки України ",
                            PaymentOfTravelExpenses = "За рахунок коштів університету",
                            PositionAtTheMainPlaceOfWork = "Старший інспектор",
                            PositionPartTime = "Інспектор з кадрів",
                            PurposeOfBusinessTrip = "",
                            RouteOfBusinessTrip = "Львів-Київ-Львів",
                            StatementCountryOfDestination = "Польща",
                            StatementPlaceOfDestination = "Київ",
                            SubdivisionAtTheMainPlaceOfWork = "Відділ кадрів",
                            SubdivisionPartTime = "",
                            TransportOfBusinessTrip = "Залізничний",
                            TypeOfBusinessTrip = "Відрядження по Україні",
                            TypeOfSalaryRetention = "Зі збереженням середньої зарплати за основним місцем праці та за сумісництвом",
                            UserLastNameGenitiveCase = "Романівної",
                            UserNameGenitiveCase = "Лідії",
                            UserSurNameGenitiveCase = "Яремчук"
                        });
                });

            modelBuilder.Entity("BusinessTrip.Models.ApplicationStatementFile", b =>
                {
                    b.Property<int?>("StatementId")
                        .HasColumnType("int");

                    b.Property<int?>("FileId")
                        .HasColumnType("int");

                    b.HasKey("StatementId", "FileId");

                    b.HasIndex("FileId");

                    b.ToTable("AspStatementFile");
                });

            modelBuilder.Entity("BusinessTrip.Models.ApplicationStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("StatusId");

                    b.ToTable("AspStatus");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            StatusName = "Прийнято на розляд"
                        },
                        new
                        {
                            StatusId = 2,
                            StatusName = "До опрацювання"
                        },
                        new
                        {
                            StatusId = 3,
                            StatusName = "Схвалено"
                        },
                        new
                        {
                            StatusId = 4,
                            StatusName = "Зареєстровано"
                        });
                });

            modelBuilder.Entity("BusinessTrip.Models.ApplicationUserStatement", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<int?>("StatementId")
                        .HasColumnType("int");

                    b.HasKey("Id", "StatementId");

                    b.HasIndex("StatementId");

                    b.ToTable("AspUserStatement");

                    b.HasData(
                        new
                        {
                            Id = "3",
                            StatementId = 1
                        },
                        new
                        {
                            Id = "4",
                            StatementId = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "fc698722-47c6-479c-8407-75fdd73beed2",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "28c78e7c-285c-439e-a13c-1be8c6b4bf6e",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8b1d23dc-da60-4c7e-a013-b04ff111d28d",
                            Email = "admin@admin.admin",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@admin.admin",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEPuixG8h4T6VZpra65SjFfsT7mbm2QUNEkpOCXD5skbRWLC54leMIXP45Dg3dotZ2A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c4d5b42e-c18e-410b-b66b-fa87cc65b604",
                            Email = "user@user.user",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "user@user.user",
                            NormalizedUserName = "USER",
                            PasswordHash = "AQAAAAEAACcQAAAAEOQofcP2Qfgq1EMC/4/ZooxNo0lTgMhwXFRlop2IB2PPbRbi9l3HUGfXUlJyNuIB7g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "User"
                        },
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e4f7cf24-bb5e-4720-a534-68d4fff964cd",
                            Email = "user2@user2.user2",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@USER2.USER2",
                            NormalizedUserName = "USER2",
                            PasswordHash = "AQAAAAEAACcQAAAAEDQpfRwBMVbSAWM7036QJefmPlbjg1eSMDQnQQDxmTDZArRUFrP0bTm0PLujP6b9Lw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "User2"
                        },
                        new
                        {
                            Id = "4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4cc2ca7e-72ac-41d0-bcbf-9d4c32556b89",
                            Email = "use32@user3.user3",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER3@USER3.USER3",
                            NormalizedUserName = "USER3",
                            PasswordHash = "AQAAAAEAACcQAAAAEMapmttLO7Wm02Cr+T8DHkfVq6sMjFAyGJ2DxZd5frf8NcvgW7/gqT6EbHIE/9DsSg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "User3"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "1",
                            RoleId = "1"
                        },
                        new
                        {
                            UserId = "2",
                            RoleId = "2"
                        },
                        new
                        {
                            UserId = "3",
                            RoleId = "2"
                        },
                        new
                        {
                            UserId = "4",
                            RoleId = "2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BusinessTrip.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("BusinessTrip.Models.ApplicationCurrentStatus", b =>
                {
                    b.HasOne("BusinessTrip.Models.ApplicationStatement", "Statement")
                        .WithMany("CurrentStatuses")
                        .HasForeignKey("StatementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessTrip.Models.ApplicationStatus", "Status")
                        .WithMany("CurrentStatuses")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BusinessTrip.Models.ApplicationHistoryOfStatus", b =>
                {
                    b.HasOne("BusinessTrip.Models.ApplicationStatement", "Statement")
                        .WithMany("HistoryOfStatuses")
                        .HasForeignKey("HistoryOfStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessTrip.Models.ApplicationStatus", "Status")
                        .WithMany("HistoryOfStatuses")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BusinessTrip.Models.ApplicationStatementFile", b =>
                {
                    b.HasOne("BusinessTrip.Models.ApplicationFile", "File")
                        .WithMany("StatementFiles")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessTrip.Models.ApplicationStatement", "Statement")
                        .WithMany("StatementFiles")
                        .HasForeignKey("StatementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BusinessTrip.Models.ApplicationUserStatement", b =>
                {
                    b.HasOne("BusinessTrip.Models.ApplicationUser", "User")
                        .WithMany("UserStatements")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessTrip.Models.ApplicationStatement", "Statement")
                        .WithMany("UserStatements")
                        .HasForeignKey("StatementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}