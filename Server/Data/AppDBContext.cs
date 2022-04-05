using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Archive> Archives { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        //Seeding data

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Archive[] categoriesToSeed = new Archive[3];

            for(int i = 1; i < 4; i++)
            {
                categoriesToSeed[i - 1] = new Archive
                {
                    ArchiveId = i,
                    ArchiveImagePath = "uploads/placeholder.jpg",
                    ArchiveChapterNumber = $"Chapter {i}"
                };
            }

            modelBuilder.Entity<Archive>().HasData(categoriesToSeed);

        }


    }
}
