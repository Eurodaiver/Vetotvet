using Microsoft.EntityFrameworkCore.Migrations;

namespace Vetotvet.Migrations
{
    public partial class KindAnimalsEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_KindOfAnimals_KindId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_KindId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "KindId",
                table: "Pets",
                newName: "KindOfAnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KindOfAnimalId",
                table: "Pets",
                newName: "KindId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_KindId",
                table: "Pets",
                column: "KindId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_KindOfAnimals_KindId",
                table: "Pets",
                column: "KindId",
                principalTable: "KindOfAnimals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
