using Microsoft.EntityFrameworkCore.Migrations;

namespace InternshipChallenge1.Migrations
{
    public partial class addPropteste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "teste",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "teste",
                table: "Accounts");
        }
    }
}
