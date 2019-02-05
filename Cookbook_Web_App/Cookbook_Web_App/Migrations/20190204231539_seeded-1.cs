using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookbook_Web_App.Migrations
{
    public partial class seeded1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SavedRecipe",
                columns: new[] { "SavedRecipeID", "APIReference", "Instructions", "Reviews", "UserID", "comments" },
                values: new object[] { 11, 22, "Cook until you can't cook no mo", null, null, "This is so good" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "UserName" },
                values: new object[] { 33, "Tom" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SavedRecipe",
                keyColumn: "SavedRecipeID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: 33);
        }
    }
}
