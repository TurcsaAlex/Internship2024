using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class LoginAttemptChangeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginAttempt_Users_CreatedById",
                table: "LoginAttempt");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginAttempt_Users_LastUpdatedById",
                table: "LoginAttempt");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginAttempt_Users_UserId",
                table: "LoginAttempt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginAttempt",
                table: "LoginAttempt");

            migrationBuilder.RenameTable(
                name: "LoginAttempt",
                newName: "LoginAttempts");

            migrationBuilder.RenameColumn(
                name: "LoginAttemptResultEnum",
                table: "LoginAttempts",
                newName: "LoginAttemptResult");

            migrationBuilder.RenameIndex(
                name: "IX_LoginAttempt_UserId",
                table: "LoginAttempts",
                newName: "IX_LoginAttempts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LoginAttempt_LastUpdatedById",
                table: "LoginAttempts",
                newName: "IX_LoginAttempts_LastUpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_LoginAttempt_CreatedById",
                table: "LoginAttempts",
                newName: "IX_LoginAttempts_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginAttempts",
                table: "LoginAttempts",
                column: "LoginAttemptId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginAttempts_Users_CreatedById",
                table: "LoginAttempts",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginAttempts_Users_LastUpdatedById",
                table: "LoginAttempts",
                column: "LastUpdatedById",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginAttempts_Users_UserId",
                table: "LoginAttempts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginAttempts_Users_CreatedById",
                table: "LoginAttempts");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginAttempts_Users_LastUpdatedById",
                table: "LoginAttempts");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginAttempts_Users_UserId",
                table: "LoginAttempts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginAttempts",
                table: "LoginAttempts");

            migrationBuilder.RenameTable(
                name: "LoginAttempts",
                newName: "LoginAttempt");

            migrationBuilder.RenameColumn(
                name: "LoginAttemptResult",
                table: "LoginAttempt",
                newName: "LoginAttemptResultEnum");

            migrationBuilder.RenameIndex(
                name: "IX_LoginAttempts_UserId",
                table: "LoginAttempt",
                newName: "IX_LoginAttempt_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LoginAttempts_LastUpdatedById",
                table: "LoginAttempt",
                newName: "IX_LoginAttempt_LastUpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_LoginAttempts_CreatedById",
                table: "LoginAttempt",
                newName: "IX_LoginAttempt_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginAttempt",
                table: "LoginAttempt",
                column: "LoginAttemptId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginAttempt_Users_CreatedById",
                table: "LoginAttempt",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginAttempt_Users_LastUpdatedById",
                table: "LoginAttempt",
                column: "LastUpdatedById",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginAttempt_Users_UserId",
                table: "LoginAttempt",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
