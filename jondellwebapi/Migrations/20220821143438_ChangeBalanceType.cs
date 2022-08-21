using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace jondellwebapi.Migrations
{
    public partial class ChangeBalanceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "Balance",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 21, 20, 4, 38, 18, DateTimeKind.Local).AddTicks(4863),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 20, 12, 20, 42, 824, DateTimeKind.Local).AddTicks(5699));

            migrationBuilder.AlterColumn<double>(
                name: "balance",
                table: "Balance",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "Balance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 20, 12, 20, 42, 824, DateTimeKind.Local).AddTicks(5699),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 8, 21, 20, 4, 38, 18, DateTimeKind.Local).AddTicks(4863));

            migrationBuilder.AlterColumn<int>(
                name: "balance",
                table: "Balance",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
