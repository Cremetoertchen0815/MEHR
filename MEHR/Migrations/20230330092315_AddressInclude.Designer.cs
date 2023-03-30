﻿// <auto-generated />
using System;
using MEHR.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MEHR.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230330092315_AddressInclude")]
    partial class AddressInclude
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.ToTable("Users");
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

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("MEHR.Models.FoodLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

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

                    b.ToTable("FoodLocations");
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

                    b.ToTable("FoodTags");
                });

            modelBuilder.Entity("MEHR.Models.HistoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CreationDate")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("OwnerId");

                    b.ToTable("HistoryItems");
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

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("LocationId");

                    b.ToTable("Ratings");
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

            modelBuilder.Entity("MEHR.Models.HistoryItem", b =>
                {
                    b.HasOne("MEHR.Models.FoodLocation", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MEHR.Models.AppUser", "Owner")
                        .WithMany("History")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Owner");
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
