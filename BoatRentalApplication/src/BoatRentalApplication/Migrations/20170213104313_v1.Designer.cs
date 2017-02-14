using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BoatRentalApplication.Models;

namespace BoatRentalApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170213104313_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BoatRentalApplication.Models.Boat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Available");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Name");

                    b.Property<string>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Boat");
                });

            modelBuilder.Entity("BoatRentalApplication.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BoatId");

                    b.Property<int>("CustomerId");

                    b.Property<string>("CustomerSocialSecurityNumber");

                    b.Property<decimal>("RentalCost");

                    b.Property<DateTime>("RentalDate");

                    b.Property<DateTime>("ReturnDate");

                    b.HasKey("Id");

                    b.HasIndex("BoatId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("BoatRentalApplication.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("BoatRentalApplication.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.Property<string>("SocialSecurityNumber");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("BoatRentalApplication.Models.Boat", b =>
                {
                    b.HasOne("BoatRentalApplication.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BoatRentalApplication.Models.Booking", b =>
                {
                    b.HasOne("BoatRentalApplication.Models.Boat", "Boat")
                        .WithMany()
                        .HasForeignKey("BoatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BoatRentalApplication.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
