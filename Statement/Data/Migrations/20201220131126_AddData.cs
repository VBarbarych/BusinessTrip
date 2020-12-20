using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Statement.Data.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "1bc8dfbe-7adc-42c6-8c87-342c2ee52268");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "1d0506e2-c663-4dfd-b962-fd8c54084ce0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e46009be-622a-4551-8edf-f6889efd349a", "AQAAAAEAACcQAAAAEOtKCvMdHNuab0N84F47TeuDsDlAL2Q2AYGCusd8OsEZ658INeHOhN0CTHyaUUH/Uw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dfe0fa83-e724-4754-aff8-54a411a597a2", "AQAAAAEAACcQAAAAEHARS/ggJ5sB4b4FWrH0zr2fNs4jkl98BsVgq2yA7DeZCrSl2JCWyCZ/+1LAyhGUFA==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3", 0, "3b39a423-5814-4a7e-b78b-7a46bcfd7f3f", "IdentityUser", "user2@user2.user2", true, false, null, "USER2@USER2.USER2", "USER2", "AQAAAAEAACcQAAAAEMuIWrCXTFxSzTvHJU/p9simtV0ShkFpAf6qMlSbH5gvJlHuQMkBbt6hto/phr1KIA==", null, false, "", false, "User2" },
                    { "4", 0, "02cefce7-ef7a-428d-8469-01a0d08bcea0", "IdentityUser", "use32@user3.user3", true, false, null, "USER3@USER3.USER3", "USER3", "AQAAAAEAACcQAAAAEHjqPFus2MblwmXPGR4UReO0LcePZcTAOKFYPRNkTBebzZXm7FIkR1Jj7NRIDVrYHQ==", null, false, "", false, "User3" }
                });

            migrationBuilder.InsertData(
                table: "AspStatement",
                columns: new[] { "StatementId", "BasisOfBusinessTrip", "DateOfBusinessTrip", "DateOfСompletionBusinessTrip", "FileData", "InstitutionWhereYouGo", "PaymentOfTravelExpenses", "PositionAtTheMainPlaceOfWork", "PositionPartTime", "PurposeOfBusinessTrip", "RouteOfBusinessTrip", "StatementCountryOfDestination", "StatementPlaceOfDestination", "SubdivisionAtTheMainPlaceOfWork", "SubdivisionPartTime", "TransportOfBusinessTrip", "TypeOfBusinessTrip", "TypeOfSalaryRetention", "UserLastNameGenitiveCase", "UserNameGenitiveCase", "UserSurNameGenitiveCase" },
                values: new object[,]
                {
                    { 1, "Запрошення", new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Вроцлавський університет", "За власний кошт/ за рахунок приймаючої сторони", "Діловод", "Архіваріус", "З метою проходження стажування", "Львів-Вроцлав-Львів", "Польща", "Вроцлав", "Архів Університету", "", "Залізничний", "Відрядження закордон", "Зі збереженням середньої зарплати за основним місце праці", "Михайлівної", "Галини", "Хланти" },
                    { 2, "Запрошення", new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Міністерство освіти і науки України ", "За рахунок коштів університету", "Старший інспектор", "Інспектор з кадрів", "", "Львів-Київ-Львів", "Польща", "Київ", "Відділ кадрів", "", "Залізничний", "Відрядження по Україні", "Зі збереженням середньої зарплати за основним місцем праці та за сумісництвом", "Романівної", "Лідії", "Яремчук" }
                });

            migrationBuilder.InsertData(
                table: "AspCurrentStatus",
                columns: new[] { "CurrentStatusId", "CurrentСomment", "DateOfLastChanges", "StatementId", "StatusId" },
                values: new object[,]
                {
                    { 1, "Всі дані вказано.", new DateTime(2020, 12, 12, 12, 23, 33, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 2, "Не вказано мети участі.", new DateTime(2020, 12, 18, 10, 7, 14, 0, DateTimeKind.Unspecified), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "AspHistoryOfStatus",
                columns: new[] { "CurrentStatusId", "DateOfChanges", "HistoryOfStatusId", "StatusId", "Сomment" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 11, 14, 55, 36, 0, DateTimeKind.Unspecified), 1, 1, "Прийнято на розляд" },
                    { 2, new DateTime(2020, 12, 12, 10, 33, 24, 0, DateTimeKind.Unspecified), 1, 3, "Схвалено оскільки всі дані вірно вказані" },
                    { 4, new DateTime(2020, 12, 12, 12, 23, 33, 0, DateTimeKind.Unspecified), 1, 4, "Зареєстровано в системі" },
                    { 3, new DateTime(2020, 12, 12, 11, 24, 48, 0, DateTimeKind.Unspecified), 2, 2, "Не вказано мети участі" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "3", "2" },
                    { "4", "2" }
                });

            migrationBuilder.InsertData(
                table: "AspUserStatement",
                columns: new[] { "Id", "StatementId" },
                values: new object[,]
                {
                    { "3", 1 },
                    { "4", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspCurrentStatus",
                keyColumn: "CurrentStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspCurrentStatus",
                keyColumn: "CurrentStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspHistoryOfStatus",
                keyColumn: "CurrentStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspHistoryOfStatus",
                keyColumn: "CurrentStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspHistoryOfStatus",
                keyColumn: "CurrentStatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspHistoryOfStatus",
                keyColumn: "CurrentStatusId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "4", "2" });

            migrationBuilder.DeleteData(
                table: "AspUserStatement",
                keyColumns: new[] { "Id", "StatementId" },
                keyValues: new object[] { "3", 1 });

            migrationBuilder.DeleteData(
                table: "AspUserStatement",
                keyColumns: new[] { "Id", "StatementId" },
                keyValues: new object[] { "4", 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "AspStatement",
                keyColumn: "StatementId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspStatement",
                keyColumn: "StatementId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "7e1aacc3-da33-4289-b030-3711e55ecf1d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "aaca14a9-0369-499c-8bd2-51850af364e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "263c2ac8-2207-4359-94ce-55bed967ce21", "AQAAAAEAACcQAAAAECIrtbWfHBg3b9cG/mrgBPLEojIaIX+y5qkgesz0l5Xwk2xj9KFM5jGxHAEGwGCjPA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d75451ea-9a57-4027-aeb6-4ccbb9a26b9d", "AQAAAAEAACcQAAAAEHH5K6GIhO1hFmmwUEWOQsxWMVXXw5OWKM0L7GZzd3yXdTA+g9kwRRN533I13q/zkg==" });
        }
    }
}
