using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizAppAPI_PRM.Migrations
{
    /// <inheritdoc />
    public partial class AddInformationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Information_Users_UserId",
                table: "Information");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Information",
                table: "Information");

            migrationBuilder.RenameTable(
                name: "Information",
                newName: "Informations");

            migrationBuilder.RenameIndex(
                name: "IX_Information_UserId",
                table: "Informations",
                newName: "IX_Informations_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Informations",
                table: "Informations",
                column: "InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Informations_Users_UserId",
                table: "Informations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Informations_Users_UserId",
                table: "Informations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Informations",
                table: "Informations");

            migrationBuilder.RenameTable(
                name: "Informations",
                newName: "Information");

            migrationBuilder.RenameIndex(
                name: "IX_Informations_UserId",
                table: "Information",
                newName: "IX_Information_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Information",
                table: "Information",
                column: "InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Information_Users_UserId",
                table: "Information",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
