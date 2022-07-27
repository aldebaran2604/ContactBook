﻿// <auto-generated />
using System;
using ContactPersistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContactPersistence.Migrations
{
    [DbContext(typeof(ContactBookContext))]
    [Migration("20220727040727_AddNewColumnsToContact")]
    partial class AddNewColumnsToContact
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("ContactPersistence.Models.BusinessDepartment", b =>
                {
                    b.Property<int>("BusinessDepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("BusinessDepartmentId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("BusinessDepartments");
                });

            modelBuilder.Entity("ContactPersistence.Models.BusinessPosition", b =>
                {
                    b.Property<int>("BusinessPositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("BusinessPositionId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("BusinessPositions");
                });

            modelBuilder.Entity("ContactPersistence.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<int?>("BusinessDepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BusinessPositionID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastNames")
                        .HasColumnType("TEXT");

                    b.Property<string>("Names")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Pseudonymous")
                        .HasColumnType("TEXT");

                    b.Property<string>("Relationship")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetDirection1")
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetDirection2")
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeRelationship")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebSite")
                        .HasColumnType("TEXT");

                    b.HasKey("ContactId");

                    b.HasIndex("BusinessDepartmentId");

                    b.HasIndex("BusinessPositionID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ContactPersistence.Models.Contact", b =>
                {
                    b.HasOne("ContactPersistence.Models.BusinessDepartment", "BusinessDepartment")
                        .WithMany("Contacts")
                        .HasForeignKey("BusinessDepartmentId");

                    b.HasOne("ContactPersistence.Models.BusinessPosition", "BusinessPosition")
                        .WithMany("Contacts")
                        .HasForeignKey("BusinessPositionID");

                    b.Navigation("BusinessDepartment");

                    b.Navigation("BusinessPosition");
                });

            modelBuilder.Entity("ContactPersistence.Models.BusinessDepartment", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("ContactPersistence.Models.BusinessPosition", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}