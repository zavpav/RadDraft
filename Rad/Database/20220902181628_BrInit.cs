using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Rad.Database
{
    public partial class BrInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrType = table.Column<int>(type: "integer", nullable: false),
                    OrgSid = table.Column<long>(type: "bigint", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StructRows",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrId = table.Column<long>(type: "bigint", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    ParentRowId = table.Column<long>(type: "bigint", nullable: true),
                    SprId = table.Column<long>(type: "bigint", nullable: false),
                    OnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ToDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SysChangeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    XmlInfo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StructRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StructRows_StructRows_ParentRowId",
                        column: x => x.ParentRowId,
                        principalTable: "StructRows",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BrSumRows",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrId = table.Column<long>(type: "bigint", nullable: false),
                    StructRowId = table.Column<long>(type: "bigint", nullable: false),
                    OrderBy = table.Column<int>(type: "integer", nullable: false),
                    DocumentId = table.Column<long>(type: "bigint", nullable: false),
                    XmlInfo = table.Column<string>(type: "text", nullable: true),
                    SmBa1 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmBa2 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmBa3 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmLbo1 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmLbo2 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmLbo3 = table.Column<decimal>(type: "numeric", nullable: false),
                    SmPof = table.Column<decimal>(type: "numeric", nullable: false),
                    SysChangeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Generation = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrSumRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrSumRows_Brs_BrId",
                        column: x => x.BrId,
                        principalTable: "Brs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrSumRows_StructRows_StructRowId",
                        column: x => x.StructRowId,
                        principalTable: "StructRows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrSumRows_BrId",
                table: "BrSumRows",
                column: "BrId");

            migrationBuilder.CreateIndex(
                name: "IX_BrSumRows_StructRowId",
                table: "BrSumRows",
                column: "StructRowId");

            migrationBuilder.CreateIndex(
                name: "IX_StructRows_ParentRowId",
                table: "StructRows",
                column: "ParentRowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrSumRows");

            migrationBuilder.DropTable(
                name: "Brs");

            migrationBuilder.DropTable(
                name: "StructRows");
        }
    }
}
