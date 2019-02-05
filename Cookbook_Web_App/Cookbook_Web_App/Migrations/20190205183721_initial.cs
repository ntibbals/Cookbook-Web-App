using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookbook_Web_App.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SavedRecipe",
                columns: table => new
                {
                    SavedRecipeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    APIReference = table.Column<int>(nullable: false),
                    Name = table.Column<int>(nullable: false),
                    Instructions = table.Column<string>(nullable: true),
                    Reviews = table.Column<string>(nullable: true),
                    comments = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedRecipe", x => x.SavedRecipeID);
                    table.ForeignKey(
                        name: "FK_SavedRecipe_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SavedRecipeID = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_SavedRecipe_SavedRecipeID",
                        column: x => x.SavedRecipeID,
                        principalTable: "SavedRecipe",
                        principalColumn: "SavedRecipeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SavedRecipe",
                columns: new[] { "SavedRecipeID", "APIReference", "Instructions", "Name", "Reviews", "UserID", "comments" },
                values: new object[] { 11, 22, "Cook until you can't cook no mo", 0, null, null, "This is so good" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "UserName" },
                values: new object[] { 33, "Tom" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SavedRecipeID",
                table: "Comments",
                column: "SavedRecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_SavedRecipe_UserID",
                table: "SavedRecipe",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "SavedRecipe");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
