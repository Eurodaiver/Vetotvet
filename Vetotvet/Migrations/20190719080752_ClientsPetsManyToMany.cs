using Microsoft.EntityFrameworkCore.Migrations;

namespace Vetotvet.Migrations
{
    public partial class ClientsPetsManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Clients_ClientId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Pets",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_ClientId",
                table: "Pets",
                newName: "IX_Pets_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Clients_OwnerId",
                table: "Pets",
                column: "OwnerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Clients_OwnerId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Pets",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_OwnerId",
                table: "Pets",
                newName: "IX_Pets_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Clients_ClientId",
                table: "Pets",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
