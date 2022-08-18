using Microsoft.EntityFrameworkCore.Migrations;

namespace jondellwebapi.Migrations
{
    public partial class AddBalanceAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    accountType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Balance",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<string>(nullable: true),
                    balance = table.Column<string>(nullable: true),
                    Accountid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balance", x => x.id);
                    table.ForeignKey(
                        name: "FK_Balance_Account_Accountid",
                        column: x => x.Accountid,
                        principalTable: "Account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balance_Accountid",
                table: "Balance",
                column: "Accountid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balance");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
