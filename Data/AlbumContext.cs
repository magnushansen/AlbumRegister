using Microsoft.EntityFrameworkCore;
using AlbumRegister.Models;

namespace AlbumRegister.Data
{
    public class AlbumContext : DbContext
    {
        public AlbumContext(DbContextOptions<AlbumContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Albums => Set<Album>();
        public DbSet<Genre> Genres => Set<Genre>();

    }
}
