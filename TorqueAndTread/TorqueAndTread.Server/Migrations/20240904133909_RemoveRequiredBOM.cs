using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRequiredBOM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Containers_BOMs_BOMId",
                table: "Containers");

            migrationBuilder.AlterColumn<int>(
                name: "BOMId",
                table: "Containers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_BOMs_BOMId",
                table: "Containers",
                column: "BOMId",
                principalTable: "BOMs",
                principalColumn: "BOMId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Containers_BOMs_BOMId",
                table: "Containers");

            migrationBuilder.AlterColumn<int>(
                name: "BOMId",
                table: "Containers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_BOMs_BOMId",
                table: "Containers",
                column: "BOMId",
                principalTable: "BOMs",
                principalColumn: "BOMId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
