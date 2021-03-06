﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test_Task.Data;

namespace Test_Task.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Test_Task.Models.ApartmentModel", b =>
                {
                    b.Property<int>("ID_Apartment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApartmentFloor")
                        .HasColumnType("int");

                    b.Property<int>("ApartmentNumber")
                        .HasColumnType("int");

                    b.Property<double>("FivingArea")
                        .HasColumnType("float");

                    b.Property<double>("FullArea")
                        .HasColumnType("float");

                    b.Property<int>("ID_House")
                        .HasColumnType("int");

                    b.Property<int>("ResidentsCount")
                        .HasColumnType("int");

                    b.Property<int>("RoomCount")
                        .HasColumnType("int");

                    b.HasKey("ID_Apartment");

                    b.HasIndex("ID_House");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("Test_Task.Models.HouseModel", b =>
                {
                    b.Property<int>("ID_House")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("PostIndex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_House");

                    b.ToTable("House");
                });

            modelBuilder.Entity("Test_Task.Models.ResidentModel", b =>
                {
                    b.Property<int>("ID_Reasident")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDat")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_Apartment")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Reasident");

                    b.HasIndex("ID_Apartment");

                    b.ToTable("Residents");
                });

            modelBuilder.Entity("Test_Task.Models.ApartmentModel", b =>
                {
                    b.HasOne("Test_Task.Models.HouseModel", "House")
                        .WithMany("Apartments")
                        .HasForeignKey("ID_House")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Test_Task.Models.ResidentModel", b =>
                {
                    b.HasOne("Test_Task.Models.ApartmentModel", "Apartment")
                        .WithMany("Residents")
                        .HasForeignKey("ID_Apartment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
