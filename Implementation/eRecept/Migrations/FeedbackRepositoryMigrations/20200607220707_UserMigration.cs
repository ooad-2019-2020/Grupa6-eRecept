using Microsoft.EntityFrameworkCore.Migrations;

namespace eRecept.Migrations.FeedbackRepositoryMigrations
{
    public partial class UserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<string>(type: "varchar(5)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(5)", nullable: false),
                    Rating = table.Column<string>(type: "varchar(5)", nullable: false),
                    Comment = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");
        }
    }
}
