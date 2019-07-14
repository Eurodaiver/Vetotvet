using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vetotvet.Migrations
{
    public partial class KindAnimalsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KindId",
                table: "Pets",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KindOfAnimals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kind = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KindOfAnimals", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_KindOfAnimals_KindId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "KindOfAnimals");

            migrationBuilder.DropIndex(
                name: "IX_Pets_KindId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "KindId",
                table: "Pets");
        }
    }
}
