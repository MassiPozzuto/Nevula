﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NevulaForo.Models.DB;

#nullable disable

namespace NevulaForo.Migrations
{
    [DbContext(typeof(NevulaContext))]
    partial class NevulaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NevulaForo.Models.DB.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("description");

                    b.Property<int>("IdPublication")
                        .HasColumnType("int")
                        .HasColumnName("id_publication");

                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    b.HasKey("Id")
                        .HasName("PK_Comments");

                    b.HasIndex("IdPublication");

                    b.HasIndex("IdUser");

                    b.ToTable("Comment", (string)null);
                });

            modelBuilder.Entity("NevulaForo.Models.DB.Publication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1750)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1750)")
                        .HasColumnName("description");

                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("PK_Publications");

                    b.HasIndex("IdUser");

                    b.ToTable("Publication", (string)null);
                });

            modelBuilder.Entity("NevulaForo.Models.DB.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Role1")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("role");

                    b.HasKey("Id")
                        .HasName("PK_roles");

                    b.ToTable("role", (string)null);
                });

            modelBuilder.Entity("NevulaForo.Models.DB.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("password");

                    b.Property<string>("Surname")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("surname");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("PK_Users");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("NevulaForo.Models.DB.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdRole")
                        .HasColumnType("int")
                        .HasColumnName("id_role");

                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("modified_at");

                    b.HasKey("Id")
                        .HasName("PK_users_roles");

                    b.HasIndex("IdRole");

                    b.HasIndex("IdUser");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("NevulaForo.Models.DB.Comment", b =>
                {
                    b.HasOne("NevulaForo.Models.DB.Publication", "IdPublicationNavigation")
                        .WithMany("Comments")
                        .HasForeignKey("IdPublication")
                        .IsRequired()
                        .HasConstraintName("FK_comments_publications");

                    b.HasOne("NevulaForo.Models.DB.User", "IdUserNavigation")
                        .WithMany("Comments")
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("FK_comments_users");

                    b.Navigation("IdPublicationNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("NevulaForo.Models.DB.Publication", b =>
                {
                    b.HasOne("NevulaForo.Models.DB.User", "IdUserNavigation")
                        .WithMany("Publications")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_publications_users");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("NevulaForo.Models.DB.UserRole", b =>
                {
                    b.HasOne("NevulaForo.Models.DB.Role", "IdRoleNavigation")
                        .WithMany("UserRoles")
                        .HasForeignKey("IdRole")
                        .IsRequired()
                        .HasConstraintName("FK_users_roles_roles");

                    b.HasOne("NevulaForo.Models.DB.User", "IdUserNavigation")
                        .WithMany("UserRoles")
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("FK_users_roles_users");

                    b.Navigation("IdRoleNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("NevulaForo.Models.DB.Publication", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("NevulaForo.Models.DB.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("NevulaForo.Models.DB.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Publications");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
