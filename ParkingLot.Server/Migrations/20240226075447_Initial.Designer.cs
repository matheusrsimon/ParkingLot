﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingLot.Server.Data;

#nullable disable

namespace ParkingLot.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240226075447_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ParkingLot.Server.Models.ParkingSection", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SizeId");

                    b.ToTable("ParkingSections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Count = 10,
                            SizeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Count = 10,
                            SizeId = 2
                        },
                        new
                        {
                            Id = 3,
                            Count = 10,
                            SizeId = 3
                        });
                });

            modelBuilder.Entity("ParkingLot.Server.Models.SpotSize", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SpotSizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Small"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Large"
                        });
                });

            modelBuilder.Entity("ParkingLot.Server.Models.SpotSizeUsage", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("SpotSizeId")
                        .HasColumnType("int");

                    b.Property<int>("Usage")
                        .HasColumnType("int");

                    b.Property<int>("VehicleSizeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpotSizeId");

                    b.HasIndex("VehicleSizeId");

                    b.ToTable("SpotSizeUsages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SpotSizeId = 1,
                            Usage = 1,
                            VehicleSizeId = 1
                        },
                        new
                        {
                            Id = 2,
                            SpotSizeId = 2,
                            Usage = 1,
                            VehicleSizeId = 1
                        },
                        new
                        {
                            Id = 3,
                            SpotSizeId = 3,
                            Usage = 1,
                            VehicleSizeId = 1
                        },
                        new
                        {
                            Id = 4,
                            SpotSizeId = 2,
                            Usage = 1,
                            VehicleSizeId = 2
                        },
                        new
                        {
                            Id = 5,
                            SpotSizeId = 3,
                            Usage = 1,
                            VehicleSizeId = 2
                        },
                        new
                        {
                            Id = 6,
                            SpotSizeId = 2,
                            Usage = 3,
                            VehicleSizeId = 3
                        },
                        new
                        {
                            Id = 7,
                            SpotSizeId = 3,
                            Usage = 1,
                            VehicleSizeId = 3
                        });
                });

            modelBuilder.Entity("ParkingLot.Server.Models.Vehicle", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.HasIndex("TypeId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("ParkingLot.Server.Models.VehicleType", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SizeId");

                    b.ToTable("VehicleTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Motorcycle",
                            SizeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Car",
                            SizeId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Van",
                            SizeId = 3
                        });
                });

            modelBuilder.Entity("ParkingLot.Server.Models.ParkingSection", b =>
                {
                    b.HasOne("ParkingLot.Server.Models.SpotSize", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Size");
                });

            modelBuilder.Entity("ParkingLot.Server.Models.SpotSizeUsage", b =>
                {
                    b.HasOne("ParkingLot.Server.Models.SpotSize", "SpotSize")
                        .WithMany("SpotUsage")
                        .HasForeignKey("SpotSizeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ParkingLot.Server.Models.SpotSize", "VehicleSize")
                        .WithMany("VehicleUsage")
                        .HasForeignKey("VehicleSizeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SpotSize");

                    b.Navigation("VehicleSize");
                });

            modelBuilder.Entity("ParkingLot.Server.Models.Vehicle", b =>
                {
                    b.HasOne("ParkingLot.Server.Models.ParkingSection", "Section")
                        .WithMany("Vehicles")
                        .HasForeignKey("SectionId");

                    b.HasOne("ParkingLot.Server.Models.VehicleType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("ParkingLot.Server.Models.VehicleType", b =>
                {
                    b.HasOne("ParkingLot.Server.Models.SpotSize", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Size");
                });

            modelBuilder.Entity("ParkingLot.Server.Models.ParkingSection", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("ParkingLot.Server.Models.SpotSize", b =>
                {
                    b.Navigation("SpotUsage");

                    b.Navigation("VehicleUsage");
                });
#pragma warning restore 612, 618
        }
    }
}
