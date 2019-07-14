using Microsoft.EntityFrameworkCore.Migrations;

namespace Vetotvet.Migrations
{
    public partial class BreedEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KindOfAnimalId",
                table: "Breeds",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_KindOfAnimalId",
                table: "Breeds",
                column: "KindOfAnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_KindOfAnimals_KindOfAnimalId",
                table: "Breeds",
                column: "KindOfAnimalId",
                principalTable: "KindOfAnimals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_KindOfAnimals_KindOfAnimalId",
                table: "Breeds");

            migrationBuilder.DropIndex(
                name: "IX_Breeds_KindOfAnimalId",
                table: "Breeds");

            migrationBuilder.DropColumn(
                name: "KindOfAnimalId",
                table: "Breeds");
        }
    }
}
