using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Statement.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AspFile",
                columns: table => new
                {
                    FileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(maxLength: 256, nullable: false),
                    FileContentType = table.Column<string>(nullable: false),
                    FileData = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspFile", x => x.FileId);
                });

            migrationBuilder.CreateTable(
                name: "AspStatement",
                columns: table => new
                {
                    StatementId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNameGenitiveCase = table.Column<string>(maxLength: 100, nullable: false),
                    UserSurNameGenitiveCase = table.Column<string>(maxLength: 100, nullable: false),
                    UserLastNameGenitiveCase = table.Column<string>(maxLength: 100, nullable: false),
                    SubdivisionAtTheMainPlaceOfWork = table.Column<string>(maxLength: 200, nullable: false),
                    PositionAtTheMainPlaceOfWork = table.Column<string>(maxLength: 100, nullable: false),
                    SubdivisionPartTime = table.Column<string>(maxLength: 200, nullable: true),
                    PositionPartTime = table.Column<string>(maxLength: 100, nullable: true),
                    TypeOfBusinessTrip = table.Column<string>(maxLength: 50, nullable: false),
                    PurposeOfBusinessTrip = table.Column<string>(maxLength: 250, nullable: true),
                    TypeOfSalaryRetention = table.Column<string>(maxLength: 200, nullable: false),
                    StatementPlaceOfDestination = table.Column<string>(maxLength: 200, nullable: false),
                    StatementCountryOfDestination = table.Column<string>(maxLength: 200, nullable: true),
                    InstitutionWhereYouGo = table.Column<string>(maxLength: 300, nullable: false),
                    DateOfBusinessTrip = table.Column<DateTime>(nullable: false),
                    DateOfСompletionBusinessTrip = table.Column<DateTime>(nullable: false),
                    RouteOfBusinessTrip = table.Column<string>(maxLength: 200, nullable: true),
                    TransportOfBusinessTrip = table.Column<string>(maxLength: 200, nullable: true),
                    PaymentOfTravelExpenses = table.Column<string>(maxLength: 200, nullable: false),
                    BasisOfBusinessTrip = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspStatement", x => x.StatementId);
                });

            migrationBuilder.CreateTable(
                name: "AspStatus",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspStatus", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "AspStatementFile",
                columns: table => new
                {
                    StatementId = table.Column<int>(nullable: false),
                    FileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspStatementFile", x => new { x.StatementId, x.FileId });
                    table.ForeignKey(
                        name: "FK_AspStatementFile_AspFile_FileId",
                        column: x => x.FileId,
                        principalTable: "AspFile",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspStatementFile_AspStatement_StatementId",
                        column: x => x.StatementId,
                        principalTable: "AspStatement",
                        principalColumn: "StatementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspUserStatement",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 450, nullable: false),
                    StatementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspUserStatement", x => new { x.Id, x.StatementId });
                    table.ForeignKey(
                        name: "FK_AspUserStatement_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspUserStatement_AspStatement_StatementId",
                        column: x => x.StatementId,
                        principalTable: "AspStatement",
                        principalColumn: "StatementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspCurrentStatus",
                columns: table => new
                {
                    CurrentStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatementId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    DateOfLastChanges = table.Column<DateTime>(nullable: false),
                    CurrentСomment = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspCurrentStatus", x => x.CurrentStatusId);
                    table.ForeignKey(
                        name: "FK_AspCurrentStatus_AspStatement_StatementId",
                        column: x => x.StatementId,
                        principalTable: "AspStatement",
                        principalColumn: "StatementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspCurrentStatus_AspStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "AspStatus",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspHistoryOfStatus",
                columns: table => new
                {
                    CurrentStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoryOfStatusId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    DateOfChanges = table.Column<DateTime>(nullable: false),
                    Сomment = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspHistoryOfStatus", x => x.CurrentStatusId);
                    table.ForeignKey(
                        name: "FK_AspHistoryOfStatus_AspStatement_HistoryOfStatusId",
                        column: x => x.HistoryOfStatusId,
                        principalTable: "AspStatement",
                        principalColumn: "StatementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspHistoryOfStatus_AspStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "AspStatus",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspCurrentStatus_StatementId",
                table: "AspCurrentStatus",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_AspCurrentStatus_StatusId",
                table: "AspCurrentStatus",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AspHistoryOfStatus_HistoryOfStatusId",
                table: "AspHistoryOfStatus",
                column: "HistoryOfStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AspHistoryOfStatus_StatusId",
                table: "AspHistoryOfStatus",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AspStatementFile_FileId",
                table: "AspStatementFile",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_AspUserStatement_StatementId",
                table: "AspUserStatement",
                column: "StatementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspCurrentStatus");

            migrationBuilder.DropTable(
                name: "AspHistoryOfStatus");

            migrationBuilder.DropTable(
                name: "AspStatementFile");

            migrationBuilder.DropTable(
                name: "AspUserStatement");

            migrationBuilder.DropTable(
                name: "AspStatus");

            migrationBuilder.DropTable(
                name: "AspFile");

            migrationBuilder.DropTable(
                name: "AspStatement");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
