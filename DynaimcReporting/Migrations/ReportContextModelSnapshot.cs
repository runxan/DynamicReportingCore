﻿// <auto-generated />
using DynaimcReporting.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DynaimcReporting.Migrations
{
    [DbContext(typeof(ReportContext))]
    partial class ReportContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DynaimcReporting.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DynaimcReporting.Models.ReportMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategorieId")
                        .HasColumnType("int");

                    b.Property<string>("DatabaseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Query")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReportTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.HasIndex("ReportTypeId");

                    b.ToTable("ReportMasters");
                });

            modelBuilder.Entity("DynaimcReporting.Models.ReportParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParameterDataType")
                        .HasColumnType("int");

                    b.Property<string>("Query")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReportMasterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReportMasterId");

                    b.ToTable("ReportParameters");
                });

            modelBuilder.Entity("DynaimcReporting.Models.ReportType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiagramType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ReportType");
                });

            modelBuilder.Entity("DynaimcReporting.Models.ReportMaster", b =>
                {
                    b.HasOne("DynaimcReporting.Models.Category", "Categories")
                        .WithMany()
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DynaimcReporting.Models.ReportType", "ReportTypes")
                        .WithMany()
                        .HasForeignKey("ReportTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");

                    b.Navigation("ReportTypes");
                });

            modelBuilder.Entity("DynaimcReporting.Models.ReportParameter", b =>
                {
                    b.HasOne("DynaimcReporting.Models.ReportMaster", "ReportMasters")
                        .WithMany()
                        .HasForeignKey("ReportMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReportMasters");
                });
#pragma warning restore 612, 618
        }
    }
}
