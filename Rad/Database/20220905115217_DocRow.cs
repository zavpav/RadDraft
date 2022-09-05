using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rad.Database
{
    public partial class DocRow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproveDt",
                table: "KuDetailRows");

            migrationBuilder.DropColumn(
                name: "BrSid",
                table: "KuDetailRows");

            migrationBuilder.DropColumn(
                name: "Descr",
                table: "KuDetailRows");

            migrationBuilder.DropColumn(
                name: "DocNum",
                table: "KuDetailRows");

            migrationBuilder.DropColumn(
                name: "DocStatus",
                table: "KuDetailRows");

            migrationBuilder.DropColumn(
                name: "DocStatusName",
                table: "KuDetailRows");

            migrationBuilder.DropColumn(
                name: "IsFirstDistribution",
                table: "KuDetailRows");

            migrationBuilder.DropColumn(
                name: "OrgSid",
                table: "KuDetailRows");

            migrationBuilder.DropColumn(
                name: "TopFullSprKey",
                table: "KuDetailRows");

            migrationBuilder.RenameColumn(
                name: "UserSid",
                table: "KuDetailRows",
                newName: "Generation");

            migrationBuilder.RenameColumn(
                name: "TopBrRowSid",
                table: "KuDetailRows",
                newName: "DocId");

            migrationBuilder.RenameColumn(
                name: "CreateDt",
                table: "KuDetailRows",
                newName: "SysChangeDate");

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "KuDetailRows",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SmBa1",
                table: "KuDetailRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SmBa2",
                table: "KuDetailRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SmBa3",
                table: "KuDetailRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SmLbo1",
                table: "KuDetailRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SmLbo2",
                table: "KuDetailRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SmLbo3",
                table: "KuDetailRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SmPof",
                table: "KuDetailRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_KuDetailRows_DocId",
                table: "KuDetailRows",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_KuDetailRows_ParentId",
                table: "KuDetailRows",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_KuDetailRows_KuDetailRows_ParentId",
                table: "KuDetailRows",
                column: "ParentId",
                principalTable: "KuDetailRows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KuDetailRows_KuDetails_DocId",
                table: "KuDetailRows",
                column: "DocId",
                principalTable: "KuDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KuDetailRows_KuDetailRows_ParentId",
                table: "KuDetailRows");

            migrationBuilder.DropForeignKey(
                name: "FK_KuDetailRows_KuDetails_DocId",
                table: "KuDetailRows");

            migrationBuilder.DropIndex(
                name: "IX_KuDetailRows_DocId",
                table: "KuDetailRows");

            migrationBuilder.DropIndex(
                name: "IX_KuDetailRows_ParentId",
                table: "KuDetailRows");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "KuDetailRows");

            migrationBuilder.DropColumn(
                name: "SmBa1",
                table: "KuDetailRows");

            migrationBuilder.DropColumn(
                name: "SmBa2",
                table: "KuDetailRows");

            migrationBuilder.DropColumn(
                name: "SmBa3",
                table: "KuDetailRows");

            migrationBuilder.DropColumn(
                name: "SmLbo1",
                table: "KuDetailRows");

            migrationBuilder.DropColumn(
                name: "SmLbo2",
                table: "KuDetailRows");

            migrationBuilder.DropColumn(
                name: "SmLbo3",
                table: "KuDetailRows");

            migrationBuilder.DropColumn(
                name: "SmPof",
                table: "KuDetailRows");

            migrationBuilder.RenameColumn(
                name: "SysChangeDate",
                table: "KuDetailRows",
                newName: "CreateDt");

            migrationBuilder.RenameColumn(
                name: "Generation",
                table: "KuDetailRows",
                newName: "UserSid");

            migrationBuilder.RenameColumn(
                name: "DocId",
                table: "KuDetailRows",
                newName: "TopBrRowSid");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApproveDt",
                table: "KuDetailRows",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BrSid",
                table: "KuDetailRows",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Descr",
                table: "KuDetailRows",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocNum",
                table: "KuDetailRows",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocStatus",
                table: "KuDetailRows",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocStatusName",
                table: "KuDetailRows",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsFirstDistribution",
                table: "KuDetailRows",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "OrgSid",
                table: "KuDetailRows",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "TopFullSprKey",
                table: "KuDetailRows",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
