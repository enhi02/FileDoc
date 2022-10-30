﻿// <auto-generated />
using System;
using FileDoc.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FileDoc.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FileDoc.Model.CargoManifest", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FlightNo")
                        .HasColumnType("int");

                    b.Property<string>("PointOfLoading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PointOfUnLoading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("FlightId");

                    b.ToTable("cargoManifests");
                });

            modelBuilder.Entity("FileDoc.Model.DocumentList", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DocumentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DocumentId");

                    b.HasIndex("UserId");

                    b.ToTable("documentLists");
                });

            modelBuilder.Entity("FileDoc.Model.GroupPermission", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.HasKey("GroupId");

                    b.ToTable("groupPermissions");
                });

            modelBuilder.Entity("FileDoc.Model.RoleModel", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("FileDoc.Model.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("GroupId");

                    b.HasIndex("RoleId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("FileDoc.Model.DocumentList", b =>
                {
                    b.HasOne("FileDoc.Model.UserModel", "User")
                        .WithMany("documentLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FileDoc.Model.UserModel", b =>
                {
                    b.HasOne("FileDoc.Model.GroupPermission", "GroupPermission")
                        .WithMany("users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FileDoc.Model.RoleModel", "Role")
                        .WithMany("users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GroupPermission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("FileDoc.Model.GroupPermission", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("FileDoc.Model.RoleModel", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("FileDoc.Model.UserModel", b =>
                {
                    b.Navigation("documentLists");
                });
#pragma warning restore 612, 618
        }
    }
}
