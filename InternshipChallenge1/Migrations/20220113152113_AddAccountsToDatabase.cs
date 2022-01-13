using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternshipChallenge1.Migrations
{
    public partial class AddAccountsToDatabase : Migration
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
                name: "AccountsContent",
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
                    table.PrimaryKey("PK_AccountsContent", x => x.AccountsContentId);
                    table.ForeignKey(
                        name: "FK_AccountsContent_Account_AccountsContentId",
                        column: x => x.AccountsContentId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountContentComment",
                columns: table => new
                {
                    AccountContentCommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    AccountsContentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountContentComment", x => x.AccountContentCommentId);
                    table.ForeignKey(
                        name: "FK_AccountContentComment_AccountsContent_AccountContentCommentId",
                        column: x => x.AccountContentCommentId,
                        principalTable: "AccountsContent",
                        principalColumn: "AccountsContentId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountContentComment");

            migrationBuilder.DropTable(
                name: "AccountsContent");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
