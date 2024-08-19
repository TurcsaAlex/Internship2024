using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddActionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemRoles_Users_CreatedById",
                table: "MenuItemRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemRoles_Users_LastUpdatedById",
                table: "MenuItemRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Users_CreatedById",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Users_LastUpdatedById",
                table: "MenuItems");

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

            migrationBuilder.CreateTable(
                name: "ActionType",
                columns: table => new
                {
                    ActionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedById = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionType", x => x.ActionTypeId);
                    table.ForeignKey(
                        name: "FK_ActionType_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_ActionType_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "MenuItemActionRole",
                columns: table => new
                {
                    MenuItemActionRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedById = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemActionRole", x => x.MenuItemActionRoleId);
                    table.ForeignKey(
                        name: "FK_MenuItemActionRole_ActionType_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalTable: "ActionType",
                        principalColumn: "ActionTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemActionRole_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemActionRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemActionRole_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_MenuItemActionRole_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

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
                name: "IX_ActionType_CreatedById",
                table: "ActionType",
                column: "CreatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActionType_LastUpdatedById",
                table: "ActionType",
                column: "LastUpdatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemActionRole_ActionTypeId",
                table: "MenuItemActionRole",
                column: "ActionTypeId");

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
                name: "IX_MenuItemActionRole_MenuItemId",
                table: "MenuItemActionRole",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemActionRole_RoleId",
                table: "MenuItemActionRole",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemRoles_Users_CreatedById",
                table: "MenuItemRoles",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemRoles_Users_LastUpdatedById",
                table: "MenuItemRoles",
                column: "LastUpdatedById",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Users_CreatedById",
                table: "MenuItems",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Users_LastUpdatedById",
                table: "MenuItems",
                column: "LastUpdatedById",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemRoles_Users_CreatedById",
                table: "MenuItemRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemRoles_Users_LastUpdatedById",
                table: "MenuItemRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Users_CreatedById",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Users_LastUpdatedById",
                table: "MenuItems");

            migrationBuilder.DropTable(
                name: "MenuItemActionRole");

            migrationBuilder.DropTable(
                name: "ActionType");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemRoles_Users_CreatedById",
                table: "MenuItemRoles",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemRoles_Users_LastUpdatedById",
                table: "MenuItemRoles",
                column: "LastUpdatedById",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Users_CreatedById",
                table: "MenuItems",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Users_LastUpdatedById",
                table: "MenuItems",
                column: "LastUpdatedById",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
