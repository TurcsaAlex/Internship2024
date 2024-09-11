using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class NullableContainerUOM1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Containers_UOMs_UOMId",
                table: "Containers");

            migrationBuilder.AlterColumn<int>(
                name: "UOMId",
                table: "Containers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_UOMs_UOMId",
                table: "Containers",
                column: "UOMId",
                principalTable: "UOMs",
                principalColumn: "UOMId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Containers_UOMs_UOMId",
                table: "Containers");

            migrationBuilder.AlterColumn<int>(
                name: "UOMId",
                table: "Containers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_UOMs_UOMId",
                table: "Containers",
                column: "UOMId",
                principalTable: "UOMs",
                principalColumn: "UOMId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
