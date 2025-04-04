﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QingYuan.Services.EF;

#nullable disable

namespace QingYuan.Gateway.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250319100128_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QingYuan.Model.Tables.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("content");

                    b.Property<DateTimeOffset>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("create_time")
                        .HasDefaultValueSql("SYSDATETIMEOFFSET()");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("tinyint")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<DateTimeOffset?>("UpdateTime")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("update_time");

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.ToTable("user");
                });
#pragma warning restore 612, 618
        }
    }
}
