using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rad.Database
{
    public partial class DocRow4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproveDt",
                table: "ToRezervRows");

            migrationBuilder.DropColumn(
                name: "BrSid",
                table: "ToRezervRows");

            migrationBuilder.DropColumn(
                name: "Descr",
                table: "ToRezervRows");

            migrationBuilder.DropColumn(
                name: "DocNum",
                table: "ToRezervRows");

            migrationBuilder.DropColumn(
                name: "DocStatus",
                table: "ToRezervRows");

            migrationBuilder.DropColumn(
                name: "DocStatusName",
                table: "ToRezervRows");

            migrationBuilder.DropColumn(
                name: "IsFirstDistribution",
                table: "ToRezervRows");

            migrationBuilder.DropColumn(
                name: "TopFullSprKey",
                table: "ToRezervRows");

            migrationBuilder.DropColumn(
                name: "ApproveDt",
                table: "ToPbsRows");

            migrationBuilder.DropColumn(
                name: "BrSid",
                table: "ToPbsRows");

            migrationBuilder.DropColumn(
                name: "Descr",
                table: "ToPbsRows");

            migrationBuilder.DropColumn(
                name: "DocNum",
                table: "ToPbsRows");

            migrationBuilder.DropColumn(
                name: "DocStatus",
                table: "ToPbsRows");

            migrationBuilder.DropColumn(
                name: "DocStatusName",
                table: "ToPbsRows");

            migrationBuilder.DropColumn(
                name: "IsFirstDistribution",
                table: "ToPbsRows");

            migrationBuilder.DropColumn(
                name: "TopFullSprKey",
                table: "ToPbsRows");

            migrationBuilder.RenameColumn(
                name: "UserSid",
                table: "ToRezervRows",
                newName: "SprId");

            migrationBuilder.RenameColumn(
                name: "TopBrRowSid",
                table: "ToRezervRows",
                newName: "Generation");

            migrationBuilder.RenameColumn(
                name: "OrgSid",
                table: "ToRezervRows",
                newName: "DocId");

            migrationBuilder.RenameColumn(
                name: "CreateDt",
                table: "ToRezervRows",
                newName: "SysChangeDate");

            migrationBuilder.RenameColumn(
                name: "UserSid",
                table: "ToPbsRows",
                newName: "SprId");

            migrationBuilder.RenameColumn(
                name: "TopBrRowSid",
                table: "ToPbsRows",
                newName: "Generation");

            migrationBuilder.RenameColumn(
                name: "OrgSid",
                table: "ToPbsRows",
                newName: "DocId");

            migrationBuilder.RenameColumn(
                name: "CreateDt",
                table: "ToPbsRows",
                newName: "SysChangeDate");

            migrationBuilder.AddColumn<string>(
                name: "FullSprKey",
                table: "ToRezervRows",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "ToRezervRows",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SmBa1",
                table: "ToRezervRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SmBa2",
                table: "ToRezervRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SmBa3",
                table: "ToRezervRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SmLbo1",
                table: "ToRezervRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SmLbo2",
                table: "ToRezervRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SmLbo3",
                table: "ToRezervRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SmPof",
                table: "ToRezervRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "StructRowId",
                table: "ToRezervRows",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullSprKey",
                table: "ToPbsRows",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "ToPbsRows",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SmBa1",
                table: "ToPbsRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SmBa2",
                table: "ToPbsRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SmBa3",
                table: "ToPbsRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SmLbo1",
                table: "ToPbsRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SmLbo2",
                table: "ToPbsRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SmLbo3",
                table: "ToPbsRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SmPof",
                table: "ToPbsRows",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "StructRowId",
                table: "ToPbsRows",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToRezervRows_DocId",
                table: "ToRezervRows",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_ToRezervRows_ParentId",
                table: "ToRezervRows",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ToPbsRows_DocId",
                table: "ToPbsRows",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_ToPbsRows_ParentId",
                table: "ToPbsRows",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToPbsRows_ToPbs_DocId",
                table: "ToPbsRows",
                column: "DocId",
                principalTable: "ToPbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToPbsRows_ToPbsRows_ParentId",
                table: "ToPbsRows",
                column: "ParentId",
                principalTable: "ToPbsRows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToRezervRows_ToRezerv_DocId",
                table: "ToRezervRows",
                column: "DocId",
                principalTable: "ToRezerv",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToRezervRows_ToRezervRows_ParentId",
                table: "ToRezervRows",
                column: "ParentId",
                principalTable: "ToRezervRows",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToPbsRows_ToPbs_DocId",
                table: "ToPbsRows");

            migrationBuilder.DropForeignKey(
                name: "FK_ToPbsRows_ToPbsRows_ParentId",
                table: "ToPbsRows");

            migrationBuilder.DropForeignKey(
                name: "FK_ToRezervRows_ToRezerv_DocId",
                table: "ToRezervRows");

            migrationBuilder.DropForeignKey(
                name: "FK_ToRezervRows_ToRezervRows_ParentId",
                table: "ToRezervRows");

            migrationBuilder.DropIndex(
                name: "IX_ToRezervRows_DocId",
                table: "ToRezervRows");

            migrationBuilder.DropIndex(
                name: "IX_ToRezervRows_ParentId",
                table: "ToRezervRows");

            migrationBuilder.DropIndex(
                name: "IX_ToPbsRows_DocId",
                table: "ToPbsRows");

            migrationBuilder.DropIndex(
                name: "IX_ToPbsRows_ParentId",
                table: "ToPbsRows");

            migrationBuilder.DropColumn(
                name: "FullSprKey",
                table: "ToRezervRows");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ToRezervRows");

            migrationBuilder.DropColumn(
                name: "SmBa1",
                table: "ToRezervRows");

            migrationBuilder.DropColumn(
                name: "SmBa2",
                table: "ToRezervRows");

            migrationBuilder.DropColumn(
                name: "SmBa3",
                table: "ToRezervRows");

            migrationBuilder.DropColumn(
                name: "SmLbo1",
                table: "ToRezervRows");

            migrationBuilder.DropColumn(
                name: "SmLbo2",
                table: "ToRezervRows");

            migrationBuilder.DropColumn(
                name: "SmLbo3",
                table: "ToRezervRows");

            migrationBuilder.DropColumn(
                name: "SmPof",
                table: "ToRezervRows");

            migrationBuilder.DropColumn(
                name: "StructRowId",
                table: "ToRezervRows");

            migrationBuilder.DropColumn(
                name: "FullSprKey",
                table: "ToPbsRows");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ToPbsRows");

            migrationBuilder.DropColumn(
                name: "SmBa1",
                table: "ToPbsRows");

            migrationBuilder.DropColumn(
                name: "SmBa2",
                table: "ToPbsRows");

            migrationBuilder.DropColumn(
                name: "SmBa3",
                table: "ToPbsRows");

            migrationBuilder.DropColumn(
                name: "SmLbo1",
                table: "ToPbsRows");

            migrationBuilder.DropColumn(
                name: "SmLbo2",
                table: "ToPbsRows");

            migrationBuilder.DropColumn(
                name: "SmLbo3",
                table: "ToPbsRows");

            migrationBuilder.DropColumn(
                name: "SmPof",
                table: "ToPbsRows");

            migrationBuilder.DropColumn(
                name: "StructRowId",
                table: "ToPbsRows");

            migrationBuilder.RenameColumn(
                name: "SysChangeDate",
                table: "ToRezervRows",
                newName: "CreateDt");

            migrationBuilder.RenameColumn(
                name: "SprId",
                table: "ToRezervRows",
                newName: "UserSid");

            migrationBuilder.RenameColumn(
                name: "Generation",
                table: "ToRezervRows",
                newName: "TopBrRowSid");

            migrationBuilder.RenameColumn(
                name: "DocId",
                table: "ToRezervRows",
                newName: "OrgSid");

            migrationBuilder.RenameColumn(
                name: "SysChangeDate",
                table: "ToPbsRows",
                newName: "CreateDt");

            migrationBuilder.RenameColumn(
                name: "SprId",
                table: "ToPbsRows",
                newName: "UserSid");

            migrationBuilder.RenameColumn(
                name: "Generation",
                table: "ToPbsRows",
                newName: "TopBrRowSid");

            migrationBuilder.RenameColumn(
                name: "DocId",
                table: "ToPbsRows",
                newName: "OrgSid");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApproveDt",
                table: "ToRezervRows",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BrSid",
                table: "ToRezervRows",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Descr",
                table: "ToRezervRows",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocNum",
                table: "ToRezervRows",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocStatus",
                table: "ToRezervRows",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocStatusName",
                table: "ToRezervRows",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsFirstDistribution",
                table: "ToRezervRows",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TopFullSprKey",
                table: "ToRezervRows",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApproveDt",
                table: "ToPbsRows",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BrSid",
                table: "ToPbsRows",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Descr",
                table: "ToPbsRows",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocNum",
                table: "ToPbsRows",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocStatus",
                table: "ToPbsRows",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocStatusName",
                table: "ToPbsRows",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsFirstDistribution",
                table: "ToPbsRows",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TopFullSprKey",
                table: "ToPbsRows",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
