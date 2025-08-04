using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context)
    {
        //apply any pending migrations
        await context.Database.MigrateAsync();

        //if we already have data - return
        if (await context.Activities.AnyAsync())
        {
            return;
        }

        var activities = new List<Activity>
        {
            new Activity
            {
                Title = "Morning Run",
                Date = DateTime.UtcNow.AddDays(1),
                Description = "A quick 5k run in the park",
                Category = "Fitness",
                City = "London",
                Venue = "Hyde Park",
                Latitude = 51.5074,
                Longitude = -0.1278,
                IsCancelled = false
            },
            new Activity
            {
                Title = "Coffee Meetup",
                Date = DateTime.UtcNow.AddDays(2),
                Description = "Meet friends for coffee and chat",
                Category = "Social",
                City = "Manchester",
                Venue = "Cafe Nero",
                Latitude = 53.4808,
                Longitude = -2.2426,
                IsCancelled = false
            }
        };

        await context.Activities.AddRangeAsync(activities);
        await context.SaveChangesAsync();
    }
}