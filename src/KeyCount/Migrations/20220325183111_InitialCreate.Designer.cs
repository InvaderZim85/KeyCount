﻿// <auto-generated />
using System;
using KeyCount.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KeyCount.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220325183111_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("KeyCount.DataObjects.DayKeyCount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Day")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Day")
                        .IsUnique();

                    b.ToTable("DayKeyCount");
                });

            modelBuilder.Entity("KeyCount.DataObjects.KeyListEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("KeyCode")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("KeyCode")
                        .IsUnique();

                    b.ToTable("KeyList");
                });
#pragma warning restore 612, 618
        }
    }
}
