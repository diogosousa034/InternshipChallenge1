using Microsoft.EntityFrameworkCore.Migrations;

namespace InternshipChallenge1.Migrations
{
    public partial class correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountContentComments_AccountsContents_AccountContentCommentId",
                table: "AccountContentComments");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsContents_Accounts_AccountsContentId",
                table: "AccountsContents");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsContents_AccountId",
                table: "AccountsContents",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountContentComments_AccountsContentId",
                table: "AccountContentComments",
                column: "AccountsContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountContentComments_AccountsContents_AccountsContentId",
                table: "AccountContentComments",
                column: "AccountsContentId",
                principalTable: "AccountsContents",
                principalColumn: "AccountsContentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsContents_Accounts_AccountId",
                table: "AccountsContents",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountContentComments_AccountsContents_AccountsContentId",
                table: "AccountContentComments");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsContents_Accounts_AccountId",
                table: "AccountsContents");

            migrationBuilder.DropIndex(
                name: "IX_AccountsContents_AccountId",
                table: "AccountsContents");

            migrationBuilder.DropIndex(
                name: "IX_AccountContentComments_AccountsContentId",
                table: "AccountContentComments");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountContentComments_AccountsContents_AccountContentCommentId",
                table: "AccountContentComments",
                column: "AccountContentCommentId",
                principalTable: "AccountsContents",
                principalColumn: "AccountsContentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsContents_Accounts_AccountsContentId",
                table: "AccountsContents",
                column: "AccountsContentId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
