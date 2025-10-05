using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AlbumRegister.Data;


namespace AlbumRegister.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AlbumContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<AlbumContext>>()))
        {
            if (context.Albums.Any() || context.Genres.Any())
            {
                return;   
            }

            Genre g1 = new Genre { GenreName = "Pop" };
            Genre g2 = new Genre { GenreName = "Rock" };
            Genre g3 = new Genre { GenreName = "Hip Hop" };
            Genre g4 = new Genre { GenreName = "Country" };
            Genre g5 = new Genre { GenreName = "Soul" };

            context.Albums.AddRange(
                new Album
                {
                    Title = "When We All Fall Asleep, Where Do We Go?",
                    ReleaseDate = DateTime.Parse("2019-03-29"),
                    Artist = "Billie Eilish",
                    Group = "Billie Eilish",
                    Genre = g1
                },
                new Album
                {
                    Title = "Happier Than Ever",
                    ReleaseDate = DateTime.Parse("2021-07-30"),
                    Artist = "Billie Eilish",
                    Group = "Billie Eilish",
                    Genre = g1,
                    IsShown = false
                },
                new Album
                {
                    Title = "25",
                    ReleaseDate = DateTime.Parse("2015-11-20"),
                    Artist = "Adele",
                    Group = "Adele",
                    Genre = g1
                },
                new Album
                {
                    Title = "Abbey Road",
                    ReleaseDate = DateTime.Parse("1969-09-26"),
                    Artist = "The Beatles",
                    Group = "The Beatles",
                    Genre = g2
                },
                new Album
                {
                    Title = "The Dark Side of the Moon",
                    ReleaseDate = DateTime.Parse("1973-03-01"),
                    Artist = "Pink Floyd",
                    Group = "Pink Floyd",
                    Genre = g2
                },
                new Album
                {
                    Title = "To Pimp a Butterfly",
                    ReleaseDate = DateTime.Parse("2015-03-15"),
                    Artist = "Kendrick Lamar",
                    Group = "Kendrick Lamar",
                    Genre = g3
                },
                new Album
                {
                    Title = "Good Kid, M.A.A.D City",
                    ReleaseDate = DateTime.Parse("2012-10-22"),
                    Artist = "Kendrick Lamar",
                    Group = "Kendrick Lamar",
                    Genre = g3
                },
                new Album
                {
                    Title = "1989",
                    ReleaseDate = DateTime.Parse("2014-10-27"),
                    Artist = "Taylor Swift",
                    Group = "Taylor Swift",
                    Genre = g4
                },
                new Album
                {
                    Title = "Fearless",
                    ReleaseDate = DateTime.Parse("2008-11-11"),
                    Artist = "Taylor Swift",
                    Group = "Taylor Swift",
                    Genre = g4
                },
                new Album
                {
                    Title = "Lover",
                    ReleaseDate = DateTime.Parse("2019-08-23"),
                    Artist = "Taylor Swift",
                    Group = "Taylor Swift",
                    Genre = g1
                },
                new Album
                {
                    Title = "Back to Black",
                    ReleaseDate = DateTime.Parse("2006-10-27"),
                    Artist = "Amy Winehouse",
                    Group = "Amy Winehouse",
                    Genre = g5
                },
                new Album
                {
                    Title = "Frank",
                    ReleaseDate = DateTime.Parse("2003-10-20"),
                    Artist = "Amy Winehouse",
                    Group = "Amy Winehouse",
                    Genre = g5
                },
                new Album
                {
                    Title = "Channel Orange",
                    ReleaseDate = DateTime.Parse("2012-07-10"),
                    Artist = "Frank Ocean",
                    Group = "Frank Ocean",
                    Genre = g5
                }, 
                new Album
                {
                    Title = "Blonde",
                    ReleaseDate = DateTime.Parse("2016-08-20"),
                    Artist = "Frank Ocean",
                    Group = "Frank Ocean",
                    Genre = g5
                },
                new Album
                {
                    Title = "Currents",
                    ReleaseDate = DateTime.Parse("2015-07-17"),
                    Artist = "Tame Impala",
                    Group = "Tame Impala",
                    Genre = g2
                }
                
            );
            context.SaveChanges();
        }
    }
}