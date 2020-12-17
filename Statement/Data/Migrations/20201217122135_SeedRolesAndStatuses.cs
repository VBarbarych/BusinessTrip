using Microsoft.EntityFrameworkCore.Migrations;

namespace Statement.Data.Migrations
{
    public partial class SeedRolesAndStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "62f637dc-8d82-4ba2-b883-9dedb4c9d269", "Admin", "ADMIN" },
                    { "2", "adf794e7-a197-41a9-870c-df460fbffb3b", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspStatus",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[,]
                {
                    { 1, "Прийнято на розляд" },
                    { 2, "До опрацювання" },
                    { 3, "Схвалено" },
                    { 4, "Зареєстровано" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspStatus",
                keyColumn: "StatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspStatus",
                keyColumn: "StatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspStatus",
                keyColumn: "StatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspStatus",
                keyColumn: "StatusId",
                keyValue: 4);
        }
    }
}
