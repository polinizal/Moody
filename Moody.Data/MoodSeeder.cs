using Moody.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Moody.Data.Seeding
{
    public static class MoodSeeder
    {
        public static void SeedMoods(this ModelBuilder modelBuilder)
        {
            var moods = new List<Mood>
            {
                // Positive moods
                new Mood { Id = 1, MoodType = "Anxious" },
                new Mood { Id = 2, MoodType = "Stressed" },
                new Mood { Id = 3, MoodType = "Tired" },
                new Mood { Id = 4, MoodType = "Angry" },
                new Mood { Id = 5, MoodType = "Sad" },

                // Negative moods
                new Mood { Id = 6, MoodType = "Relaxed" },
                new Mood { Id = 7, MoodType = "Optimistic" },
                new Mood { Id = 8, MoodType = "Cheerful" },
                new Mood { Id = 9, MoodType = "Excited" },
                new Mood { Id = 10, MoodType = "Happy" }
            };

            modelBuilder.Entity<Mood>().HasData(moods);
        }
    }
}
