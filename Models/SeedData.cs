using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "The RM",
                    ReleaseDate = DateTime.Parse("2003-2-12"),
                    Genre = "Comedy",
                    Rating = "PG",
                    Price = 5.99M,
                    ImageName = "TheRm.jpg"
                },
                new Movie
                {
                    Title = "The Other Side of Heaven",
                    ReleaseDate = DateTime.Parse("2001-3-13"),
                    Genre = "Adventure",
                    Rating = "PG",
                    Price = 8.99M,
                    ImageName = "TheOtherSideofHeaven.jpg"
                },
                new Movie
                {
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("2014-2-23"),
                    Genre = "Documentary",
                    Rating = "PG",
                    Price = 9.99M,
                    ImageName = "MeetTheMormons.jpg"
                }
            );
            context.SaveChanges();
        }
    }
}