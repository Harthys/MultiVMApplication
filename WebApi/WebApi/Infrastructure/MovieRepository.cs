using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Infrastructure
{
    public class MovieRepository
    {
        private readonly MovieApiDbContext _context;

        public MovieRepository( MovieApiDbContext context )
        {
            _context = context;
        }

        public List<Movie> GetMovies( )
        {
            return _context.Movies.Include( x => x.Reviews ).ToList( );
        }

        public Movie GetMovieById( int id )
        {
            return _context.Movies.Include( x => x.Reviews ).FirstOrDefault( x => x.Id == id );
        }

        public void AddMovie( Movie movie )
        {
            _context.Movies.Add( movie );
        }
    }
}