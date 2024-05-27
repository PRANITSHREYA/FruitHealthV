using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FruitHealth.Migrations.fruitHealth
{
    /// <inheritdoc />
    public partial class changetablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FruitHealthPredictionResult");

            migrationBuilder.CreateTable(
                name: "FruitHealthPredictionResults",
                columns: table => new
                {
                    PredictedLabel = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    Score = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ImageFilePath = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    PredictedDateTime = table.Column<DateTime>(type: "datetime2", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FruitHealthPredictionResults", x => x.PredictedLabel);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FruitHealthPredictionResults");

            migrationBuilder.CreateTable(
                name: "FruitHealthPredictionResult",
                columns: table => new
                {
                    PredictedLabel = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    ImageFilePath = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    PredictedDateTime = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Score = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FruitHealthPredictionResult", x => x.PredictedLabel);
                });
        }
    }
}
