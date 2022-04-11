﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Data;

#nullable disable

namespace Server.Data.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20220408235038_InitialPostModel")]
    partial class InitialPostModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("Shared.Models.ArchiveModel", b =>
                {
                    b.Property<int>("ArchiveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ArchiveChapterNumber")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ArchiveThumbnailImagePath")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("ArchiveId");

                    b.ToTable("ArchiveModels");

                    b.HasData(
                        new
                        {
                            ArchiveId = 1,
                            ArchiveChapterNumber = "Chapter 1",
                            ArchiveThumbnailImagePath = "uploads/Chapter_1_Thumbnail.png"
                        },
                        new
                        {
                            ArchiveId = 2,
                            ArchiveChapterNumber = "Chapter 2",
                            ArchiveThumbnailImagePath = "uploads/Chapter_2_Thumbnail.png"
                        },
                        new
                        {
                            ArchiveId = 3,
                            ArchiveChapterNumber = "Chapter 3",
                            ArchiveThumbnailImagePath = "uploads/Chapter_3_Thumbnail.png"
                        });
                });

            modelBuilder.Entity("Shared.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArchiveId")
                        .HasMaxLength(256)
                        .HasColumnType("INTEGER");

                    b.Property<string>("ArchiveThumbnailImagePath")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(65536)
                        .HasColumnType("TEXT");

                    b.Property<string>("IntroBorder")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PublishDate")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Published")
                        .HasMaxLength(256)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.HasKey("PostId");

                    b.HasIndex("ArchiveId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            ArchiveId = 1,
                            ArchiveThumbnailImagePath = "uploads/placeholder.jpg",
                            Content = "",
                            IntroBorder = "uploads/intro_border.png",
                            PublishDate = "04/08/2022",
                            Published = true,
                            Title = "First post"
                        },
                        new
                        {
                            PostId = 2,
                            ArchiveId = 2,
                            ArchiveThumbnailImagePath = "uploads/placeholder.jpg",
                            Content = "",
                            IntroBorder = "uploads/intro_border.png",
                            PublishDate = "04/08/2022",
                            Published = true,
                            Title = "Second post"
                        },
                        new
                        {
                            PostId = 3,
                            ArchiveId = 3,
                            ArchiveThumbnailImagePath = "uploads/placeholder.jpg",
                            Content = "",
                            IntroBorder = "uploads/intro_border.png",
                            PublishDate = "04/08/2022",
                            Published = true,
                            Title = "Third post"
                        },
                        new
                        {
                            PostId = 4,
                            ArchiveId = 1,
                            ArchiveThumbnailImagePath = "uploads/placeholder.jpg",
                            Content = "",
                            IntroBorder = "uploads/intro_border.png",
                            PublishDate = "04/08/2022",
                            Published = true,
                            Title = "Fourth post"
                        },
                        new
                        {
                            PostId = 5,
                            ArchiveId = 2,
                            ArchiveThumbnailImagePath = "uploads/placeholder.jpg",
                            Content = "",
                            IntroBorder = "uploads/intro_border.png",
                            PublishDate = "04/08/2022",
                            Published = true,
                            Title = "Fifth post"
                        },
                        new
                        {
                            PostId = 6,
                            ArchiveId = 3,
                            ArchiveThumbnailImagePath = "uploads/placeholder.jpg",
                            Content = "",
                            IntroBorder = "uploads/intro_border.png",
                            PublishDate = "04/08/2022",
                            Published = true,
                            Title = "Sixth post"
                        });
                });

            modelBuilder.Entity("Shared.Models.Post", b =>
                {
                    b.HasOne("Shared.Models.ArchiveModel", "ArchiveModel")
                        .WithMany("Posts")
                        .HasForeignKey("ArchiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArchiveModel");
                });

            modelBuilder.Entity("Shared.Models.ArchiveModel", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}