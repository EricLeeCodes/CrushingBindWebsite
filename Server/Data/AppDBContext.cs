using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<ArchiveModel> ArchiveModels { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        //Seeding data

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ArchiveModel[] categoriesToSeed = new ArchiveModel[3];

            for(int i = 1; i < 4; i++)
            {
                categoriesToSeed[i - 1] = new ArchiveModel
                {
                    ArchiveId = i,
                    ArchiveThumbnailImagePath = $"uploads/Chapter_{i}_Thumbnail.png",
                    ArchiveChapterNumber = $"Chapter {i}"
                };
            }

            modelBuilder.Entity<ArchiveModel>().HasData(categoriesToSeed);

        }


    }
}
