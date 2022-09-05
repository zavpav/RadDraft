using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rad.Database
{
    public partial class BrFsk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullSprKey",
                table: "StructRows",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_StructRows_BrId",
                table: "StructRows",
                column: "BrId");

            migrationBuilder.AddForeignKey(
                name: "FK_StructRows_Brs_BrId",
                table: "StructRows",
                column: "BrId",
                principalTable: "Brs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StructRows_Brs_BrId",
                table: "StructRows");

            migrationBuilder.DropIndex(
                name: "IX_StructRows_BrId",
                table: "StructRows");

            migrationBuilder.DropColumn(
                name: "FullSprKey",
                table: "StructRows");
        }
    }
}
