using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;

namespace Server.Data
{
    public class AppDBContext : IdentityDbContext
    {
        public DbSet<ArchiveModel> ArchiveModels { get; set; }
        public DbSet<Post> Posts { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        //Seeding data

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region ArchiveModels seed

            ArchiveModel[] categoriesToSeed = new ArchiveModel[3];

            for (int i = 1; i < 4; i++)
            {
                categoriesToSeed[i - 1] = new ArchiveModel
                {
                    ArchiveId = i,
                    ArchiveThumbnailImagePath = $"uploads/Chapter_{i}_Thumbnail.png",
                    ArchiveChapterNumber = $"Chapter {i}"
                };
            }

            modelBuilder.Entity<ArchiveModel>().HasData(categoriesToSeed);

            #endregion

            modelBuilder.Entity<Post>(
                entity =>
                {
                    entity.HasOne(post => post.ArchiveModel)
                    .WithMany(archivemodel => archivemodel.Posts)
                    .HasForeignKey("ArchiveId");
                });

            #region Posts seed

            Post[] postsToSeed = new Post[6];

            for (int i = 1; i < 7; i++)
            {
                string postTitle = string.Empty;
                int archiveId = 0;

                switch (i)
                {
                    case 1:
                        postTitle = "First post";
                        archiveId = 1;
                        break;
                    case 2:
                        postTitle = "Second post";
                        archiveId = 2;
                        break;
                    case 3:
                        postTitle = "Third post";
                        archiveId = 3;
                        break;
                    case 4:
                        postTitle = "Fourth post";
                        archiveId = 1;
                        break;
                    case 5:
                        postTitle = "Fifth post";
                        archiveId = 2;
                        break;
                    case 6:
                        postTitle = "Sixth post";
                        archiveId = 3;
                        break;
                    default:
                        break;
                }

                postsToSeed[i - 1] = new Post
                {
                    PostId = i,
                    ArchiveThumbnailImagePath = "uploads/placeholder.jpg",
                    Title = postTitle,
                    Excerpt = "This is an excerpt example",
                    Content = string.Empty,
                    PublishDate = DateTime.UtcNow.ToString("MM/dd/yyyy"),
                    Published = true,
                    ArchiveId = archiveId
                };
            }

            modelBuilder.Entity<Post>().HasData(postsToSeed);

            #endregion

            #region Administrator Role Seed

            const string administratorRoleName = "Administrator";

            IdentityRole administratorRoleToSeed = new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = administratorRoleName,
                NormalizedName = administratorRoleName.ToUpperInvariant()
            };

            modelBuilder.Entity<IdentityRole>().HasData(administratorRoleToSeed);


            #endregion

            #region Administrator User Seed

            const string administratorUserEmail = "admin@crushingbind.com";

            var passwordHasher = new PasswordHasher<IdentityUser>();

            IdentityUser administratorUserToSeed = new()
            {
                AccessFailedCount = 5,
                Id = Guid.NewGuid().ToString(),
                UserName = administratorUserEmail,
                NormalizedUserName = administratorUserEmail.ToUpperInvariant(),
                Email = administratorUserEmail,
                NormalizedEmail = administratorUserEmail.ToUpperInvariant(),
                PasswordHash = string.Empty,
            };

            string hashedPassword = passwordHasher.HashPassword(administratorUserToSeed, "Password123!");

            administratorUserToSeed.PasswordHash = hashedPassword;

            modelBuilder.Entity<IdentityUser>().HasData(administratorUserToSeed);


            #endregion

            #region Add The Administrator User To The Administrator Role

            IdentityUserRole<string> identityUserRoleToSeed = new()
            {
                RoleId = administratorRoleToSeed.Id,
                UserId = administratorUserToSeed.Id,
            };

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(identityUserRoleToSeed);

            #endregion
        }


    }
}
