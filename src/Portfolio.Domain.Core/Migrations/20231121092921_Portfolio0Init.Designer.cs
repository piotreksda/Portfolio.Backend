﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Portfolio.Domain.Core.Domain;

#nullable disable

namespace Portfolio.Domain.Core.Migrations
{
    [DbContext(typeof(PortfolioDbContext))]
    [Migration("20231121092921_Portfolio0Init")]
    partial class Portfolio0Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("EmailConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<Guid>("SecurityStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.Property<bool>("TwoFactorEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasDatabaseName("User_UserName");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.LoginHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2023, 11, 21, 9, 29, 21, 372, DateTimeKind.Utc).AddTicks(4070));

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LoginHistory", (string)null);
                });

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Permissions", (string)null);
                });

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.PermissionPermissionSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<int>("PermissionId")
                        .HasColumnType("integer");

                    b.Property<int?>("PermissionId1")
                        .HasColumnType("integer");

                    b.Property<int>("PermissionSetId")
                        .HasColumnType("integer");

                    b.Property<int>("PermissionSetId1")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId1");

                    b.HasIndex("PermissionSetId");

                    b.HasIndex("PermissionSetId1");

                    b.HasIndex("PermissionId", "PermissionSetId");

                    b.ToTable("PermissionsPermissionSets", (string)null);
                });

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.PermissionSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("PermissionSets", (string)null);
                });

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApplicationUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<byte[]>("Token")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ValidTo")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.RolePermissionSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<int>("PermissionSetId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("PermissionSetId", "RoleId");

                    b.ToTable("RolesPermissionSets", (string)null);
                });

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId", "RoleId");

                    b.ToTable("UsersRoles", (string)null);
                });

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.ApplicationUser", b =>
                {
                    b.OwnsOne("Portfolio.Domain.Core.Domain.Auth.Entities.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<int>("ApplicationUserId")
                                .HasColumnType("integer");

                            b1.Property<string>("Value")
                                .HasMaxLength(64)
                                .HasColumnType("character varying(64)")
                                .HasColumnName("Email");

                            b1.HasKey("ApplicationUserId");

                            b1.HasIndex("Value")
                                .IsUnique()
                                .HasDatabaseName("User_Email");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("ApplicationUserId");
                        });

                    b.OwnsOne("Portfolio.Domain.Core.Domain.Auth.Entities.ValueObjects.Email", "NormalizedEmail", b1 =>
                        {
                            b1.Property<int>("ApplicationUserId")
                                .HasColumnType("integer");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("character varying(64)")
                                .HasColumnName("NormalizedEmail");

                            b1.HasKey("ApplicationUserId");

                            b1.HasIndex("Value")
                                .IsUnique()
                                .HasDatabaseName("User_NormalizedEmail");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("ApplicationUserId");
                        });

                    b.OwnsOne("Portfolio.Domain.Core.Domain.Auth.Entities.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<int>("ApplicationUserId")
                                .HasColumnType("integer");

                            b1.Property<string>("Value")
                                .HasMaxLength(64)
                                .HasColumnType("character varying(64)")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("ApplicationUserId");

                            b1.HasIndex("Value")
                                .IsUnique()
                                .HasDatabaseName("User_PhoneNumber")
                                .HasFilter("\"PhoneNumber\" IS NOT NULL");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("ApplicationUserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("NormalizedEmail")
                        .IsRequired();

                    b.Navigation("PhoneNumber");
                });

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.LoginHistory", b =>
                {
                    b.HasOne("Portfolio.Domain.Core.Domain.Auth.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_LoginHistory_UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.PermissionPermissionSet", b =>
                {
                    b.HasOne("Portfolio.Domain.Core.Domain.Auth.Entities.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PermissionPermissionSet_Permission");

                    b.HasOne("Portfolio.Domain.Core.Domain.Auth.Entities.Permission", null)
                        .WithMany("PermissionPermissionSet")
                        .HasForeignKey("PermissionId1");

                    b.HasOne("Portfolio.Domain.Core.Domain.Auth.Entities.PermissionSet", null)
                        .WithMany("PermissionPermissionSet")
                        .HasForeignKey("PermissionSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PermissionSet_PermissionSetId");

                    b.HasOne("Portfolio.Domain.Core.Domain.Auth.Entities.PermissionSet", "PermissionSet")
                        .WithMany()
                        .HasForeignKey("PermissionSetId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("PermissionSet");
                });

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.RefreshToken", b =>
                {
                    b.HasOne("Portfolio.Domain.Core.Domain.Auth.Entities.ApplicationUser", null)
                        .WithMany("RefreshTokens")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Portfolio.Domain.Core.Domain.Auth.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_RefreshToken_UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.RolePermissionSet", b =>
                {
                    b.HasOne("Portfolio.Domain.Core.Domain.Auth.Entities.PermissionSet", "PermissionSet")
                        .WithMany()
                        .HasForeignKey("PermissionSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_RolePermissionSet_PermissionSetId");

                    b.HasOne("Portfolio.Domain.Core.Domain.Auth.Entities.ApplicationRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_RolePermissionSet_RoleId");

                    b.Navigation("PermissionSet");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.UserRole", b =>
                {
                    b.HasOne("Portfolio.Domain.Core.Domain.Auth.Entities.ApplicationRole", null)
                        .WithMany("UsersRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ApplicationRole_RoleId");

                    b.HasOne("Portfolio.Domain.Core.Domain.Auth.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserRole_RoleId");

                    b.HasOne("Portfolio.Domain.Core.Domain.Auth.Entities.ApplicationRole", "Role")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserRole_UserId");

                    b.HasOne("Portfolio.Domain.Core.Domain.Auth.Entities.ApplicationUser", null)
                        .WithMany("UsersRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ApplicationUser_RoleId");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.ApplicationRole", b =>
                {
                    b.Navigation("UsersRoles");
                });

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.ApplicationUser", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UsersRoles");
                });

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.Permission", b =>
                {
                    b.Navigation("PermissionPermissionSet");
                });

            modelBuilder.Entity("Portfolio.Domain.Core.Domain.Auth.Entities.PermissionSet", b =>
                {
                    b.Navigation("PermissionPermissionSet");
                });
#pragma warning restore 612, 618
        }
    }
}
