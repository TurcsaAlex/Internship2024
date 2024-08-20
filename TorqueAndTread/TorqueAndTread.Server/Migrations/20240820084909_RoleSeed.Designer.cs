﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TorqueAndTread.Server.Context;

#nullable disable

namespace TorqueAndTread.Server.Migrations
{
    [DbContext(typeof(TorqueDbContext))]
    [Migration("20240820084909_RoleSeed")]
    partial class RoleSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TorqueAndTread.Server.Models.ActionType", b =>
                {
                    b.Property<int>("ActionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActionTypeId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("LastUpdatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActionTypeId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.ToTable("ActionType");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.BOM", b =>
                {
                    b.Property<int>("BOMId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BOMId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("BOMName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaterialIdBOMCode")
                        .HasColumnType("int");

                    b.HasKey("BOMId");

                    b.ToTable("BOMs");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.Container", b =>
                {
                    b.Property<int>("ContainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContainerId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("BOMId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UOMId")
                        .HasColumnType("int");

                    b.HasKey("ContainerId");

                    b.HasIndex("BOMId");

                    b.HasIndex("UOMId")
                        .IsUnique();

                    b.ToTable("Containers");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("IconClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LastUpdatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderNo")
                        .HasColumnType("int");

                    b.HasKey("MenuItemId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.MenuItemActionRole", b =>
                {
                    b.Property<int>("MenuItemActionRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemActionRoleId"));

                    b.Property<int>("ActionTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("LastUpdatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<bool>("ReqSuperVisorApproval")
                        .HasColumnType("bit");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("MenuItemActionRoleId");

                    b.HasIndex("ActionTypeId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("RoleId");

                    b.ToTable("MenuItemActionRole");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.MenuItemRole", b =>
                {
                    b.Property<int>("MenuItemRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemRoleId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("LastUpdatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("MenuItemRoleId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("RoleId");

                    b.ToTable("MenuItemRoles");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductCodeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ProductTypeIdName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductTypeId")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.ProductBOM", b =>
                {
                    b.Property<int>("ProductBOMId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductBOMId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("BOMId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductBOMId");

                    b.HasIndex("BOMId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductBOMs");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.ProductType", b =>
                {
                    b.Property<int>("ProductTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductTypeId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductTypeId");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("LastUpdatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = -1,
                            Active = true,
                            CreatedById = -1,
                            CreatedOn = new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified),
                            LastUpdatedById = -1,
                            LastUpdatedOn = new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Administrator"
                        },
                        new
                        {
                            RoleId = -2,
                            Active = true,
                            CreatedById = -1,
                            CreatedOn = new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified),
                            LastUpdatedById = -1,
                            LastUpdatedOn = new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Operator"
                        },
                        new
                        {
                            RoleId = -3,
                            Active = true,
                            CreatedById = -1,
                            CreatedOn = new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified),
                            LastUpdatedById = -1,
                            LastUpdatedOn = new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Supervisor"
                        });
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.UOM", b =>
                {
                    b.Property<int>("UOMId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UOMId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("UOMName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UOMId");

                    b.ToTable("UOMs");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("LastUpdatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.HasIndex("UserName", "Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = -1,
                            Active = true,
                            CreatedById = -1,
                            CreatedOn = new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified),
                            Email = "admin@admin.com",
                            LastUpdatedById = -1,
                            LastUpdatedOn = new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Administrator",
                            Password = "",
                            UserName = "admin"
                        },
                        new
                        {
                            UserId = -2,
                            Active = true,
                            CreatedById = -1,
                            CreatedOn = new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified),
                            Email = "admin2@admin.com",
                            LastUpdatedById = -1,
                            LastUpdatedOn = new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Administrator",
                            Password = "",
                            UserName = "admin1"
                        },
                        new
                        {
                            UserId = -3,
                            Active = true,
                            CreatedById = -1,
                            CreatedOn = new DateTime(2024, 8, 19, 10, 15, 30, 0, DateTimeKind.Unspecified),
                            Email = "admin3@admin.com",
                            LastUpdatedById = -1,
                            LastUpdatedOn = new DateTime(2024, 8, 19, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Administrator",
                            Password = "",
                            UserName = "admin2"
                        });
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserRoleId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("LastUpdatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserRoleId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.ActionType", b =>
                {
                    b.HasOne("TorqueAndTread.Server.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TorqueAndTread.Server.Models.User", "LastUpdatedBy")
                        .WithMany()
                        .HasForeignKey("LastUpdatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("LastUpdatedBy");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.Container", b =>
                {
                    b.HasOne("TorqueAndTread.Server.Models.BOM", "BOM")
                        .WithMany("Containers")
                        .HasForeignKey("BOMId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TorqueAndTread.Server.Models.UOM", "UOM")
                        .WithOne("Container")
                        .HasForeignKey("TorqueAndTread.Server.Models.Container", "UOMId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BOM");

                    b.Navigation("UOM");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.MenuItem", b =>
                {
                    b.HasOne("TorqueAndTread.Server.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TorqueAndTread.Server.Models.User", "LastUpdatedBy")
                        .WithMany()
                        .HasForeignKey("LastUpdatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("LastUpdatedBy");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.MenuItemActionRole", b =>
                {
                    b.HasOne("TorqueAndTread.Server.Models.ActionType", "ActionType")
                        .WithMany("MenuItemActionRoles")
                        .HasForeignKey("ActionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TorqueAndTread.Server.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TorqueAndTread.Server.Models.User", "LastUpdatedBy")
                        .WithMany()
                        .HasForeignKey("LastUpdatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TorqueAndTread.Server.Models.MenuItem", "MenuItem")
                        .WithMany("MenuItemActionRoles")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TorqueAndTread.Server.Models.Role", "Role")
                        .WithMany("MenuItemActionRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActionType");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastUpdatedBy");

                    b.Navigation("MenuItem");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.MenuItemRole", b =>
                {
                    b.HasOne("TorqueAndTread.Server.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TorqueAndTread.Server.Models.User", "LastUpdatedBy")
                        .WithMany()
                        .HasForeignKey("LastUpdatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TorqueAndTread.Server.Models.MenuItem", "MenuItem")
                        .WithMany("MenuItemRoles")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TorqueAndTread.Server.Models.Role", "Role")
                        .WithMany("MenuItemRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("LastUpdatedBy");

                    b.Navigation("MenuItem");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.Product", b =>
                {
                    b.HasOne("TorqueAndTread.Server.Models.ProductType", "ProductType")
                        .WithOne("Product")
                        .HasForeignKey("TorqueAndTread.Server.Models.Product", "ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.ProductBOM", b =>
                {
                    b.HasOne("TorqueAndTread.Server.Models.BOM", "BOM")
                        .WithMany("ProductBOM")
                        .HasForeignKey("BOMId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TorqueAndTread.Server.Models.Product", "Product")
                        .WithMany("ProductBOMs")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BOM");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.Role", b =>
                {
                    b.HasOne("TorqueAndTread.Server.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TorqueAndTread.Server.Models.User", "LastUpdatedBy")
                        .WithMany()
                        .HasForeignKey("LastUpdatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("LastUpdatedBy");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.User", b =>
                {
                    b.HasOne("TorqueAndTread.Server.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TorqueAndTread.Server.Models.User", "LastUpdatedBy")
                        .WithMany()
                        .HasForeignKey("LastUpdatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("LastUpdatedBy");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.UserRole", b =>
                {
                    b.HasOne("TorqueAndTread.Server.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TorqueAndTread.Server.Models.User", "LastUpdatedBy")
                        .WithMany()
                        .HasForeignKey("LastUpdatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TorqueAndTread.Server.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TorqueAndTread.Server.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("LastUpdatedBy");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.ActionType", b =>
                {
                    b.Navigation("MenuItemActionRoles");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.BOM", b =>
                {
                    b.Navigation("Containers");

                    b.Navigation("ProductBOM");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.MenuItem", b =>
                {
                    b.Navigation("MenuItemActionRoles");

                    b.Navigation("MenuItemRoles");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.Product", b =>
                {
                    b.Navigation("ProductBOMs");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.ProductType", b =>
                {
                    b.Navigation("Product")
                        .IsRequired();
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.Role", b =>
                {
                    b.Navigation("MenuItemActionRoles");

                    b.Navigation("MenuItemRoles");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.UOM", b =>
                {
                    b.Navigation("Container")
                        .IsRequired();
                });

            modelBuilder.Entity("TorqueAndTread.Server.Models.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
