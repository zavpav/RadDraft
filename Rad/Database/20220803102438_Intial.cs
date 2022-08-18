using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Rad.Database
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocRads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocNum = table.Column<string>(type: "text", nullable: false),
                    DocDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    LawNumber = table.Column<string>(type: "text", nullable: false),
                    LawDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BossFio = table.Column<string>(type: "text", nullable: false),
                    BossStat = table.Column<string>(type: "text", nullable: false),
                    ExecuterFio = table.Column<string>(type: "text", nullable: false),
                    ExecuterStat = table.Column<string>(type: "text", nullable: false),
                    ExecuterPhone = table.Column<string>(type: "text", nullable: false),
                    Descr = table.Column<string>(type: "text", nullable: false),
                    UserSid = table.Column<long>(type: "bigint", nullable: false),
                    Generation = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocRads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SprKbkIncomes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ToDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprKbkIncomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocRadRows",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RadId = table.Column<long>(type: "bigint", nullable: false),
                    KbkCode = table.Column<string>(type: "text", nullable: false),
                    OndateKbk = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TodateKbk = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AdbName = table.Column<string>(type: "text", nullable: false),
                    AdbInn = table.Column<string>(type: "text", nullable: false),
                    AdbKpp = table.Column<string>(type: "text", nullable: false),
                    LawLegalName = table.Column<string>(type: "text", nullable: false),
                    LawNumber = table.Column<string>(type: "text", nullable: false),
                    LawDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DocRadId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocRadRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocRadRows_DocRads_DocRadId",
                        column: x => x.DocRadId,
                        principalTable: "DocRads",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SprRads",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Inn = table.Column<string>(type: "text", nullable: false),
                    Kpp = table.Column<string>(type: "text", nullable: false),
                    Kbk = table.Column<string>(type: "text", nullable: false),
                    OnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ToDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SprKbkIncomeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprRads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SprRads_SprKbkIncomes_SprKbkIncomeId",
                        column: x => x.SprKbkIncomeId,
                        principalTable: "SprKbkIncomes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocRadRows_DocRadId",
                table: "DocRadRows",
                column: "DocRadId");

            migrationBuilder.CreateIndex(
                name: "IX_SprRads_SprKbkIncomeId",
                table: "SprRads",
                column: "SprKbkIncomeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocRadRows");

            migrationBuilder.DropTable(
                name: "SprRads");

            migrationBuilder.DropTable(
                name: "DocRads");

            migrationBuilder.DropTable(
                name: "SprKbkIncomes");
        }
    }
}
