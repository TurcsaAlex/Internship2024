using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "UserRoles");

            migrationBuilder.AddColumn<int>(
                name: "ActionTypeId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuItemId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: -3,
                columns: new[] { "ActionTypeId", "MenuItemId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: -2,
                columns: new[] { "ActionTypeId", "MenuItemId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: -1,
                columns: new[] { "ActionTypeId", "MenuItemId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ActionTypeId",
                table: "Roles",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_MenuItemId",
                table: "Roles",
                column: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_ActionType_ActionTypeId",
                table: "Roles",
                column: "ActionTypeId",
                principalTable: "ActionType",
                principalColumn: "ActionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_MenuItems_MenuItemId",
                table: "Roles",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "MenuItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_ActionType_ActionTypeId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_MenuItems_MenuItemId",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_ActionTypeId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_MenuItemId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ActionTypeId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "Roles");

            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "UserRoles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }
    }
}
