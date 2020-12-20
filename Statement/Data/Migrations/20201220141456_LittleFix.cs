using Microsoft.EntityFrameworkCore.Migrations;

namespace Statement.Data.Migrations
{
    public partial class LittleFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "fc698722-47c6-479c-8407-75fdd73beed2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "28c78e7c-285c-439e-a13c-1be8c6b4bf6e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b1d23dc-da60-4c7e-a013-b04ff111d28d", "AQAAAAEAACcQAAAAEPuixG8h4T6VZpra65SjFfsT7mbm2QUNEkpOCXD5skbRWLC54leMIXP45Dg3dotZ2A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "c4d5b42e-c18e-410b-b66b-fa87cc65b604", "USER", "AQAAAAEAACcQAAAAEOQofcP2Qfgq1EMC/4/ZooxNo0lTgMhwXFRlop2IB2PPbRbi9l3HUGfXUlJyNuIB7g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e4f7cf24-bb5e-4720-a534-68d4fff964cd", "AQAAAAEAACcQAAAAEDQpfRwBMVbSAWM7036QJefmPlbjg1eSMDQnQQDxmTDZArRUFrP0bTm0PLujP6b9Lw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4cc2ca7e-72ac-41d0-bcbf-9d4c32556b89", "AQAAAAEAACcQAAAAEMapmttLO7Wm02Cr+T8DHkfVq6sMjFAyGJ2DxZd5frf8NcvgW7/gqT6EbHIE/9DsSg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "dfe0fa83-e724-4754-aff8-54a411a597a2", "STAFF", "AQAAAAEAACcQAAAAEHARS/ggJ5sB4b4FWrH0zr2fNs4jkl98BsVgq2yA7DeZCrSl2JCWyCZ/+1LAyhGUFA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3b39a423-5814-4a7e-b78b-7a46bcfd7f3f", "AQAAAAEAACcQAAAAEMuIWrCXTFxSzTvHJU/p9simtV0ShkFpAf6qMlSbH5gvJlHuQMkBbt6hto/phr1KIA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "02cefce7-ef7a-428d-8469-01a0d08bcea0", "AQAAAAEAACcQAAAAEHjqPFus2MblwmXPGR4UReO0LcePZcTAOKFYPRNkTBebzZXm7FIkR1Jj7NRIDVrYHQ==" });
        }
    }
}
