﻿// <auto-generated />
using System;
using MUIServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MUIServer.Migrations
{
    [DbContext(typeof(MainServerDbContext))]
    [Migration("20230630022036_Initial_MainServer_DB")]
    partial class Initial_MainServer_DB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MUIServer.Entities.MainServer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("MainServerID")
                        .HasColumnType("int");

                    b.Property<string>("MainServerIP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainServerLivetime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainServerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MainServerPort")
                        .HasColumnType("int");

                    b.Property<string>("MainServerTimeEnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainServerTimeStart")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainServerURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainServerVersion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("MainServer");
                });
#pragma warning restore 612, 618
        }
    }
}