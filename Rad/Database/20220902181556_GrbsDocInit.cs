using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Rad.Database
{
    public partial class GrbsDocInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KuDetailRows",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocNum = table.Column<string>(type: "text", nullable: false),
                    ApproveDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DocStatus = table.Column<string>(type: "text", nullable: false),
                    DocStatusName = table.Column<string>(type: "text", nullable: false),
                    Descr = table.Column<string>(type: "text", nullable: false),
                    UserSid = table.Column<long>(type: "bigint", nullable: false),
                    OrgSid = table.Column<long>(type: "bigint", nullable: false),
                    BrSid = table.Column<long>(type: "bigint", nullable: false),
                    TopBrRowSid = table.Column<long>(type: "bigint", nullable: false),
                    TopFullSprKey = table.Column<string>(type: "text", nullable: false),
                    IsFirstDistribution = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KuDetailRows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KuDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocNum = table.Column<string>(type: "text", nullable: false),
                    ApproveDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DocStatus = table.Column<string>(type: "text", nullable: false),
                    DocStatusName = table.Column<string>(type: "text", nullable: false),
                    Descr = table.Column<string>(type: "text", nullable: false),
                    UserSid = table.Column<long>(type: "bigint", nullable: false),
                    OrgSid = table.Column<long>(type: "bigint", nullable: false),
                    BrSid = table.Column<long>(type: "bigint", nullable: false),
                    TopBrRowSid = table.Column<long>(type: "bigint", nullable: false),
                    TopFullSprKey = table.Column<string>(type: "text", nullable: false),
                    IsFirstDistribution = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KuDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToPbs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocNum = table.Column<string>(type: "text", nullable: false),
                    ApproveDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DocStatus = table.Column<string>(type: "text", nullable: false),
                    DocStatusName = table.Column<string>(type: "text", nullable: false),
                    Descr = table.Column<string>(type: "text", nullable: false),
                    UserSid = table.Column<long>(type: "bigint", nullable: false),
                    OrgSid = table.Column<long>(type: "bigint", nullable: false),
                    BrSid = table.Column<long>(type: "bigint", nullable: false),
                    TopBrRowSid = table.Column<long>(type: "bigint", nullable: false),
                    TopFullSprKey = table.Column<string>(type: "text", nullable: false),
                    IsFirstDistribution = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToPbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToPbsRows",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocNum = table.Column<string>(type: "text", nullable: false),
                    ApproveDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DocStatus = table.Column<string>(type: "text", nullable: false),
                    DocStatusName = table.Column<string>(type: "text", nullable: false),
                    Descr = table.Column<string>(type: "text", nullable: false),
                    UserSid = table.Column<long>(type: "bigint", nullable: false),
                    OrgSid = table.Column<long>(type: "bigint", nullable: false),
                    BrSid = table.Column<long>(type: "bigint", nullable: false),
                    TopBrRowSid = table.Column<long>(type: "bigint", nullable: false),
                    TopFullSprKey = table.Column<string>(type: "text", nullable: false),
                    IsFirstDistribution = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToPbsRows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToRezerv",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocNum = table.Column<string>(type: "text", nullable: false),
                    ApproveDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DocStatus = table.Column<string>(type: "text", nullable: false),
                    DocStatusName = table.Column<string>(type: "text", nullable: false),
                    Descr = table.Column<string>(type: "text", nullable: false),
                    UserSid = table.Column<long>(type: "bigint", nullable: false),
                    OrgSid = table.Column<long>(type: "bigint", nullable: false),
                    BrSid = table.Column<long>(type: "bigint", nullable: false),
                    TopBrRowSid = table.Column<long>(type: "bigint", nullable: false),
                    TopFullSprKey = table.Column<string>(type: "text", nullable: false),
                    IsFirstDistribution = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToRezerv", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToRezervRows",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocNum = table.Column<string>(type: "text", nullable: false),
                    ApproveDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreateDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DocStatus = table.Column<string>(type: "text", nullable: false),
                    DocStatusName = table.Column<string>(type: "text", nullable: false),
                    Descr = table.Column<string>(type: "text", nullable: false),
                    UserSid = table.Column<long>(type: "bigint", nullable: false),
                    OrgSid = table.Column<long>(type: "bigint", nullable: false),
                    BrSid = table.Column<long>(type: "bigint", nullable: false),
                    TopBrRowSid = table.Column<long>(type: "bigint", nullable: false),
                    TopFullSprKey = table.Column<string>(type: "text", nullable: false),
                    IsFirstDistribution = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToRezervRows", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KuDetailRows");

            migrationBuilder.DropTable(
                name: "KuDetails");

            migrationBuilder.DropTable(
                name: "ToPbs");

            migrationBuilder.DropTable(
                name: "ToPbsRows");

            migrationBuilder.DropTable(
                name: "ToRezerv");

            migrationBuilder.DropTable(
                name: "ToRezervRows");
        }
    }
}
