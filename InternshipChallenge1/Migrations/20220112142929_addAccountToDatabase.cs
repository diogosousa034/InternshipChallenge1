using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternshipChallenge1.Migrations
{
    public partial class addAccountToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    NrFollowers = table.Column<int>(nullable: false),
                    NrFollowing = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountsContents",
                columns: table => new
                {
                    AccountsContentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(nullable: true),
                    PublicationData = table.Column<DateTime>(nullable: false),
                    AccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsContents", x => x.AccountsContentId);
                    table.ForeignKey(
                        name: "FK_AccountsContents_Account_AccountsContentId",
                        column: x => x.AccountsContentId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountContentComments",
                columns: table => new
                {
                    AccountContentCommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    AccountsContentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountContentComments", x => x.AccountContentCommentId);
                    table.ForeignKey(
                        name: "FK_AccountContentComments_AccountsContents_AccountContentCommentId",
                        column: x => x.AccountContentCommentId,
                        principalTable: "AccountsContents",
                        principalColumn: "AccountsContentId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountContentComments");

            migrationBuilder.DropTable(
                name: "AccountsContents");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
