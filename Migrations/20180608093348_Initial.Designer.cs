﻿// <auto-generated />
using Electron.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Electron.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180608093348_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799");

            modelBuilder.Entity("Electron.Context.Locations", b =>
                {
                    b.Property<int>("LocationsID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<string>("Region")
                        .IsRequired();

                    b.HasKey("LocationsID");

                    b.ToTable("Locations");

                    b.HasData(
                        new { LocationsID = 1, Location = "Kumasi", Region = "Ashanti" },
                        new { LocationsID = 2, Location = "Accra", Region = "Greater Accra" },
                        new { LocationsID = 3, Location = "Nalerigu", Region = "Northern" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
