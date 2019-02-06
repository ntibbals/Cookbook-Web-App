using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookbook_Web_App.Migrations
{
    public partial class seedsavedre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SavedRecipe",
                columns: new[] { "SavedRecipeID", "APIReference", "Name", "UserID" },
                values: new object[] { 11, 22, "Fruit Loops", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SavedRecipe",
                keyColumn: "SavedRecipeID",
                keyValue: 11);
        }
    }
}
