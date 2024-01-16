﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QaFullStack.Model;

#nullable disable

namespace QaFullStack.Migrations
{
    [DbContext(typeof(EstateDBContext))]
    partial class EstateDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QaFullStack.Model.Booking", b =>
                {
                    b.Property<int>("BOOKING_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BOOKING_ID"), 1L, 1);

                    b.Property<string>("BUYER_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PROPERTY_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TIME")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("BOOKING_ID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("QaFullStack.Model.Buyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BUYER_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ADDRESS")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FIRST_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PHONE")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("POSTCODE")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SURNAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("QaFullStack.Model.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PROPERTY_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ADDRESS")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("QaFullStack.Model.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SELLER_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ADDRESS")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FIRST_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PHONE")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("POSTCODE")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SURNAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Sellers");
                });
#pragma warning restore 612, 618
        }
    }
}
