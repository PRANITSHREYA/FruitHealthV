using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FruitHealth.Migrations.fruitHealth
{
    /// <inheritdoc />
    public partial class YourMigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FruitHealthPredictionResult",
                columns: table => new
                {
                    PredictedLabel = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    Score = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ImageFilePath = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    PredictedDateTime = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FruitHealthPredictionResult", x => x.PredictedLabel);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FruitHealthPredictionResult");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
