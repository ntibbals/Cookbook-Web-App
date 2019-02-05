﻿// <auto-generated />
using System;
using Cookbook_Web_App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cookbook_Web_App.Migrations
{
    [DbContext(typeof(CookbookDbContext))]
    [Migration("20190204231539_seeded-1")]
    partial class seeded1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cookbook_Web_App.Models.Comments", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(max)");

                    b.Property<int>("SavedRecipeID");

                    b.HasKey("ID");

                    b.HasIndex("SavedRecipeID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Cookbook_Web_App.Models.SavedRecipe", b =>
                {
                    b.Property<int>("SavedRecipeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("APIReference");

                    b.Property<string>("Instructions");

                    b.Property<string>("Reviews");

                    b.Property<int?>("UserID");

                    b.Property<string>("comments");

                    b.HasKey("SavedRecipeID");

                    b.HasIndex("UserID");

                    b.ToTable("SavedRecipe");

                    b.HasData(
                        new
                        {
                            SavedRecipeID = 11,
                            APIReference = 22,
                            Instructions = "Cook until you can't cook no mo",
                            comments = "This is so good"
                        });
                });

            modelBuilder.Entity("Cookbook_Web_App.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("ID");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            ID = 33,
                            UserName = "Tom"
                        });
                });

            modelBuilder.Entity("Cookbook_Web_App.Models.Comments", b =>
                {
                    b.HasOne("Cookbook_Web_App.Models.SavedRecipe")
                        .WithMany("Comments")
                        .HasForeignKey("SavedRecipeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cookbook_Web_App.Models.SavedRecipe", b =>
                {
                    b.HasOne("Cookbook_Web_App.Models.User", "User")
                        .WithMany("SavedRecipe")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}
