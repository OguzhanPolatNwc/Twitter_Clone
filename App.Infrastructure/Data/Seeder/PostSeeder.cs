using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Data.Seeder
{
    public class PostSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(new List<Post>
            {
                new Post {
                    Id = 1,
                    Content = "Hi this is a test tweet",
                    UserId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
            });
        }
    }
}