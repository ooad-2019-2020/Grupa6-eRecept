using Microsoft.EntityFrameworkCore.Migrations;

namespace eRecept.Migrations.RecipeRepositoryMigrations
{
    public partial class UserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1028)", nullable: false),
                    MealType = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    SideNote = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(1028)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
