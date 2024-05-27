using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FruitHealth.Migrations.fruitHealth
{
    /// <inheritdoc />
    public partial class addedId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FruitHealthPredictionResults",
                table: "FruitHealthPredictionResults");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FruitHealthPredictionResults",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FruitHealthPredictionResults",
                table: "FruitHealthPredictionResults",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FruitHealthPredictionResults",
                table: "FruitHealthPredictionResults");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FruitHealthPredictionResults");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FruitHealthPredictionResults",
                table: "FruitHealthPredictionResults",
                column: "PredictedLabel");
        }
    }
}
