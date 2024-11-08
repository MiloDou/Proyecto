﻿// <auto-generated />
using BibliotecaCarlosMeridaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibliotecaCarlosMeridaAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241104053201_UpdatePrimaryKey")]
    partial class UpdatePrimaryKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BibliotecaCarlosMeridaAPI.Models.Libro", b =>
                {
                    b.Property<int>("IdLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("DisponiblePrestamo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Portada")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("VecesPrestado")
                        .HasColumnType("int");

                    b.HasKey("IdLibro");

                    b.ToTable("Libros");
                });
#pragma warning restore 612, 618
        }
    }
}
