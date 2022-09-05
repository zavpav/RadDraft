using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rad.Database
{
    public partial class BrHst1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "StructRows");

            migrationBuilder.AlterColumn<int>(
                name: "OrderBy",
                table: "BrSumRows",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApproveDate",
                table: "BrSumRows",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproveDate",
                table: "BrSumRows");

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "StructRows",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "OrderBy",
                table: "BrSumRows",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
