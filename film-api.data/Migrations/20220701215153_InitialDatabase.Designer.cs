﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using film_api.data.Models;

#nullable disable

namespace film_api.data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220701215153_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("film_api.data.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("MovieId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("film_api.data.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("film_api.data.Actor", b =>
                {
                    b.HasOne("film_api.data.Movie", null)
                        .WithMany("Actors")
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("film_api.data.Movie", b =>
                {
                    b.Navigation("Actors");
                });
#pragma warning restore 612, 618
        }
    }
}
