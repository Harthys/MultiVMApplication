using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Infrastructure
{
    public class MovieApiDbContext : DbContext
    {
        public MovieApiDbContext( DbContextOptions options ) : base( options )
        {
        }
        
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}