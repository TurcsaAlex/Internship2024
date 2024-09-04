using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class LoginAttemptsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginAttempt_Users_UserId",
                table: "LoginAttempt");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "LoginAttempt",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginAttempt_Users_UserId",
                table: "LoginAttempt",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginAttempt_Users_UserId",
                table: "LoginAttempt");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "LoginAttempt",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginAttempt_Users_UserId",
                table: "LoginAttempt",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
