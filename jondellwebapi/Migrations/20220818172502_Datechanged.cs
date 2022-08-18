using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace jondellwebapi.Migrations
{
    public partial class Datechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balance_Account_Accountid",
                table: "Balance");

            migrationBuilder.RenameColumn(
                name: "Accountid",
                table: "Balance",
                newName: "accountId");

            migrationBuilder.RenameIndex(
                name: "IX_Balance_Accountid",
                table: "Balance",
                newName: "IX_Balance_accountId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "Balance",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Balance_Account_accountId",
                table: "Balance",
                column: "accountId",
                principalTable: "Account",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balance_Account_accountId",
                table: "Balance");

            migrationBuilder.RenameColumn(
                name: "accountId",
                table: "Balance",
                newName: "Accountid");

            migrationBuilder.RenameIndex(
                name: "IX_Balance_accountId",
                table: "Balance",
                newName: "IX_Balance_Accountid");

            migrationBuilder.AlterColumn<string>(
                name: "date",
                table: "Balance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddForeignKey(
                name: "FK_Balance_Account_Accountid",
                table: "Balance",
                column: "Accountid",
                principalTable: "Account",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
