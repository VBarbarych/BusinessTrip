using Microsoft.EntityFrameworkCore.Migrations;

namespace Statement.Data.Migrations
{
    public partial class AddDefaultRolesAndUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "7e1aacc3-da33-4289-b030-3711e55ecf1d", "Admin", "ADMIN" },
                    { "2", "aaca14a9-0369-499c-8bd2-51850af364e2", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "263c2ac8-2207-4359-94ce-55bed967ce21", "IdentityUser", "admin@admin.admin", true, false, null, "admin@admin.admin", "ADMIN", "AQAAAAEAACcQAAAAECIrtbWfHBg3b9cG/mrgBPLEojIaIX+y5qkgesz0l5Xwk2xj9KFM5jGxHAEGwGCjPA==", null, false, "", false, "Admin" },
                    { "2", 0, "d75451ea-9a57-4027-aeb6-4ccbb9a26b9d", "IdentityUser", "user@user.user", true, false, null, "user@user.user", "STAFF", "AQAAAAEAACcQAAAAEHH5K6GIhO1hFmmwUEWOQsxWMVXXw5OWKM0L7GZzd3yXdTA+g9kwRRN533I13q/zkg==", null, false, "", false, "User" }
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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "1", "1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "2", "2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2", "2" });

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

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");
        }
    }
}
