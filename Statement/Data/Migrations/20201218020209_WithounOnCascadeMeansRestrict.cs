using Microsoft.EntityFrameworkCore.Migrations;

namespace Statement.Data.Migrations
{
    public partial class WithounOnCascadeMeansRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspCurrentStatus_AspStatement_StatementId",
                table: "AspCurrentStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_AspCurrentStatus_AspStatus_StatusId",
                table: "AspCurrentStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_AspHistoryOfStatus_AspStatement_HistoryOfStatusId",
                table: "AspHistoryOfStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_AspHistoryOfStatus_AspStatus_StatusId",
                table: "AspHistoryOfStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_AspStatementFile_AspFile_FileId",
                table: "AspStatementFile");

            migrationBuilder.DropForeignKey(
                name: "FK_AspStatementFile_AspStatement_StatementId",
                table: "AspStatementFile");

            migrationBuilder.DropForeignKey(
                name: "FK_AspUserStatement_AspNetUsers_Id",
                table: "AspUserStatement");

            migrationBuilder.DropForeignKey(
                name: "FK_AspUserStatement_AspStatement_StatementId",
                table: "AspUserStatement");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6d64c3db-ad90-4f3b-b92e-dac476b7771f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "22f9e1b0-397f-4e92-a91e-1f9f73ef78ab");

            migrationBuilder.AddForeignKey(
                name: "FK_AspCurrentStatus_AspStatement_StatementId",
                table: "AspCurrentStatus",
                column: "StatementId",
                principalTable: "AspStatement",
                principalColumn: "StatementId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspCurrentStatus_AspStatus_StatusId",
                table: "AspCurrentStatus",
                column: "StatusId",
                principalTable: "AspStatus",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspHistoryOfStatus_AspStatement_HistoryOfStatusId",
                table: "AspHistoryOfStatus",
                column: "HistoryOfStatusId",
                principalTable: "AspStatement",
                principalColumn: "StatementId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspHistoryOfStatus_AspStatus_StatusId",
                table: "AspHistoryOfStatus",
                column: "StatusId",
                principalTable: "AspStatus",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspStatementFile_AspFile_FileId",
                table: "AspStatementFile",
                column: "FileId",
                principalTable: "AspFile",
                principalColumn: "FileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspStatementFile_AspStatement_StatementId",
                table: "AspStatementFile",
                column: "StatementId",
                principalTable: "AspStatement",
                principalColumn: "StatementId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspUserStatement_AspNetUsers_Id",
                table: "AspUserStatement",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspUserStatement_AspStatement_StatementId",
                table: "AspUserStatement",
                column: "StatementId",
                principalTable: "AspStatement",
                principalColumn: "StatementId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspCurrentStatus_AspStatement_StatementId",
                table: "AspCurrentStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_AspCurrentStatus_AspStatus_StatusId",
                table: "AspCurrentStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_AspHistoryOfStatus_AspStatement_HistoryOfStatusId",
                table: "AspHistoryOfStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_AspHistoryOfStatus_AspStatus_StatusId",
                table: "AspHistoryOfStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_AspStatementFile_AspFile_FileId",
                table: "AspStatementFile");

            migrationBuilder.DropForeignKey(
                name: "FK_AspStatementFile_AspStatement_StatementId",
                table: "AspStatementFile");

            migrationBuilder.DropForeignKey(
                name: "FK_AspUserStatement_AspNetUsers_Id",
                table: "AspUserStatement");

            migrationBuilder.DropForeignKey(
                name: "FK_AspUserStatement_AspStatement_StatementId",
                table: "AspUserStatement");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "62f637dc-8d82-4ba2-b883-9dedb4c9d269");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "adf794e7-a197-41a9-870c-df460fbffb3b");

            migrationBuilder.AddForeignKey(
                name: "FK_AspCurrentStatus_AspStatement_StatementId",
                table: "AspCurrentStatus",
                column: "StatementId",
                principalTable: "AspStatement",
                principalColumn: "StatementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspCurrentStatus_AspStatus_StatusId",
                table: "AspCurrentStatus",
                column: "StatusId",
                principalTable: "AspStatus",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspHistoryOfStatus_AspStatement_HistoryOfStatusId",
                table: "AspHistoryOfStatus",
                column: "HistoryOfStatusId",
                principalTable: "AspStatement",
                principalColumn: "StatementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspHistoryOfStatus_AspStatus_StatusId",
                table: "AspHistoryOfStatus",
                column: "StatusId",
                principalTable: "AspStatus",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspStatementFile_AspFile_FileId",
                table: "AspStatementFile",
                column: "FileId",
                principalTable: "AspFile",
                principalColumn: "FileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspStatementFile_AspStatement_StatementId",
                table: "AspStatementFile",
                column: "StatementId",
                principalTable: "AspStatement",
                principalColumn: "StatementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspUserStatement_AspNetUsers_Id",
                table: "AspUserStatement",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspUserStatement_AspStatement_StatementId",
                table: "AspUserStatement",
                column: "StatementId",
                principalTable: "AspStatement",
                principalColumn: "StatementId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
