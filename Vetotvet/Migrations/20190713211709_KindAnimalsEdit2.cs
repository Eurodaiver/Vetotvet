using Microsoft.EntityFrameworkCore.Migrations;

namespace Vetotvet.Migrations
{
    public partial class KindAnimalsEdit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pets_KindOfAnimalId",
                table: "Pets",
                column: "KindOfAnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_KindOfAnimals_KindOfAnimalId",
                table: "Pets",
                column: "KindOfAnimalId",
                principalTable: "KindOfAnimals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_KindOfAnimals_KindOfAnimalId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_KindOfAnimalId",
                table: "Pets");
        }
    }
}
