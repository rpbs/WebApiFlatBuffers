﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(PresentationContext))]
    partial class PresentationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApi.Dump", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("FlatBufferData")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varbinary(1)");

                    b.Property<string>("JsonData")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.HasKey("UserId")
                        .HasName("Users_pk");

                    b.ToTable("Dump", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
