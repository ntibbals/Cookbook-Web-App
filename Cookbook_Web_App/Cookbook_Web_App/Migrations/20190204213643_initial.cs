using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookbook_Web_App.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SavedRecipeID",
                table: "User",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SavedRecipe",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    APIReference = table.Column<int>(nullable: false),
                    Instructions = table.Column<string>(nullable: true),
                    Reviews = table.Column<string>(nullable: true),
                    comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedRecipe", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_SavedRecipeID",
                table: "User",
                column: "SavedRecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SavedRecipeID",
                table: "Comments",
                column: "SavedRecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_SavedRecipe_SavedRecipeID",
                table: "Comments",
                column: "SavedRecipeID",
                principalTable: "SavedRecipe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_SavedRecipe_SavedRecipeID",
                table: "User",
                column: "SavedRecipeID",
                principalTable: "SavedRecipe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_SavedRecipe_SavedRecipeID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_User_SavedRecipe_SavedRecipeID",
                table: "User");

            migrationBuilder.DropTable(
                name: "SavedRecipe");

            migrationBuilder.DropIndex(
                name: "IX_User_SavedRecipeID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SavedRecipeID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "SavedRecipeID",
                table: "User");
        }
    }
}
