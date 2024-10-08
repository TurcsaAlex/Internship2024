﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TorqueAndTread.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMenuItemWithRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfilePicturePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedById = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Users_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

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
                name: "ContainerTypes",
                columns: table => new
                {
                    ContainerTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContainerTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedById = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerTypes", x => x.ContainerTypeId);
                    table.ForeignKey(
                        name: "FK_ContainerTypes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_ContainerTypes_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "LoginAttempts",
                columns: table => new
                {
                    LoginAttemptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginAttemptResult = table.Column<int>(type: "int", nullable: false),
                    LoginMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedById = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAttempts", x => x.LoginAttemptId);
                    table.ForeignKey(
                        name: "FK_LoginAttempts_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_LoginAttempts_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_LoginAttempts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedById = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_MenuItems_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_MenuItems_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ProductTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedById = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeId);
                    table.ForeignKey(
                        name: "FK_ProductTypes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_ProductTypes_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_Roles_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Roles_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UOMs",
                columns: table => new
                {
                    UOMId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UOMName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedById = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UOMs", x => x.UOMId);
                    table.ForeignKey(
                        name: "FK_UOMs_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_UOMs_Users_LastUpdatedById",
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
                    ReqSuperVisorApproval = table.Column<bool>(type: "bit", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "MenuItemRoles",
                columns: table => new
                {
                    MenuItemRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedById = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemRoles", x => x.MenuItemRoleId);
                    table.ForeignKey(
                        name: "FK_MenuItemRoles_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemRoles_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_MenuItemRoles_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedById = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BOMs",
                columns: table => new
                {
                    BOMId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BOMName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    BOMCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedById = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMs", x => x.BOMId);
                    table.ForeignKey(
                        name: "FK_BOMs_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_BOMs_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    ContainerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    ContainerCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedById = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BOMId = table.Column<int>(type: "int", nullable: true),
                    UOMId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ContainerTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x.ContainerId);
                    table.ForeignKey(
                        name: "FK_Containers_BOMs_BOMId",
                        column: x => x.BOMId,
                        principalTable: "BOMs",
                        principalColumn: "BOMId");
                    table.ForeignKey(
                        name: "FK_Containers_ContainerTypes_ContainerTypeId",
                        column: x => x.ContainerTypeId,
                        principalTable: "ContainerTypes",
                        principalColumn: "ContainerTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Containers_UOMs_UOMId",
                        column: x => x.UOMId,
                        principalTable: "UOMs",
                        principalColumn: "UOMId");
                    table.ForeignKey(
                        name: "FK_Containers_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Containers_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCodeName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedById = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    DefaultUOMId = table.Column<int>(type: "int", nullable: false),
                    ContainerId = table.Column<int>(type: "int", nullable: true),
                    UOMId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Containers_ContainerId",
                        column: x => x.ContainerId,
                        principalTable: "Containers",
                        principalColumn: "ContainerId");
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_UOMs_DefaultUOMId",
                        column: x => x.DefaultUOMId,
                        principalTable: "UOMs",
                        principalColumn: "UOMId");
                    table.ForeignKey(
                        name: "FK_Products_UOMs_UOMId",
                        column: x => x.UOMId,
                        principalTable: "UOMs",
                        principalColumn: "UOMId");
                    table.ForeignKey(
                        name: "FK_Products_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Products_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "ProductBOMs",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BOMId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedById = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBOMs", x => new { x.ProductId, x.BOMId });
                    table.ForeignKey(
                        name: "FK_ProductBOMs_BOMs_BOMId",
                        column: x => x.BOMId,
                        principalTable: "BOMs",
                        principalColumn: "BOMId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductBOMs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductBOMs_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_ProductBOMs_Users_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Active", "CreatedById", "CreatedOn", "Email", "LastUpdatedById", "LastUpdatedOn", "Name", "Password", "ProfilePicturePath", "UserName" },
                values: new object[] { -1, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), "admin@admin.com", -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", "", "", "admin" });

            migrationBuilder.InsertData(
                table: "ContainerTypes",
                columns: new[] { "ContainerTypeId", "Active", "ContainerTypeName", "CreatedById", "CreatedOn", "LastUpdatedById", "LastUpdatedOn" },
                values: new object[,]
                {
                    { -2, true, "Palet", -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -1, true, "Box", -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "Active", "CreatedById", "CreatedOn", "IconClass", "LastUpdatedById", "LastUpdatedOn", "Link", "Name", "OrderNo" },
                values: new object[,]
                {
                    { 1, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), "", -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "/dashboard", "Dashboard", 1 },
                    { 2, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), "fas fa-bars", -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "/menus", "Menus", 2 },
                    { 3, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), "fas fa-users", -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "/users", "Users", 3 },
                    { 4, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), "fas fa-user-tag", -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "/roles", "Roles", 4 },
                    { 5, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), "fas fa-box", -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "/products", "Products", 5 },
                    { 6, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), "fas fa-boxes", -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "/containers", "Containers", 6 },
                    { 7, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), "fas fa-list-alt", -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "/boms", "BOMs", 7 },
                    { 8, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), "fas fa-industry", -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "/productionorders", "Production Orders", 8 }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "ProductTypeId", "Active", "CreatedById", "CreatedOn", "LastUpdatedById", "LastUpdatedOn", "ProductTypeName" },
                values: new object[,]
                {
                    { -3, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Finished Good" },
                    { -2, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Semifinished Good" },
                    { -1, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Raw Material" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Active", "CreatedById", "CreatedOn", "LastUpdatedById", "LastUpdatedOn", "Name" },
                values: new object[,]
                {
                    { -3, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Supervisor" },
                    { -2, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Operator" },
                    { -1, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "UOMs",
                columns: new[] { "UOMId", "Active", "CreatedById", "CreatedOn", "LastUpdatedById", "LastUpdatedOn", "UOMName" },
                values: new object[,]
                {
                    { -3, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Ea" },
                    { -2, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Kg" },
                    { -1, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "g" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Active", "CreatedById", "CreatedOn", "Email", "LastUpdatedById", "LastUpdatedOn", "Name", "Password", "ProfilePicturePath", "UserName" },
                values: new object[,]
                {
                    { -3, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), "admin3@admin.com", -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", "", "", "admin2" },
                    { -2, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), "admin2@admin.com", -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", "", "", "admin1" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "Active", "CreatedById", "CreatedOn", "LastUpdatedById", "LastUpdatedOn" },
                values: new object[,]
                {
                    { -1, -3, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -3, -2, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -2, -2, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -1, -2, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -3, -1, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -2, -1, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -1, -1, true, -1, new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified), -1, new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionType_CreatedById",
                table: "ActionType",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ActionType_LastUpdatedById",
                table: "ActionType",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BOMs_CreatedById",
                table: "BOMs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BOMs_LastUpdatedById",
                table: "BOMs",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BOMs_MaterialId",
                table: "BOMs",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_BOMId",
                table: "Containers",
                column: "BOMId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_ContainerCode",
                table: "Containers",
                column: "ContainerCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Containers_ContainerTypeId",
                table: "Containers",
                column: "ContainerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_CreatedById",
                table: "Containers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_LastUpdatedById",
                table: "Containers",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_ProductId",
                table: "Containers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_UOMId",
                table: "Containers",
                column: "UOMId");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerTypes_CreatedById",
                table: "ContainerTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerTypes_LastUpdatedById",
                table: "ContainerTypes",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LoginAttempts_CreatedById",
                table: "LoginAttempts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LoginAttempts_LastUpdatedById",
                table: "LoginAttempts",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LoginAttempts_UserId",
                table: "LoginAttempts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemActionRole_ActionTypeId",
                table: "MenuItemActionRole",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemActionRole_CreatedById",
                table: "MenuItemActionRole",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemActionRole_LastUpdatedById",
                table: "MenuItemActionRole",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemActionRole_MenuItemId",
                table: "MenuItemActionRole",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemActionRole_RoleId",
                table: "MenuItemActionRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemRoles_CreatedById",
                table: "MenuItemRoles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemRoles_LastUpdatedById",
                table: "MenuItemRoles",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemRoles_MenuItemId",
                table: "MenuItemRoles",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemRoles_RoleId",
                table: "MenuItemRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CreatedById",
                table: "MenuItems",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_LastUpdatedById",
                table: "MenuItems",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBOMs_BOMId",
                table: "ProductBOMs",
                column: "BOMId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBOMs_CreatedById",
                table: "ProductBOMs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBOMs_LastUpdatedById",
                table: "ProductBOMs",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ContainerId",
                table: "Products",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedById",
                table: "Products",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DefaultUOMId",
                table: "Products",
                column: "DefaultUOMId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LastUpdatedById",
                table: "Products",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCodeName",
                table: "Products",
                column: "ProductCodeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UOMId",
                table: "Products",
                column: "UOMId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_CreatedById",
                table: "ProductTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_LastUpdatedById",
                table: "ProductTypes",
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
                name: "IX_UOMs_CreatedById",
                table: "UOMs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UOMs_LastUpdatedById",
                table: "UOMs",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_CreatedById",
                table: "UserRoles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_LastUpdatedById",
                table: "UserRoles",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedById",
                table: "Users",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LastUpdatedById",
                table: "Users",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName_Email",
                table: "Users",
                columns: new[] { "UserName", "Email" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BOMs_Products_MaterialId",
                table: "BOMs",
                column: "MaterialId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Products_ProductId",
                table: "Containers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOMs_Users_CreatedById",
                table: "BOMs");

            migrationBuilder.DropForeignKey(
                name: "FK_BOMs_Users_LastUpdatedById",
                table: "BOMs");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Users_CreatedById",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Users_LastUpdatedById",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerTypes_Users_CreatedById",
                table: "ContainerTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerTypes_Users_LastUpdatedById",
                table: "ContainerTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_CreatedById",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_LastUpdatedById",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Users_CreatedById",
                table: "ProductTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Users_LastUpdatedById",
                table: "ProductTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_UOMs_Users_CreatedById",
                table: "UOMs");

            migrationBuilder.DropForeignKey(
                name: "FK_UOMs_Users_LastUpdatedById",
                table: "UOMs");

            migrationBuilder.DropForeignKey(
                name: "FK_BOMs_Products_MaterialId",
                table: "BOMs");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Products_ProductId",
                table: "Containers");

            migrationBuilder.DropTable(
                name: "LoginAttempts");

            migrationBuilder.DropTable(
                name: "MenuItemActionRole");

            migrationBuilder.DropTable(
                name: "MenuItemRoles");

            migrationBuilder.DropTable(
                name: "ProductBOMs");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "ActionType");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "BOMs");

            migrationBuilder.DropTable(
                name: "ContainerTypes");

            migrationBuilder.DropTable(
                name: "UOMs");
        }
    }
}
