﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Data;

#nullable disable

namespace Server.Data.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
#pragma warning restore 612, 618
        }
    }
}
