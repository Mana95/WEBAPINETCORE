using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace jondellwebapi.Migrations
{
    public partial class convertBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "Balance",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 20, 12, 20, 42, 824, DateTimeKind.Local).AddTicks(5699),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "balance",
                table: "Balance",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "Balance",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 8, 20, 12, 20, 42, 824, DateTimeKind.Local).AddTicks(5699));

            migrationBuilder.AlterColumn<string>(
                name: "balance",
                table: "Balance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
