using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rad.Database
{
    public partial class DocRow2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullSprKey",
                table: "KuDetailRows",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StructRowId",
                table: "KuDetailRows",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullSprKey",
                table: "KuDetailRows");

            migrationBuilder.DropColumn(
                name: "StructRowId",
                table: "KuDetailRows");
        }
    }
}
