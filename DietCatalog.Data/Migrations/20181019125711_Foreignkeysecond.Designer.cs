﻿// <auto-generated />
using DietCatalog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DietCatalog.Data.Migrations
{
    [DbContext(typeof(DietCatalogDBContext))]
    [Migration("20181019125711_Foreignkeysecond")]
    partial class Foreignkeysecond
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DietCatalog.Data.EntityConstants.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("DietCatalog.Data.EntityConstants.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DietCatalog.Data.EntityConstants.CategoryDiet", b =>
                {
                    b.Property<int>("CategoryId");

                    b.Property<int>("DietId");

                    b.HasKey("CategoryId", "DietId");

                    b.HasIndex("DietId");

                    b.ToTable("CategoryDiets");
                });

            modelBuilder.Entity("DietCatalog.Data.EntityConstants.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Breakfast")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("DailyTotal")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("DietId");

                    b.Property<string>("Dinner")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("FirstSnack")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("LastSnack")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Lunch")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Recommended")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("SecondSnack")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("WeekDay")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("DietId");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("DietCatalog.Data.EntityConstants.Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AgeRestriction");

                    b.Property<int>("AuthorId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Difficult");

                    b.Property<string>("HowLong")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<DateTime?>("ReleaseDate")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("DietCatalog.Data.EntityConstants.CategoryDiet", b =>
                {
                    b.HasOne("DietCatalog.Data.EntityConstants.Category", "Category")
                        .WithMany("Diets")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DietCatalog.Data.EntityConstants.Diet", "Diet")
                        .WithMany("Categories")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DietCatalog.Data.EntityConstants.Day", b =>
                {
                    b.HasOne("DietCatalog.Data.EntityConstants.Diet", "Diet")
                        .WithMany("Days")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DietCatalog.Data.EntityConstants.Diet", b =>
                {
                    b.HasOne("DietCatalog.Data.EntityConstants.Author", "Author")
                        .WithMany("Diets")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
