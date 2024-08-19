using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixedCreatedByRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRoles_CreatedById",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_LastUpdatedById",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_CreatedById",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_LastUpdatedById",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_CreatedById",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_LastUpdatedById",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemRoles_CreatedById",
                table: "MenuItemRoles");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemRoles_LastUpdatedById",
                table: "MenuItemRoles");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemActionRole_CreatedById",
                table: "MenuItemActionRole");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemActionRole_LastUpdatedById",
                table: "MenuItemActionRole");

            migrationBuilder.DropIndex(
                name: "IX_ActionType_CreatedById",
                table: "ActionType");

            migrationBuilder.DropIndex(
                name: "IX_ActionType_LastUpdatedById",
                table: "ActionType");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_CreatedById",
                table: "UserRoles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_LastUpdatedById",
                table: "UserRoles",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatedById",
                table: "Roles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_LastUpdatedById",
                table: "Roles",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CreatedById",
                table: "MenuItems",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_LastUpdatedById",
                table: "MenuItems",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemRoles_CreatedById",
                table: "MenuItemRoles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemRoles_LastUpdatedById",
                table: "MenuItemRoles",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemActionRole_CreatedById",
                table: "MenuItemActionRole",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemActionRole_LastUpdatedById",
                table: "MenuItemActionRole",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ActionType_CreatedById",
                table: "ActionType",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ActionType_LastUpdatedById",
                table: "ActionType",
                column: "LastUpdatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRoles_CreatedById",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_LastUpdatedById",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_CreatedById",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_LastUpdatedById",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_CreatedById",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_LastUpdatedById",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemRoles_CreatedById",
                table: "MenuItemRoles");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemRoles_LastUpdatedById",
                table: "MenuItemRoles");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemActionRole_CreatedById",
                table: "MenuItemActionRole");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemActionRole_LastUpdatedById",
                table: "MenuItemActionRole");

            migrationBuilder.DropIndex(
                name: "IX_ActionType_CreatedById",
                table: "ActionType");

            migrationBuilder.DropIndex(
                name: "IX_ActionType_LastUpdatedById",
                table: "ActionType");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_CreatedById",
                table: "UserRoles",
                column: "CreatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_LastUpdatedById",
                table: "UserRoles",
                column: "LastUpdatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatedById",
                table: "Roles",
                column: "CreatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_LastUpdatedById",
                table: "Roles",
                column: "LastUpdatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CreatedById",
                table: "MenuItems",
                column: "CreatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_LastUpdatedById",
                table: "MenuItems",
                column: "LastUpdatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemRoles_CreatedById",
                table: "MenuItemRoles",
                column: "CreatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemRoles_LastUpdatedById",
                table: "MenuItemRoles",
                column: "LastUpdatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemActionRole_CreatedById",
                table: "MenuItemActionRole",
                column: "CreatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemActionRole_LastUpdatedById",
                table: "MenuItemActionRole",
                column: "LastUpdatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActionType_CreatedById",
                table: "ActionType",
                column: "CreatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActionType_LastUpdatedById",
                table: "ActionType",
                column: "LastUpdatedById",
                unique: true);
        }
    }
}
