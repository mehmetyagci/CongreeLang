﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Db;

namespace Server.Migrations
{
    [DbContext(typeof(CongreeLangDbContext))]
    [Migration("20210811191856_NewFieldsAdded")]
    partial class NewFieldsAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Server.Models.Analysis", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("DocumentId")
                        .HasColumnType("bigint");

                    b.Property<double>("ElapsedMiliseconds")
                        .HasColumnType("float");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("Analyzes");
                });

            modelBuilder.Entity("Server.Models.AnalysisItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AnalysisId")
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<long>("TagId")
                        .HasColumnType("bigint");

                    b.Property<string>("Word")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnalysisId");

                    b.HasIndex("TagId");

                    b.ToTable("AnalysisItem");
                });

            modelBuilder.Entity("Server.Models.Document", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("Server.Models.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("DocumentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Server.Models.TagDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TagId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.ToTable("TagDetail");
                });

            modelBuilder.Entity("Server.Models.Analysis", b =>
                {
                    b.HasOne("Server.Models.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("Server.Models.AnalysisItem", b =>
                {
                    b.HasOne("Server.Models.Analysis", "Analysis")
                        .WithMany("AnalysisItems")
                        .HasForeignKey("AnalysisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Analysis");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Server.Models.Tag", b =>
                {
                    b.HasOne("Server.Models.Document", "Document")
                        .WithMany("Tags")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("Server.Models.TagDetail", b =>
                {
                    b.HasOne("Server.Models.Tag", "Tag")
                        .WithMany("TagDetails")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Server.Models.Analysis", b =>
                {
                    b.Navigation("AnalysisItems");
                });

            modelBuilder.Entity("Server.Models.Document", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Server.Models.Tag", b =>
                {
                    b.Navigation("TagDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
