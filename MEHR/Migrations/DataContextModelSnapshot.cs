﻿// <auto-generated />
using System;
using MEHR.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MEHR.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("MEHR.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("CookieHash")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("MEHR.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("LowerPriceRange")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TagId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("UpperPriceRange")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("TagId");

                    b.ToTable("Foods", (string)null);
                });

            modelBuilder.Entity("MEHR.Models.FoodLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasDelivery")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Icon")
                        .HasColumnType("INTEGER");

                    b.Property<double>("LocationLatitude")
                        .HasColumnType("REAL");

                    b.Property<double>("LocationLongitude")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("OpeningTimesSerial")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("FoodLocations", (string)null);
                });

            modelBuilder.Entity("MEHR.Models.FoodTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Color")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FoodTags", (string)null);
                });

            modelBuilder.Entity("MEHR.Models.LocationRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Rating")
                        .HasColumnType("REAL");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("LocationId");

                    b.ToTable("Ratings", (string)null);
                });

            modelBuilder.Entity("MEHR.Models.Food", b =>
                {
                    b.HasOne("MEHR.Models.FoodLocation", "Location")
                        .WithMany("Foods")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MEHR.Models.FoodTag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");

                    b.Navigation("Location");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("MEHR.Models.FoodLocation", b =>
                {
                    b.HasOne("MEHR.Models.AppUser", null)
                        .WithMany("History")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("MEHR.Models.LocationRating", b =>
                {
                    b.HasOne("MEHR.Models.AppUser", "Author")
                        .WithMany("Ratings")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MEHR.Models.FoodLocation", "Location")
                        .WithMany("Ratings")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Author");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("MEHR.Models.AppUser", b =>
                {
                    b.Navigation("History");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("MEHR.Models.FoodLocation", b =>
                {
                    b.Navigation("Foods");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
