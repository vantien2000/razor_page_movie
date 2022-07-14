using Microsoft.EntityFrameworkCore;
using RazorPageMovie;
using RazorPageMovie.Data;

namespace RazorPageMovie.Models
{
  public static class SeedData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new RazorPageMovieContext(serviceProvider.GetRequiredService
        <DbContextOptions<RazorPageMovieContext>>()))
      {
        if (context == null || context.Movie == null)
        {
          throw new ArgumentNullException("Null RazorPagesMovieContext");
        }

        //look for any movie.
        if (context.Movie.Any())
        {
          return; //DB has seed
        }

        context.Movie.AddRange(
          new Movie
          {
            Title = "When Harry Met Sally",
            ReleaseDate = DateTime.Parse("1989-2-12"),
            Genre = "Romantic Comedy",
            Price = 7.99,
            Rating = "R"
          },
          new Movie
          {
            Title = "Ghostbusters ",
            ReleaseDate = DateTime.Parse("1984-3-13"),
            Genre = "Comedy",
            Price = 8.99,
            Rating = "G"
          },
          new Movie
          {
            Title = "Ghostbusters 2",
            ReleaseDate = DateTime.Parse("1986-2-23"),
            Genre = "Comedy",
            Price = 9.99,
            Rating = "G"
          },

          new Movie
          {
            Title = "Rio Bravo",
            ReleaseDate = DateTime.Parse("1959-4-15"),
            Genre = "Western",
            Price = 3.99,
            Rating = "NA"
          }
        );
        context.SaveChanges();
      }
    }
  }
}